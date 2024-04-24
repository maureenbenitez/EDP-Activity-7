using Google.Protobuf.WellKnownTypes;
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
    public partial class New_Adoption : Form
    {
        private string loggedInUsername;
        public New_Adoption(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
        }

        private void ClearTextBoxes()
        {
            name_textbox.Text = string.Empty;
            number_textbox.Text = string.Empty;
            address_textbox.Text = string.Empty;
            animal_textbox.Text = "";
            adopter_textbox.Text = "";
            date_datetimepicker.Value = DateTime.Today;
            fee_textbox.Text = "";
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(name_textbox.Text) ||
                string.IsNullOrWhiteSpace(number_textbox.Text) ||
                string.IsNullOrWhiteSpace(address_textbox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO adopter (adopter_name, phone_number, address) VALUES (@adopter_name, @phone_number, @address)", con);
                
                cmd.Parameters.AddWithValue("@adopter_name", name_textbox.Text);
                cmd.Parameters.AddWithValue("@phone_number", number_textbox.Text);
                cmd.Parameters.AddWithValue("@address", address_textbox.Text);
      
                cmd.ExecuteNonQuery();
                
                con.Close();

                MessageBox.Show("New adopter added.");
            }
        }

        private void add1_button_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(animal_textbox.Text) ||
                string.IsNullOrWhiteSpace(adopter_textbox.Text) ||
                string.IsNullOrWhiteSpace(date_datetimepicker.Text) ||
                string.IsNullOrWhiteSpace(fee_textbox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO adoption (animal_id, adopter_id, adoption_date, adoption_fee) VALUES (@animal_id, @adopter_id, @adoption_date, @adoption_fee)", con);

                cmd.Parameters.AddWithValue("@animal_id", animal_textbox.Text);
                cmd.Parameters.AddWithValue("@adopter_id", adopter_textbox.Text);
                cmd.Parameters.AddWithValue("@adoption_date", date_datetimepicker.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@adoption_fee", fee_textbox.Text);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("New adoption added.");
            }
        }

        private void SearchAdopterById(int adopter_id)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM adopter WHERE adopter_id = @adopter_id"; // Replace "users" with your table name
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@adopter_id", adopter_id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // User found, display details in textboxes
                        name_textbox.Text = reader["adopter_name"].ToString();
                        number_textbox.Text = reader["phone_number"].ToString();
                        address_textbox.Text = reader["address"].ToString();

                    }
                    else
                    {
                        // User not found, clear textboxes
                        ClearTextBoxes();
                        //datagridview.DataSource = null;
                        MessageBox.Show("Adopter not found.");
                        return; // Exit the method if user is not found
                    }
                }
            }
        }

        private void SearchAdoptionById(int adoption_id)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM adoption WHERE adoption_id = @adoption_id"; // Replace "users" with your table name
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@adoption_id", adoption_id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // User found, display details in textboxes

                        animal_textbox.Text = reader.GetInt32(reader.GetOrdinal("animal_id")).ToString();
                        adopter_textbox.Text = reader.GetInt32(reader.GetOrdinal("adopter_id")).ToString();
                        date_datetimepicker.Value = Convert.ToDateTime(reader["adoption_date"]);
                        fee_textbox.Text = reader.GetDecimal(reader.GetOrdinal("adoption_fee")).ToString();
                    }
                    else
                    {
                        // User not found, clear textboxes
                        ClearTextBoxes();
                        //datagridview.DataSource = null;
                        MessageBox.Show("Adoption not found.");
                        return; // Exit the method if user is not found
                    }
                }
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            int adopter_id;
            if (int.TryParse(adopterid_textbox.Text, out adopter_id))
            {
                SearchAdopterById(adopter_id);

            }
            else
            {
                MessageBox.Show("Please enter a valid adopter ID.");
            }
        }

        private void search1_button_Click(object sender, EventArgs e)
        {
            int adoption_id;
            if (int.TryParse(adoptionid_textbox.Text, out adoption_id))
            {
                SearchAdoptionById(adoption_id);
            }
            else
            {
                MessageBox.Show("Please enter a valid adoption ID.");
            }
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE adopter SET adopter_name = @adopter_name, phone_number = @phone_number, address = @address WHERE adopter_id = @adopter_id", con);

                cmd.Parameters.AddWithValue("@adopter_id", adopterid_textbox.Text);
                cmd.Parameters.AddWithValue("@adopter_name", name_textbox.Text);
                cmd.Parameters.AddWithValue("@phone_number", number_textbox.Text);
                cmd.Parameters.AddWithValue("@address", address_textbox.Text);


                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Adopter updated.");
            }
        }

        private void update1_button_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE adoption SET animal_id = @animal_id, adopter_id = @adopter_id, adoption_date = @adoption_date, adoption_fee = @adoption_fee WHERE adoption_id = @adoption_id", con);

                decimal adoptionFee;
                if (!decimal.TryParse(fee_textbox.Text, out adoptionFee))
                {
                    MessageBox.Show("Invalid adoption fee.");
                    return;
                }

                int animalId, adopterId;
                if (!int.TryParse(animal_textbox.Text, out animalId) || !int.TryParse(adopter_textbox.Text, out adopterId))
                {
                    MessageBox.Show("Invalid animal ID or adopter ID.");
                    return;
                }

                cmd.Parameters.AddWithValue("@adoption_id", adoptionid_textbox.Text);
                cmd.Parameters.AddWithValue("@animal_id", animalId);
                cmd.Parameters.AddWithValue("@adopter_id", adopterId);
                cmd.Parameters.AddWithValue("@adoption_date", date_datetimepicker.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@adoption_fee", adoptionFee);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Adoption updated.");
            }
        }

    }
}
