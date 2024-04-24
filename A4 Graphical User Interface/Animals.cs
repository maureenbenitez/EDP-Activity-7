using Microsoft.Office.Core;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Google.Protobuf.WellKnownTypes;
using PBType = Google.Protobuf.WellKnownTypes.Type;

namespace A4_Graphical_User_Interface
{
    public partial class Animals : Form
    {
        private string loggedInUsername;
        public Animals(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
            this.Load += Animal_Load;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Animal_Load(object sender, EventArgs e)
        {
            DisplayAnimalData();
        }

        private void DisplayAnimalData()
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT animal_id AS 'Animal ID', animal_kind AS 'Animal Kind', name AS 'Name', breed AS 'Breed', age AS 'Age', size AS 'Size', sex AS 'Sex', coat_length AS 'Coat Length', color AS 'Color', health_status AS 'Health Status', adoption_status AS 'Adoption Status' FROM animal";
                MySqlCommand cmd = new MySqlCommand(query, con);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        dt.Columns["Animal ID"].SetOrdinal(0);
                        dt.Columns["Animal Kind"].SetOrdinal(1);
                        dt.Columns["Name"].SetOrdinal(2);
                        dt.Columns["Breed"].SetOrdinal(3);
                        dt.Columns["Age"].SetOrdinal(4);
                        dt.Columns["Size"].SetOrdinal(5);
                        dt.Columns["Sex"].SetOrdinal(6);
                        dt.Columns["Coat Length"].SetOrdinal(7);
                        dt.Columns["Color"].SetOrdinal(8);
                        dt.Columns["Health Status"].SetOrdinal(9);
                        dt.Columns["Adoption Status"].SetOrdinal(10);

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

        private void dashboard_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboardForm = new Dashboard(loggedInUsername);
            dashboardForm.ShowDialog();
            this.Close();
        }

        private void PopulateAnimalData(Excel._Worksheet oSheet)
        {
            int startRow = 15; // Start from row 15
            int currentRow = startRow;

            // Establish MySQL connection
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();

                // Example: Fetching data from the total_animals view
                string animalQuery = "SELECT * FROM total_animals;";
                using (MySqlCommand animalCmd = new MySqlCommand(animalQuery, con))
                {
                    using (MySqlDataReader animalReader = animalCmd.ExecuteReader())
                    {
                        // Check if the reader has rows
                        if (animalReader.HasRows)
                        {
                            // Iterate through each row in the result set
                            while (animalReader.Read())
                            {
                                // Example: Assuming there are three columns in the view
                                // Displaying data in columns 1 and 2 in Excel starting from row 15
                                for (int i = 0; i < animalReader.FieldCount; i++)
                                {
                                    oSheet.Cells[currentRow, i + 1] = animalReader.GetValue(i);
                                }

                                currentRow++; // Move to the next row in Excel
                            }
                        }
                    }
                }

                // Fetch data from age_distribution view
                string ageQuery = "SELECT AgeGroup, count FROM age_distribution;";
                using (MySqlCommand ageCmd = new MySqlCommand(ageQuery, con))
                {
                    using (MySqlDataReader ageReader = ageCmd.ExecuteReader())
                    {
                        // Reset currentRow to startRow
                        currentRow = startRow;

                        // Check if the reader has rows
                        if (ageReader.HasRows)
                        {
                            // Iterate through each row in the result set
                            while (ageReader.Read())
                            {
                                // Displaying data from age_distribution in columns 3 and 4
                                oSheet.Cells[currentRow, 3] = ageReader.GetString(0); // AgeGroup
                                oSheet.Cells[currentRow, 4] = ageReader.GetInt32(1); // count
                                currentRow++; // Move to the next row in Excel
                            }
                        }
                    }
                }

                // Fetch data from gender_distribution view
                string genderQuery = "SELECT Gender, Count FROM gender_distribution;";
                using (MySqlCommand genderCmd = new MySqlCommand(genderQuery, con))
                {
                    using (MySqlDataReader genderReader = genderCmd.ExecuteReader())
                    {
                        // Reset currentRow to startRow
                        currentRow = startRow;

                        // Check if the reader has rows
                        if (genderReader.HasRows)
                        {
                            // Iterate through each row in the result set
                            while (genderReader.Read())
                            {
                                // Displaying data from age_distribution in columns 3 and 4
                                oSheet.Cells[currentRow, 5] = genderReader.GetString(0); // AgeGroup
                                oSheet.Cells[currentRow, 6] = genderReader.GetInt32(1); // count
                                currentRow++; // Move to the next row in Excel
                            }
                        }
                    }
                }

                // Fetch data from health_status view
                string healthQuery = "SELECT health_status, Count FROM health_status;";
                using (MySqlCommand healthCmd = new MySqlCommand(healthQuery, con))
                {
                    using (MySqlDataReader healthReader = healthCmd.ExecuteReader())
                    {
                        // Reset currentRow to startRow
                        currentRow = startRow;

                        // Check if the reader has rows
                        if (healthReader.HasRows)
                        {
                            // Iterate through each row in the result set
                            while (healthReader.Read())
                            {
                                // Displaying data from age_distribution in columns 3 and 4
                                oSheet.Cells[currentRow, 7] = healthReader.GetString(0); // AgeGroup
                                oSheet.Cells[currentRow, 8] = healthReader.GetInt32(1); // count
                                currentRow++; // Move to the next row in Excel
                            }
                        }
                    }
                }

                // Fetch data from adoption_status view
                string adoptionQuery = "SELECT adoption_status, Count FROM adoption_status;";
                using (MySqlCommand adoptionCmd = new MySqlCommand(adoptionQuery, con))
                {
                    using (MySqlDataReader adoptionReader = adoptionCmd.ExecuteReader())
                    {
                        // Reset currentRow to startRow
                        currentRow = startRow;

                        // Check if the reader has rows
                        if (adoptionReader.HasRows)
                        {
                            // Iterate through each row in the result set
                            while (adoptionReader.Read())
                            {
                                // Displaying data from age_distribution in columns 3 and 4
                                oSheet.Cells[currentRow, 9] = adoptionReader.GetString(0); // AgeGroup
                                oSheet.Cells[currentRow, 10] = adoptionReader.GetInt32(1); // count
                                currentRow++; // Move to the next row in Excel
                            }
                        }
                    }
                }
            }
        }

