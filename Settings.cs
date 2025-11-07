using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;

namespace desktop_app.Forms
{
    public partial class Settings : Form
    {
        private string connectionString = "server=localhost;user=root;password=;database=smartsilo;";

        public Settings()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Settings - Reports";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Button to export sensor readings
            Button btnExportSensor = new Button
            {
                Text = "Download Sensor Readings Report (Excel)",
                Size = new Size(350, 50),
                Location = new Point((this.Width - 350) / 2, 200)
            };
            btnExportSensor.Click += BtnExportSensor_Click;
            this.Controls.Add(btnExportSensor);
        }

        private void BtnExportSensor_Click(object sender, EventArgs e)
        {
            // Query updated to match the correct database table structure
            string query = "SELECT id, temperature, humidity, moisture, distance AS GrainLevel, alert AS AlertStatus, timestamp " +
                           "FROM sensor_readings " +
                           "ORDER BY timestamp DESC";

            ExportReport(query, "SensorReadingsReport");
        }

        private void ExportReport(string query, string fileNameDefault)
        {
            try
            {
                DataTable dt = GetDataTable(query);

                if (dt.Rows.Count > 0)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files (*.xlsx)|*.xlsx",
                        FileName = $"{fileNameDefault}.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Report");
                            wb.SaveAs(saveFileDialog.FileName);
                        }
                        MessageBox.Show("Report saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No data available to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
