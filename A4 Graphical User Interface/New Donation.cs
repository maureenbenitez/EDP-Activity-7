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
    public partial class New_Donation : Form
    {
        private string loggedInUsername;
        public New_Donation(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void add_button_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(donorname_textbox.Text) ||
                string.IsNullOrWhiteSpace(donorcontact_textbox.Text) ||
                string.IsNullOrWhiteSpace(donationdate_datetimepicker.Text) ||
                string.IsNullOrWhiteSpace(donationtype_textbox.Text) ||
                string.IsNullOrWhiteSpace(donationamount_textbox.Text) ||
                string.IsNullOrWhiteSpace(donationmethod_textbox.Text) ||
                string.IsNullOrWhiteSpace(purpose_textbox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO donation (donor_name, donor_contact, donation_date, donation_type, donation_amount, donation_method, purpose) VALUES (@donor_name, @donor_contact, @donation_date, @donation_type, @donation_amount, @donation_method, @purpose)", con);


                cmd.Parameters.AddWithValue("@donor_name", donorname_textbox.Text);
                cmd.Parameters.AddWithValue("@donor_contact", donorcontact_textbox.Text);
                cmd.Parameters.AddWithValue("@donation_date", donationdate_datetimepicker.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@donation_type", donationtype_textbox.Text);
                cmd.Parameters.AddWithValue("@donation_amount", donationamount_textbox.Text);
                cmd.Parameters.AddWithValue("@donation_method", donationmethod_textbox.Text);
                cmd.Parameters.AddWithValue("@purpose", purpose_textbox.Text);
                              
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("New donation added.");
            }
        }

        private void ClearTextBoxes()
        {
            donorname_textbox.Text = string.Empty;
            donorcontact_textbox.Text = string.Empty;
            donationdate_datetimepicker.Value = DateTime.Today;
            donationtype_textbox.Text = string.Empty;
            donationamount_textbox.Text = "";
            donationmethod_textbox.Text = string.Empty;
            purpose_textbox.Text = string.Empty;
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void SearchDonationById(int donation_id)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM donation WHERE donation_id = @donation_id"; // Replace "users" with your table name
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@donation_id", donation_id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // User found, display details in textboxes
                        donorname_textbox.Text = reader["donor_name"].ToString();
                        donorcontact_textbox.Text = reader["donor_contact"].ToString();
                        donationdate_datetimepicker.Value = Convert.ToDateTime(reader["donation_date"]);
                        donationtype_textbox.Text = reader["donation_type"].ToString();
                        donationamount_textbox.Text = reader.GetDecimal(reader.GetOrdinal("donation_amount")).ToString();
                        donationmethod_textbox.Text = reader["donation_method"].ToString();
                        purpose_textbox.Text = reader["purpose"].ToString();
                    }
                    else
                    {
                        // User not found, clear textboxes
                        ClearTextBoxes();
                        //datagridview.DataSource = null;
                        MessageBox.Show("Data not found.");
                        return; // Exit the method if user is not found
                    }
                }
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            int donation_id;
            if (int.TryParse(donationid_textbox.Text, out donation_id))
            {
                SearchDonationById(donation_id);

            }
            else
            {
                MessageBox.Show("Please enter a valid donation ID.");
            }
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE donation SET donor_name = @donor_name, donor_contact = @donor_contact, donation_date = @donation_date, donation_type = @donation_type, donation_amount = @donation_amount, donation_method = @donation_method, purpose = @purpose WHERE donation_id = @donation_id", con);

                // Parse donation amount to decimal
                decimal donationAmount;
                if (!decimal.TryParse(donationamount_textbox.Text, out donationAmount))
                {
                    MessageBox.Show("Invalid donation amount.");
                    return;
                }

                cmd.Parameters.AddWithValue("@donation_id", donationid_textbox.Text);
                cmd.Parameters.AddWithValue("@donor_name", donorname_textbox.Text);
                cmd.Parameters.AddWithValue("@donor_contact", donorcontact_textbox.Text);
                cmd.Parameters.AddWithValue("@donation_date", donationdate_datetimepicker.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@donation_type", donationtype_textbox.Text);
                cmd.Parameters.AddWithValue("@donation_amount", donationAmount);
                cmd.Parameters.AddWithValue("@donation_method", donationmethod_textbox.Text);
                cmd.Parameters.AddWithValue("@purpose", purpose_textbox.Text);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Donation updated.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
