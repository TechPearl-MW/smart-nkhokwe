using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace desktop_app.Forms
{
    public partial class Register : Form
    {
        private string connectionString = "server=localhost;user=root;password= ;database=smartsilo;";

        public Register()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (fullName == "" || email == "" || password == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Hash password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO users (full_name, email, password_hash) VALUES (@name, @email, @password)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@name", fullName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registration successful!");

                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    Hide();
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                        MessageBox.Show("Email already registered.");
                    else
                        MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LinkSignin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Authentication.PanelLogin.Controls.Clear();

            Login login = new Login()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };

            Authentication.PanelLogin.Controls.Add(login);
            login.Show();
            Hide();
        }
    }
}
