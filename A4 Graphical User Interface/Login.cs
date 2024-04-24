using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace A4_Graphical_User_Interface
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SecurityQuestion securityQuestion = new SecurityQuestion();
            securityQuestion.ShowDialog();
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string selectQuery = "SELECT user_id FROM users WHERE username = @Name AND password = @Password AND status = 'inactive'";
                var selectCmd = new MySqlCommand(selectQuery, con);

                selectCmd.Parameters.AddWithValue("@Name", username_textbox.Text);
                selectCmd.Parameters.AddWithValue("@Password", password_textbox.Text);

                using (MySqlDataReader rdr = selectCmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        int userId = rdr.GetInt32("user_id");
                        rdr.Close();

                        // Update user's status to active
                        string updateQuery = "UPDATE users SET status = 'active' WHERE user_id = @UserId";
                        var updateCmd = new MySqlCommand(updateQuery, con);
                        updateCmd.Parameters.AddWithValue("@UserId", userId);
                        updateCmd.ExecuteNonQuery();

                        // Store the logged-in username
                        string loggedInUsername = username_textbox.Text;

                        // Successful login, navigate to the dashboard
                        this.Hide();
                        Dashboard frm = new Dashboard(loggedInUsername); // Pass the logged-in username to the dashboard form
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // Username or password incorrect
                        MessageBox.Show("Username or password is incorrect or user is already logged in!");
                    }
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
