using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A4_Graphical_User_Interface
{
    public partial class Password_Recovery_Reset : Form
    {
        private readonly string username;
        public Password_Recovery_Reset(string username)
        {
            InitializeComponent();
            this.username = username;
            this.Load += PasswordRecoveryReset_Load;
        }

        private void PasswordRecoveryReset_Load(object sender, EventArgs e)
        {
            // Display the username in the textbox
            username_textbox.Text = username;
        }

        private void resetpassword_button_Click(object sender, EventArgs e)
        {
            string newPassword = newpassword_textbox.Text;
            string confirmedPassword = confirmpassword_textbox.Text;

            // Validate new password and confirm password
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmedPassword))
            {
                MessageBox.Show("Please enter both the new password and confirm password.");
                return;
            }

            if (newPassword != confirmedPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            // Update password in the database
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                string stm = "UPDATE users SET password = @Password WHERE username = @Username";
                var cmd = new MySqlCommand(stm, con);

                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@Username", username_textbox.Text); 

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password updated successfully.");
                    this.Hide();
                    Login loginForm = new Login();
                    loginForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update password. Please try again.");
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void newpassword_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_textbox_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
