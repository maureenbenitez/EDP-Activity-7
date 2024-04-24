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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

namespace A4_Graphical_User_Interface
{
    public partial class Shelter : Form
    {
        private string loggedInUsername;
        public Shelter(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
        }

        private void ClearTextBoxes()
        {
            kind_textbox.Text = string.Empty;
            name_textbox.Text = string.Empty;
            breed_textbox.Text = string.Empty;
            age_textbox.Text = "";
            size_textbox.Text = string.Empty;
            sex_textbox.Text = string.Empty;
            coatlength_textbox.Text = string.Empty;
            color_textbox.Text = string.Empty;
            health_textbox.Text = string.Empty;
            adoption_textbox.Text = string.Empty;
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void SearchAnimalById(int animal_id)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM animal WHERE animal_id = @animal_id"; // Replace "users" with your table name
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@animal_id", animal_id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // User found, display details in textboxes
                        kind_textbox.Text = reader["animal_kind"].ToString();
                        name_textbox.Text = reader["name"].ToString();
                        breed_textbox.Text = reader["breed"].ToString();
                        age_textbox.Text = reader.GetInt32(reader.GetOrdinal("age")).ToString();
                        size_textbox.Text = reader["size"].ToString();
                        sex_textbox.Text = reader["sex"].ToString();
                        coatlength_textbox.Text = reader["coat_length"].ToString();
                        color_textbox.Text = reader["color"].ToString();
                        health_textbox.Text = reader["health_status"].ToString();
                        adoption_textbox.Text = reader["adoption_status"].ToString();
                    }
                    else
                    {
                        // User not found, clear textboxes
                        ClearTextBoxes();
                        //datagridview.DataSource = null;
                        MessageBox.Show("Animal not found.");
                        return; // Exit the method if user is not found
                    }
                }
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            int animal_id;
            if (int.TryParse(animalid_textbox.Text, out animal_id))
            {
                SearchAnimalById(animal_id);

            }
            else
            {
                MessageBox.Show("Please enter a valid animal ID.");
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(kind_textbox.Text) ||
                string.IsNullOrWhiteSpace(name_textbox.Text) ||
                string.IsNullOrWhiteSpace(breed_textbox.Text) ||
                string.IsNullOrWhiteSpace(age_textbox.Text) ||
                string.IsNullOrWhiteSpace(size_textbox.Text) ||
                string.IsNullOrWhiteSpace(sex_textbox.Text) ||
                string.IsNullOrWhiteSpace(coatlength_textbox.Text) ||
                string.IsNullOrWhiteSpace(color_textbox.Text) ||
                string.IsNullOrWhiteSpace(health_textbox.Text) ||
                string.IsNullOrWhiteSpace(adoption_textbox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO animal (animal_kind, name, breed, age, size, sex, coat_length, color, health_status, adoption_status) VALUES (@animal_kind, @name, @breed, @age, @size, @sex, @coat_length, @color, @health_status, @adoption_status)", con);


                cmd.Parameters.AddWithValue("@animal_kind", kind_textbox.Text);
                cmd.Parameters.AddWithValue("@name", name_textbox.Text);
                cmd.Parameters.AddWithValue("@breed", breed_textbox.Text);
                cmd.Parameters.AddWithValue("@age", age_textbox.Text);
                cmd.Parameters.AddWithValue("@size", size_textbox.Text);
                cmd.Parameters.AddWithValue("@sex", sex_textbox.Text);
                cmd.Parameters.AddWithValue("@coat_length", coatlength_textbox.Text);
                cmd.Parameters.AddWithValue("@color", color_textbox.Text);
                cmd.Parameters.AddWithValue("@health_status", health_textbox.Text);
                cmd.Parameters.AddWithValue("@adoption_status", adoption_textbox.Text);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("New animal added.");
            }
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE animal SET animal_kind = @animal_kind, name = @name, breed = @breed, age = @age, size = @sex, coat_length = @coat_length, color = @color, health_status = @health_status, adoption_status = @adoption_status WHERE animal_id = @animal_id", con);

                // Parse donation amount to decimal
                int age;
                if (!int.TryParse(age_textbox.Text, out age))
                {
                    MessageBox.Show("Invalid age.");
                    return;
                }

                cmd.Parameters.AddWithValue("@animal_id", animalid_textbox.Text);
                cmd.Parameters.AddWithValue("@animal_kind", kind_textbox.Text);
                cmd.Parameters.AddWithValue("@name", name_textbox.Text);
                cmd.Parameters.AddWithValue("@breed", breed_textbox.Text);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@size", size_textbox.Text);
                cmd.Parameters.AddWithValue("@sex", sex_textbox.Text);
                cmd.Parameters.AddWithValue("@coat_length", coatlength_textbox.Text);
                cmd.Parameters.AddWithValue("@color", color_textbox.Text);
                cmd.Parameters.AddWithValue("@health_status", health_textbox.Text);
                cmd.Parameters.AddWithValue("@adoption_status", adoption_textbox.Text);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Animal updated.");
            }
        }

        private void animalid_textbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
