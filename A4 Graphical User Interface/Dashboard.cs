using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A4_Graphical_User_Interface
{
    public partial class Dashboard : Form
    {
        private string loggedInUsername;
        public Dashboard(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
            this.Load += new EventHandler(Dashboard_Load);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void total_animals_label(object sender, EventArgs e)
        {
            //total_animals_label();
        }

        private (int totalAnimalsCount, int totalAdoptionsCount, int totalDogsCount, int totalCatsCount) GetTotalCountsFromDatabase()
        {
            int totalAnimalsCount = 0;
            int totalAdoptionsCount = 0;
            int totalDogsCount = 0;
            int totalCatsCount = 0;

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();

                // Retrieve total animals count
                MySqlCommand animalsCommand = new MySqlCommand("SELECT total_animals FROM total_animals", con);
                object animalsResult = animalsCommand.ExecuteScalar();

                if (animalsResult != null)
                {
                    totalAnimalsCount = Convert.ToInt32(animalsResult);
                }

                // Retrieve total adoptions count
                MySqlCommand adoptionsCommand = new MySqlCommand("SELECT total_adoptions FROM adoption_summary", con);
                object adoptionsResult = adoptionsCommand.ExecuteScalar();

                if (adoptionsResult != null)
                {
                    totalAdoptionsCount = Convert.ToInt32(adoptionsResult);
                }

                // Retrieve total dogs and cats count
                MySqlCommand totalDogsCatsCommand = new MySqlCommand("SELECT total_dogs, total_cats FROM total_dogs_and_cats", con);
                using (MySqlDataReader reader = totalDogsCatsCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Retrieve counts for dogs and cats separately
                        totalDogsCount = Convert.ToInt32(reader["total_dogs"]);
                        totalCatsCount = Convert.ToInt32(reader["total_cats"]);
                    }
                }
            }

            // Return all counts as a tuple
            return (totalAnimalsCount, totalAdoptionsCount, totalDogsCount, totalCatsCount);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adoption adoptionForm = new Adoption(loggedInUsername);
            adoptionForm.ShowDialog();
            this.Close();
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

        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee employeeForm = new Employee(loggedInUsername);
            employeeForm.ShowDialog();
            this.Close();
        }

        private void about_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            About aboutForm = new About(loggedInUsername);
            aboutForm.ShowDialog();
            this.Close();
        }

        private void animal_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Animals animalsForm = new Animals(loggedInUsername);
            animalsForm.ShowDialog();
            this.Close();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Donations donationsForm = new Donations(loggedInUsername);
            donationsForm.ShowDialog();
            this.Close();
        }

        private void dashboard_button_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Update the label with the total animals count
            total_label();
            timer1.Start();

        }

        private void total_label()
        {
            // Get counts from the database
            (int totalAnimalsCount, int totalAdoptionsCount, int totalDogsCount, int totalCatsCount) = GetTotalCountsFromDatabase();

            // Update the labels with the retrieved counts
            total_animals.Text = totalAnimalsCount.ToString();
            total_adopted.Text = totalAdoptionsCount.ToString();
            total_dogs.Text = totalDogsCount.ToString();
            total_cats.Text = totalCatsCount.ToString();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Animals animalsForm = new Animals(loggedInUsername);
            animalsForm.ShowDialog();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void date_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToShortDateString();
        }
    }
}