        private void donation_report_button_Click(object sender, EventArgs e)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            //Excel.Range oRng;

            try
            {
                oXL = new Excel.Application();
                oXL.Visible = true;

                oWB = oXL.Workbooks.Add(System.Reflection.Missing.Value);
                //oWB = oXL.Workbooks.Add(Type.Missing);
                //oWB = (Excel._Workbook)(oXL.Workbooks.Add(System.Reflection.Missing.Value)); // Corrected reference
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;
                               
                oSheet.Name = "Inventory Report";

                // Merge cells A1 to H7
                oSheet.get_Range("A1", "J10").Merge();

                // Merge cells A10 to H11
                Excel.Range titleRange = oSheet.get_Range("A11", "J13");
                titleRange.Merge();

                // Set text to "Donation Report"
                oSheet.Cells[11, 1] = "Inventory Report";


                // Format the text
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.Font.Color = System.Drawing.Color.FromArgb(132, 18, 18);
                titleRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Add logo
                var logoTextbox = oSheet.Shapes.AddPicture("C:\\Users\\Aly\\Downloads//FurEverHome.png", MsoTriState.msoFalse, MsoTriState.msoCTrue, 20, 20, 100, 100);

                // Add text box for "FurEver Home" above the address, contact, and email
                var furEverHomeTextbox = oSheet.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 20, 10, 100, 100);
                var furEverHomeTextFrame = furEverHomeTextbox.TextFrame2;
                // Remove the outline of the text box
                furEverHomeTextbox.Line.Visible = MsoTriState.msoFalse;

                // Set text for the "FurEver Home" text box
                furEverHomeTextFrame.TextRange.Text = "FurEver Home";

                // Apply formatting to the "FurEver Home" text box
                furEverHomeTextFrame.TextRange.Font.Bold = MsoTriState.msoTrue; // Use MsoTriState.msoTrue for true
                furEverHomeTextFrame.TextRange.Font.Size = 28;
                var color = System.Drawing.Color.FromArgb(132, 18, 18);
                furEverHomeTextFrame.TextRange.Font.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(color); // Same color as the address, contact, and email

                // Resize the text box to fit the text content
                furEverHomeTextbox.Width = furEverHomeTextFrame.TextRange.BoundWidth + 65; // Add some padding
                furEverHomeTextbox.Height = 40; // Add some padding

                // Position the "FurEver Home" text box above the address, contact, and email
                furEverHomeTextbox.Top = 20;
                furEverHomeTextbox.Left = logoTextbox.Left + logoTextbox.Width; // Add some spacing

                // Remove the outline of the text box
                furEverHomeTextbox.Line.Visible = MsoTriState.msoFalse;

