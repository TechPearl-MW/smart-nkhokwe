using System;
using System.Drawing;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace desktop_app.Forms
{
    public partial class Home : Form
    {
        private SerialPort serialPort;
        private System.Windows.Forms.Timer dataTimer;
        private string connectionString = "server=localhost;user=root;password=;database=smartsilo;";
        private bool alertSent = false;
        private bool tempAlertSent = false;

        public Home()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            try
            {
                serialPort = new SerialPort("COM6", 9600)
                {
                    NewLine = "\n",
                    ReadTimeout = 2000
                };
                serialPort.Open();

                dataTimer = new System.Windows.Forms.Timer
                {
                    Interval = 3000
                };
                dataTimer.Tick += DataTimer_Tick;
                dataTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening serial port: " + ex.Message);
            }
        }

        private void DataTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort == null || !serialPort.IsOpen)
                return;

            try
            {
                string line = serialPort.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split(',');

                    // Expected: temp,humidity,moisture,grainLevel,status
                    if (parts.Length == 5)
                    {
                        double temp = GetValue(parts, 0);
                        double humidity = GetValue(parts, 1);
                        double moisture = GetValue(parts, 2);
                        string grainLevelText = parts[3].Trim();
                        string status = parts[4].Trim();

                        // Match Arduino logic: Alert when temp ≥ 32°C
                        bool isTempAlert = temp >= 32.0;
                        bool isMoistureAlert = moisture >= 16.0;
                        bool isHumidityAlert = humidity >= 80.0;
                        bool isAlert = isTempAlert || isMoistureAlert || isHumidityAlert;

                        // Update UI display
                        this.Invoke((MethodInvoker)delegate
                        {
                            labelTemperature.Text = $"{temp:F1} °C";
                            labelHumidity.Text = $"{humidity:F1} %";
                            labelMoisture.Text = $"{moisture:F1} %";
                            labelDistance.Text = grainLevelText;

                            // Reset label colors first
                            labelTemperature.ForeColor = Color.White;
                            labelHumidity.ForeColor = Color.White;
                            labelMoisture.ForeColor = Color.White;
                            labelDistance.ForeColor = Color.White;

                            if (isAlert)
                            {
                                labelAlerts.Text = "⚠️ ALERT";
                                labelAlerts.ForeColor = Color.Red;
                                labelAlerts.BackColor = Color.LightPink;
                                labelAlerts.Font = new Font(labelAlerts.Font, FontStyle.Bold);

                                if (isTempAlert)
                                    labelTemperature.ForeColor = Color.Red;

                                if (isHumidityAlert)
                                    labelHumidity.ForeColor = Color.Red;

                                if (isMoistureAlert)
                                    labelMoisture.ForeColor = Color.Red;
                            }
                            else
                            {
                                labelAlerts.Text = "Normal";
                                labelAlerts.ForeColor = Color.Green;
                                labelAlerts.BackColor = SystemColors.Control;
                                labelAlerts.Font = new Font(labelAlerts.Font, FontStyle.Regular);
                            }
                        });

                        // Log to database
                        LogSensorData(temp, humidity, grainLevelText, moisture, isAlert);

                        // SMS logic — send only once per true alert cycle
                        if (isAlert && !alertSent)
                        {
                            string alertType = "SILO CONDITION ALERT";
                            SendSmsAlert(temp, humidity, grainLevelText, moisture, alertType);
                            alertSent = true;
                        }
                        else if (!isAlert)
                        {
                            alertSent = false;
                        }
                    }
                }
            }
            catch (TimeoutException) { }
            catch (Exception ex)
            {
                Console.WriteLine("Serial read error: " + ex.Message);
            }
        }

        private double GetValue(string[] parts, int index)
        {
            if (parts.Length > index)
            {
                Match match = Regex.Match(parts[index], @"[-+]?\d*\.?\d+");
                if (match.Success && double.TryParse(match.Value, out double result))
                    return result;
            }
            return 0;
        }

        private void LogSensorData(double temp, double humidity, string distance, double moisture, bool alert)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO sensor_readings 
                             (temperature, humidity, moisture, distance, alert, timestamp) 
                             VALUES (@temperature, @humidity, @moisture, @distance, @alert, NOW())";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@temperature", temp);
                    cmd.Parameters.AddWithValue("@humidity", humidity);
                    cmd.Parameters.AddWithValue("@moisture", moisture);
                    cmd.Parameters.AddWithValue("@distance", distance);
                    cmd.Parameters.AddWithValue("@alert", alert ? "ALERT" : "NORMAL");
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database error: " + ex.Message);
                }
            }
        }

        private void SendSmsAlert(double temp, double humidity, string distance, double moisture, string alertType)
        {
            try
            {
                const string accountSid = "AC922209e43c742e798c724e2567b0bd4d";
                const string authToken = "3df1fa2b93a389dc4591046914de5666";
                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: $"⚠️ {alertType}!\nTemp: {temp:F1} °C\nHumidity: {humidity:F1}%\nMoisture: {moisture:F1}%\nLevel: {distance}\nCheck silo conditions immediately.",
                    from: new Twilio.Types.PhoneNumber("+14197402676"),
                    to: new Twilio.Types.PhoneNumber("+265884172079")
                );

                Console.WriteLine($"SMS sent successfully. SID: {message.Sid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("SMS sending error: " + ex.Message);
            }
        }

        private void BtnUpdates_Click(object sender, EventArgs e)
        {
            Updates updates = new Updates
            {
                WindowState = FormWindowState.Maximized
            };
            updates.FormClosed += Updates_FormClosed;
            updates.Show();
            this.Hide();
        }

        private void Updates_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void labelDistance_Click(object sender, EventArgs e) { }
    }
}
