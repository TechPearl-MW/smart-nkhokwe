using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace desktop_app.Forms
{
    public partial class Login : Form
    {
        private string connectionString = "server=localhost;user=root;password= ;database=smartsilo;";

        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM users WHERE email = @email LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", email);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPassword = reader["password_hash"].ToString();
                            string fullName = reader["full_name"].ToString();

                            if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                            {
                                MessageBox.Show($"Welcome, {fullName}!");

                                Dashboard dashboard = new Dashboard();
                                dashboard.Show();
                                Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect password.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No account found with that email.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
        }

        private void LinkSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Authentication.PanelRegister.Controls.Clear();

            Register register = new Register()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };

            Authentication.PanelRegister.Controls.Add(register);
            register.Show();

            Hide();
        }
    }
}
