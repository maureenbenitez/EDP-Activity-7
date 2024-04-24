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
    public partial class Employee : Form
    {
        private string loggedInUsername;
        public Employee(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void add_button_Click(object sender, EventArgs e)
        {
            DisplayData();

            // Validate input fields
            if (string.IsNullOrWhiteSpace(firstname_textbox.Text) ||
                string.IsNullOrWhiteSpace(lastname_textbox.Text) ||
                string.IsNullOrWhiteSpace(email_textbox.Text) ||
                string.IsNullOrWhiteSpace(phonenumber_textbox.Text) ||
                string.IsNullOrWhiteSpace(role_textbox.Text) ||
                string.IsNullOrWhiteSpace(username_textbox.Text) ||
                string.IsNullOrWhiteSpace(password_textbox.Text) ||
                string.IsNullOrWhiteSpace(firstpetname_textbox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO users (first_name, last_name, email, phone_number, roles, username, password, Birthdate, FirstPetName) VALUES (@first_name, @last_name, @email, @phone_number, @roles, @username, @password, @Birthdate, @FirstPetName)", con);


                cmd.Parameters.AddWithValue("@first_name", firstname_textbox.Text);
                cmd.Parameters.AddWithValue("@last_name", lastname_textbox.Text);
                cmd.Parameters.AddWithValue("@email", email_textbox.Text);
                cmd.Parameters.AddWithValue("@phone_number", phonenumber_textbox.Text);
                cmd.Parameters.AddWithValue("@roles", role_textbox.Text);

                cmd.Parameters.AddWithValue("@username", username_textbox.Text);
                cmd.Parameters.AddWithValue("@password", password_textbox.Text);

                cmd.Parameters.AddWithValue("@Birthdate", birthday_datetimepicker.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@FirstPetName", firstpetname_textbox.Text);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("New account added.");
            }
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            DisplayData();

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE users SET first_name = @first_name, last_name = @last_name, email = @email, phone_number = @phone_number, roles = @roles, username = @username, password = @password, Birthdate = @Birthdate, FirstPetName = @FirstPetName WHERE user_id = @user_id", con);


                //MySqlCommand cmd = new MySqlCommand("UPDATE users SET first_name = @first_name, last_name = @last_name, email = @email, phone_number = @phone_number, roles = @roles, username = @username, password = @password, Birthdate = @Birthdate, FirstPetName = @FirstPetName", con);

                cmd.Parameters.AddWithValue("@user_id", userid_textbox.Text);
                cmd.Parameters.AddWithValue("@first_name", firstname_textbox.Text);
                cmd.Parameters.AddWithValue("@last_name", lastname_textbox.Text);
                cmd.Parameters.AddWithValue("@email", email_textbox.Text);
                cmd.Parameters.AddWithValue("@phone_number", phonenumber_textbox.Text);
                cmd.Parameters.AddWithValue("@roles", role_textbox.Text);
                cmd.Parameters.AddWithValue("@username", username_textbox.Text);
                cmd.Parameters.AddWithValue("@password", password_textbox.Text);
                cmd.Parameters.AddWithValue("@Birthdate", birthday_datetimepicker.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@FirstPetName", firstpetname_textbox.Text);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Account updated.");
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            int userId;
            if (int.TryParse(userid_textbox.Text, out userId))
            {
                SearchUserById(userId);
                
            }
            else
            {
                MessageBox.Show("Please enter a valid user ID.");
            }
            
        }

        private void SearchUserById(int userId)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM users WHERE user_id = @userId"; // Replace "users" with your table name
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // User found, display details in textboxes
                        firstname_textbox.Text = reader["first_name"].ToString();
                        lastname_textbox.Text = reader["last_name"].ToString();
                        email_textbox.Text = reader["email"].ToString();
                        phonenumber_textbox.Text = reader["phone_number"].ToString();
                        role_textbox.Text = reader["roles"].ToString();
                        username_textbox.Text = reader["username"].ToString();
                        password_textbox.Text = reader["password"].ToString();
                        birthday_datetimepicker.Value = Convert.ToDateTime(reader["Birthdate"]);
                        firstpetname_textbox.Text = reader["FirstPetName"].ToString();
                    }
                    else
                    {
                        // User not found, clear textboxes
                        ClearTextBoxes();
                        datagridview.DataSource = null;
                        MessageBox.Show("User not found.");
                        return; // Exit the method if user is not found
                    }
                }

                // Execute a separate query to fetch specific columns for DataGridView
                string userDataQuery = "SELECT first_name AS 'First Name', last_name AS 'Last Name', email AS 'Email', phone_number AS 'Phone Number', roles AS 'Roles' FROM users WHERE user_id = @userId";
                MySqlCommand userDataCmd = new MySqlCommand(userDataQuery, con);
                userDataCmd.Parameters.AddWithValue("@userId", userId);

                using (MySqlDataReader userDataReader = userDataCmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(userDataReader);
                    datagridview.DataSource = dt;

                    // Calculate maximum width for each column
                    int totalWidth = datagridview.ClientSize.Width;
                    int columnCount = datagridview.Columns.Count;
                    int maxColumnWidth = totalWidth / columnCount;

                    // Set maximum width for each column
                    foreach (DataGridViewColumn column in datagridview.Columns)
                    {
                        column.Width = maxColumnWidth;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    }
                }
            }
        }

        private void ClearTextBoxes()
        {
            firstname_textbox.Text = string.Empty;
            lastname_textbox.Text = string.Empty;
            email_textbox.Text = string.Empty;
            phonenumber_textbox.Text = string.Empty;
            role_textbox.Text = string.Empty;
            username_textbox.Text = string.Empty;
            password_textbox.Text = string.Empty;
            birthday_datetimepicker.Value = DateTime.Today;
            firstpetname_textbox.Text = string.Empty;
        }

        private void DisplayData()
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT user_id AS 'User ID', first_name AS 'First Name', last_name AS 'Last Name', email AS 'Email Address', phone_number AS 'Phone Number', roles AS 'Roles', status AS 'STATUS' FROM users";
                MySqlCommand cmd = new MySqlCommand(query, con);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Reorder the columns
                        dt.Columns["First Name"].SetOrdinal(1);
                        dt.Columns["Last Name"].SetOrdinal(2);
                        dt.Columns["Email Address"].SetOrdinal(3);
                        dt.Columns["Phone Number"].SetOrdinal(4);
                        dt.Columns["Roles"].SetOrdinal(5);

                        datagridview.DataSource = dt;

                        // Calculate maximum width for each column
                        int totalWidth = datagridview.ClientSize.Width;
                        int columnCount = datagridview.Columns.Count;
                        int maxColumnWidth = totalWidth / columnCount;

                        // Set maximum width for each column
                        foreach (DataGridViewColumn column in datagridview.Columns)
                        {
                            column.Width = maxColumnWidth;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        }
                    }
                }
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            DisplayData();

        }

        private void DisplayAllUsers()
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM users"; // Replace "users" with your table name
                MySqlCommand cmd = new MySqlCommand(query, con);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        datagridview.DataSource = dt;
                    }
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DisplayAllUsers();
            DisplayData();
        }

        private void iconButton5_Click(object sender, EventArgs e)
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

        }

        private void about_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            About aboutForm = new About(loggedInUsername);
            aboutForm.ShowDialog();
            this.Close();
        }

        private void dashboard_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboardForm = new Dashboard(loggedInUsername);
            dashboardForm.ShowDialog();
            this.Close();
        }

        private void datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Animals animalsForm = new Animals(loggedInUsername);
            animalsForm.ShowDialog();
            this.Close();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adoption adoptionForm = new Adoption(loggedInUsername);
            adoptionForm.ShowDialog();
            this.Close();
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Donations donationsForm = new Donations(loggedInUsername);
            donationsForm.ShowDialog();
            this.Close();
        }
    }
}
