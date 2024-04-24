using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace A4_Graphical_User_Interface
{
    public partial class SecurityQuestion : Form
    {
        public SecurityQuestion()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();
            this.Close();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string username = username_textbox.Text;
            string birthdate = birthdate_datetimepicker.Value.ToString("yyyy-MM-dd");
            string firstPetName = firstpetname_textbox.Text;

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                string stm = "SELECT user_id FROM users WHERE username = @Username AND birthdate = @Birthdate AND firstpetname = @FirstPetName";
                var cmd = new MySqlCommand(stm, con);

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Birthdate", birthdate);
                cmd.Parameters.AddWithValue("@FirstPetName", firstPetName);

                con.Open();
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        // Security answers match, navigate to the password recovery form
                        this.Hide();
                        Password_Recovery_Reset frm = new Password_Recovery_Reset(username); // Pass username to the constructor
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // Security answers incorrect
                        Console.WriteLine("Security answers incorrect. Please try again");
                        MessageBox.Show("Security answers incorrect. Please try again.");
                    }
                }
            }
        }

        private void SecurityQuestion_Load(object sender, EventArgs e)
        {

        }
    }
}
