using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A4_Graphical_User_Interface
{
    public partial class About : Form
    {
        private string loggedInUsername;
        public About(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void logout_button_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();

                // Update user's status to inactive
                string updateQuery = "UPDATE users SET status = 'inactive' WHERE username = @Name";
                var updateCmd = new MySqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@Name", loggedInUsername); // loggedInUsername is the username of the logged-in user
                updateCmd.ExecuteNonQuery();

                // Navigate back to the login screen
                this.Hide();
                Login loginForm = new Login();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboardForm = new Dashboard(loggedInUsername);
            dashboardForm.ShowDialog();
            this.Close();
        }

        private void about_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            About aboutForm = new About(loggedInUsername);
            aboutForm.ShowDialog();
            this.Close();
        }

        private void employee_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee employeeForm = new Employee(loggedInUsername);
            employeeForm.ShowDialog();
            this.Close();
        }

        private void animal_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Animals animalsForm = new Animals(loggedInUsername);
            animalsForm.ShowDialog();
            this.Close();
        }

        private void dashboard_button_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboardForm = new Dashboard(loggedInUsername);
            dashboardForm.ShowDialog();
            this.Close();
        }

        private void about_button_Click_1(object sender, EventArgs e)
        {
            
        }

        private void employee_button_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Employee employeeForm = new Employee(loggedInUsername);
            employeeForm.ShowDialog();
            this.Close();
        }

        private void animal_button_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Animals animalsForm = new Animals(loggedInUsername);
            animalsForm.ShowDialog();
            this.Close();
        }

        private void report_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adoption adoptionForm = new Adoption(loggedInUsername);
            adoptionForm.ShowDialog();
            this.Close();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Donations donationsForm = new Donations(loggedInUsername);
            donationsForm.ShowDialog();
            this.Close();
        }

        private void logout_button_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();

                // Update user's status to inactive
                string updateQuery = "UPDATE users SET status = 'inactive' WHERE username = @Name";
                var updateCmd = new MySqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@Name", loggedInUsername); // loggedInUsername is the username of the logged-in user
                updateCmd.ExecuteNonQuery();

                // Navigate back to the login screen
                this.Hide();
                Login loginForm = new Login();
                loginForm.ShowDialog();
                this.Close();
            }
        }
    }
}