                // Add text box for address, contact, and email below the "FurEver Home" text box
                var headerTextbox = oSheet.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal,
                                                              furEverHomeTextbox.Left, furEverHomeTextbox.Top + furEverHomeTextbox.Height + 10, 300, 100);
                var textFrame = headerTextbox.TextFrame2;

                // Set text for the entire text frame
                textFrame.TextRange.Text = "Address: Albay, Philippines\nContact: +63 912 3456 789\nEmail: furverhome@gmail.com";

                // Apply formatting to the entire text frame
                textFrame.TextRange.Font.Bold = MsoTriState.msoTrue; // Use MsoTriState.msoTrue for true
                textFrame.TextRange.Font.Size = 12;
                //textFrame.TextRange.Font.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(color);

                // Resize the text box to fit the text content
                headerTextbox.Width = textFrame.TextRange.BoundWidth; // Add some padding
                headerTextbox.Height = textFrame.TextRange.BoundHeight; // Add some padding

                // Remove the outline of the text box
                headerTextbox.Line.Visible = MsoTriState.msoFalse;

                // Lock the header cells
                oSheet.get_Range("A1", "J10").Locked = true;

                // Add original header
                oSheet.Cells[14, 1] = "Total Animals";
                oSheet.Cells[14, 2] = "Total Animal Kinds";
                oSheet.Cells[14, 3] = "Age Distribution";
                oSheet.Cells[14, 4] = "";
                oSheet.Cells[14, 5] = "Gender Distribution";
                oSheet.Cells[14, 6] = "";
                oSheet.Cells[14, 7] = "Health Status";
                oSheet.Cells[14, 8] = "";
                oSheet.Cells[14, 9] = "Adoption Status";
                oSheet.Cells[14, 10] = "";

                // Add styles to original header
                Excel.Range headerRange = oSheet.get_Range("A14", "J14");
                headerRange.Font.Bold = true;
                headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                headerRange.Font.Color = System.Drawing.Color.White;
                headerRange.Interior.Color = System.Drawing.Color.FromArgb(132, 18, 18);

                // Unprotect the sheet to allow modifications
                oSheet.Unprotect();

                // Add donation data
                PopulateAnimalData(oSheet);

                // Create Sheet2 for the pie chart
                Excel._Worksheet oSheet2 = (Excel._Worksheet)oWB.Sheets.Add();
                oSheet2.Name = "Age Distribution";

                // Get age distribution data
                Dictionary<string, int> ageDistribution = GetAgeDistributionData();

                // Populate age distribution data into Sheet2
                int startRow = 1;
                int currentRow = startRow;
                foreach (var kvp in ageDistribution)
                {
                    oSheet2.Cells[currentRow, 1] = kvp.Key; // AgeGroup
                    oSheet2.Cells[currentRow, 2] = kvp.Value; // count
                    currentRow++;
                }

                // Generate pie chart for age distribution on Sheet2
                GeneratePieChart(oSheet2, ageDistribution);

                // Format cells
                Excel.Range range = oSheet.Range["A14:J25"];
                range.Columns.AutoFit();

                PlaceSignaturePlaceholder(oSheet);

                // Protect the sheet again
                oSheet.Protect();

                oXL.Visible = true;
                oXL.UserControl = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void PlaceSignaturePlaceholder(Excel._Worksheet oSheet)
        {
            // Find the last used row and column
            int lastRow = oSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            // Calculate the row position for the signature placeholder
            int signatureRow = lastRow + 3; // Place the signature placeholder 2 rows below the last used row

            // Add signature placeholder
            oSheet.Cells[signatureRow, 7] = "Signature:"; // Place the signature placeholder in the 9th column

            // Merge cells for signature area
            oSheet.Range[oSheet.Cells[signatureRow, 7], oSheet.Cells[signatureRow, 10]].Merge();

            // Apply formatting to signature area
            Excel.Range signatureRange = oSheet.Range[oSheet.Cells[signatureRow, 7], oSheet.Cells[signatureRow, 10]];
            signatureRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft; // Align signature text to the right
            signatureRange.Font.Bold = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Shelter new_AnimalForm = new Shelter(loggedInUsername);
            new_AnimalForm.ShowDialog();
        }

        private Dictionary<string, int> GetAgeDistributionData()
        {
            Dictionary<string, int> ageDistribution = new Dictionary<string, int>();

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string ageQuery = "SELECT AgeGroup, count FROM age_distribution;";
                using (MySqlCommand ageCmd = new MySqlCommand(ageQuery, con))
                {
                    using (MySqlDataReader ageReader = ageCmd.ExecuteReader())
                    {
                        if (ageReader.HasRows)
                        {
                            while (ageReader.Read())
                            {
                                string ageGroup = ageReader.GetString(0);
                                int count = ageReader.GetInt32(1);
                                ageDistribution.Add(ageGroup, count);
                            }
                        }
                    }
                }
            }

            return ageDistribution;
        }

        private void GeneratePieChart(Excel._Worksheet oSheet, Dictionary<string, int> ageDistribution)
        {
            Excel.ChartObjects chartObjects = (Excel.ChartObjects)oSheet.ChartObjects(System.Type.Missing);
            Excel.ChartObject chartObject = chartObjects.Add(100, 100, 300, 300) as Microsoft.Office.Interop.Excel.ChartObject;

            Excel.Chart chart = chartObject.Chart;

            // Prepare data for the chart
            Excel.Range chartRange = oSheet.Range["A1", "B" + ageDistribution.Count] as Microsoft.Office.Interop.Excel.Range;

            chart.SetSourceData(chartRange, Excel.XlRowCol.xlColumns);

            // Set chart type to Pie
            chart.ChartType = Excel.XlChartType.xlPie;

            // Add data labels
            chart.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowLabel, false, true, true, false, false, true, false, true, true);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Donations donationsForm = new Donations(loggedInUsername);
            donationsForm.ShowDialog();
            this.Close();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adoption adoptionForm = new Adoption(loggedInUsername);
            adoptionForm.ShowDialog();
            this.Close();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {

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
    }
}
