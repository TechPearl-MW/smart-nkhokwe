using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace desktop_app.Forms
{
    public partial class Monitoring : Form
    {
        private string connectionString = "server=localhost;user=root;password=;database=smartsilo;";
        private System.Windows.Forms.Timer refreshTimer;
        private Chart chartTemperature;
        private Chart chartHumidity;
        private Chart chartMoisture;
        private DataGridView dataGridViewReadings;
        private Panel statusPanel;
        private Label statusLabel;
        private Label tempStatusLabel;
        private Label humidityStatusLabel;
        private Label moistureStatusLabel;
        private Label spoilageRiskLabel;
        private NotifyIcon notifyIcon;

        public Monitoring()
        {
            InitializeCustomComponents();
            SetupRefreshTimer();
            LoadData();
        }

        private void InitializeCustomComponents()
        {
            // Form setup
            this.Text = "Smart Silo Monitoring Dashboard - Live Monitoring";
            this.Size = new Size(1200, 800);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            // Header
            var headerLabel = new Label();
            headerLabel.Text = "SILO MONITORING DASHBOARD";
            headerLabel.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            headerLabel.ForeColor = Color.FromArgb(0, 123, 255);
            headerLabel.Size = new Size(400, 35);
            headerLabel.Location = new Point(20, 15);
            this.Controls.Add(headerLabel);

            InitializeStatusPanel();
            InitializeCharts();
            InitializeDataGridView();
            InitializeNotifyIcon();
        }

        private void InitializeStatusPanel()
        {
            statusPanel = new Panel();
            statusPanel.Location = new Point(20, 60);
            statusPanel.Size = new Size(1150, 80);
            statusPanel.BackColor = Color.FromArgb(248, 249, 250);
            statusPanel.BorderStyle = BorderStyle.FixedSingle;

            // Status labels
            statusLabel = new Label();
            statusLabel.Text = "SYSTEM STATUS: MONITORING...";
            statusLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            statusLabel.ForeColor = Color.FromArgb(40, 167, 69);
            statusLabel.Location = new Point(10, 10);
            statusLabel.Size = new Size(300, 25);
            statusPanel.Controls.Add(statusLabel);

            tempStatusLabel = CreateStatusLabel(320, 10, "🌡 TEMP: --°C", Color.Black);
            humidityStatusLabel = CreateStatusLabel(500, 10, "💧 HUMIDITY: --%", Color.Black);
            moistureStatusLabel = CreateStatusLabel(680, 10, "💦 MOISTURE: --%", Color.Black);

            spoilageRiskLabel = new Label();
            spoilageRiskLabel.Text = "SPOILAGE RISK: CALCULATING...";
            spoilageRiskLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            spoilageRiskLabel.Location = new Point(10, 45);
            spoilageRiskLabel.Size = new Size(400, 25);
            statusPanel.Controls.Add(spoilageRiskLabel);

            this.Controls.Add(statusPanel);
        }

        private Label CreateStatusLabel(int x, int y, string text, Color color)
        {
            var label = new Label();
            label.Text = text;
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.ForeColor = color;
            label.Location = new Point(x, y);
            label.Size = new Size(170, 25);
            statusPanel.Controls.Add(label);
            return label;
        }

        private void InitializeCharts()
        {
            int chartWidth = 370;
            int chartHeight = 250;

            // Temperature Chart
            chartTemperature = CreateChart("TEMPERATURE TREND", "Time", "Temperature (°C)",
                Color.Red, new Point(20, 160), chartWidth, chartHeight);

            // Humidity Chart
            chartHumidity = CreateChart("HUMIDITY TREND", "Time", "Humidity (%)",
                Color.Blue, new Point(400, 160), chartWidth, chartHeight);

            // Moisture Chart
            chartMoisture = CreateChart("MOISTURE TREND", "Time", "Moisture (%)",
                Color.Green, new Point(780, 160), chartWidth, chartHeight);
        }

        private Chart CreateChart(string title, string xTitle, string yTitle, Color color, Point location, int width, int height)
        {
            var chart = new Chart();
            chart.Location = location;
            chart.Size = new Size(width, height);
            chart.BorderlineColor = Color.LightGray;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth = 1;

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = xTitle;
            chartArea.AxisY.Title = yTitle;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.BackColor = Color.White;
            chart.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.Color = color;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 6;
            series.MarkerColor = color;
            chart.Series.Add(series);

            Title chartTitle = new Title();
            chartTitle.Text = title;
            chartTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            chartTitle.ForeColor = Color.FromArgb(52, 58, 64);
            chart.Titles.Add(chartTitle);

            this.Controls.Add(chart);
            return chart;
        }

        private void InitializeDataGridView()
        {
            dataGridViewReadings = new DataGridView();
            dataGridViewReadings.Location = new Point(20, 430);
            dataGridViewReadings.Size = new Size(1150, 300);
            dataGridViewReadings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReadings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReadings.ReadOnly = true;
            dataGridViewReadings.Font = new Font("Segoe UI", 9);
            dataGridViewReadings.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewReadings.RowHeadersVisible = false;

            // Add "Live Data" label above grid
            var gridLabel = new Label();
            gridLabel.Text = "LIVE SENSOR READINGS";
            gridLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            gridLabel.ForeColor = Color.FromArgb(52, 58, 64);
            gridLabel.Location = new Point(20, 405);
            gridLabel.Size = new Size(250, 25);
            this.Controls.Add(gridLabel);

            this.Controls.Add(dataGridViewReadings);
        }

        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.Icon = SystemIcons.Warning;
            notifyIcon.BalloonTipTitle = "Silo Monitoring Alert";
        }

        private void SetupRefreshTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 3000; // 3 seconds
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT temperature, humidity, moisture, distance, alert, timestamp " +
                                   "FROM sensor_readings " +
                                   "ORDER BY timestamp DESC " +
                                   "LIMIT 15";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    UpdateCharts(dt);
                    UpdateDataGridView(dt);
                    AnalyzeConditions(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database error: " + ex.Message);
                    statusLabel.Text = "SYSTEM STATUS: DATABASE ERROR";
                    statusLabel.ForeColor = Color.Red;
                }
            }
        }

        private void UpdateCharts(DataTable dt)
        {
            chartTemperature.Series[0].Points.Clear();
            chartHumidity.Series[0].Points.Clear();
            chartMoisture.Series[0].Points.Clear();

            if (dt.Rows.Count == 0) return;

            var orderedData = dt.AsEnumerable().OrderBy(row => row.Field<DateTime>("timestamp"));

            foreach (DataRow row in orderedData)
            {
                string timeLabel = row.Field<DateTime>("timestamp").ToString("HH:mm:ss");
                double temp = Convert.ToDouble(row["temperature"]);
                double humidity = Convert.ToDouble(row["humidity"]);
                double moisture = Convert.ToDouble(row["moisture"]);
                string alert = row["alert"].ToString();

                int tempIndex = chartTemperature.Series[0].Points.AddXY(timeLabel, temp);
                int humidityIndex = chartHumidity.Series[0].Points.AddXY(timeLabel, humidity);
                int moistureIndex = chartMoisture.Series[0].Points.AddXY(timeLabel, moisture);

                if (alert == "ALERT")
                {
                    chartTemperature.Series[0].Points[tempIndex].Color = Color.Red;
                    chartHumidity.Series[0].Points[humidityIndex].Color = Color.Red;
                    chartMoisture.Series[0].Points[moistureIndex].Color = Color.Red;
                }
            }
        }

        private void UpdateDataGridView(DataTable dt)
        {
            dataGridViewReadings.DataSource = dt;

            foreach (DataGridViewRow row in dataGridViewReadings.Rows)
            {
                if (row.Cells["alert"].Value?.ToString() == "ALERT")
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }

        private void AnalyzeConditions(DataTable dt)
        {
            if (dt.Rows.Count == 0) return;

            DataRow latest = dt.Rows[0];
            double temp = Convert.ToDouble(latest["temperature"]);
            double humidity = Convert.ToDouble(latest["humidity"]);
            double moisture = Convert.ToDouble(latest["moisture"]);

            tempStatusLabel.Text = $"🌡 TEMP: {temp}°C";
            humidityStatusLabel.Text = $"💧 HUMIDITY: {humidity}%";
            moistureStatusLabel.Text = $"💦 MOISTURE: {moisture}%";

            tempStatusLabel.ForeColor = temp > 35 ? Color.Red : temp > 30 ? Color.Orange : Color.Green;
            humidityStatusLabel.ForeColor = humidity > 70 ? Color.Red : humidity > 60 ? Color.Orange : Color.Green;
            moistureStatusLabel.ForeColor = moisture > 15 ? Color.Red : moisture > 12 ? Color.Orange : Color.Green;

            CalculateSpoilageRisk(temp, humidity, moisture);
            CheckForAlerts(temp, humidity, moisture);
        }

        private void CalculateSpoilageRisk(double temp, double humidity, double moisture)
        {
            int riskScore = 0;
            string riskLevel = "LOW";
            Color riskColor = Color.Green;
            string feedback = "";

            if (temp > 35) riskScore += 3;
            else if (temp > 30) riskScore += 2;
            else if (temp > 25) riskScore += 1;

            if (humidity > 75) riskScore += 3;
            else if (humidity > 65) riskScore += 2;
            else if (humidity > 55) riskScore += 1;

            if (moisture > 16) riskScore += 3;
            else if (moisture > 14) riskScore += 2;
            else if (moisture > 12) riskScore += 1;

            if (riskScore >= 6)
            {
                riskLevel = "HIGH";
                riskColor = Color.Red;
                feedback = "⚠️ CRITICAL: Immediate action required!";
            }
            else if (riskScore >= 3)
            {
                riskLevel = "MEDIUM";
                riskColor = Color.Orange;
                feedback = "⚠️ WARNING: Monitor conditions closely.";
            }
            else
            {
                riskLevel = "LOW";
                riskColor = Color.Green;
                feedback = "✅ OPTIMAL: Conditions are good.";
            }

            spoilageRiskLabel.Text = $"SPOILAGE RISK: {riskLevel}";
            spoilageRiskLabel.ForeColor = riskColor;

            statusLabel.Text = $"SYSTEM STATUS: {riskLevel} RISK";
            statusLabel.ForeColor = riskColor;
        }

        private void CheckForAlerts(double temp, double humidity, double moisture)
        {
            bool showAlert = false;
            string alertTitle = "";
            string alertMessage = "";

            if (temp > 35)
            {
                showAlert = true;
                alertTitle = "HIGH TEMPERATURE ALERT!";
                alertMessage = $"Critical {temp}°C! Spoilage risk high.";
            }

            if (humidity > 75)
            {
                showAlert = true;
                alertTitle = "HIGH HUMIDITY ALERT!";
                alertMessage = $"Critical {humidity}%! Mold growth risk.";
            }

            if (moisture > 16)
            {
                showAlert = true;
                alertTitle = "HIGH MOISTURE ALERT!";
                alertMessage = $"Critical {moisture}%! Dry grains needed.";
            }

            if (showAlert)
            {
                notifyIcon.BalloonTipTitle = alertTitle;
                notifyIcon.BalloonTipText = alertMessage;
                notifyIcon.ShowBalloonTip(5000);

                statusLabel.Text = $"ALERT: {alertTitle.Replace("!", "")}";
                statusLabel.ForeColor = Color.Red;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }

            if (notifyIcon != null)
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
            }
        }
    }
}
