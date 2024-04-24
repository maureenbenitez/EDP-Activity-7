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
using Microsoft.Office.Interop.Excel;

namespace A4_Graphical_User_Interface
{
    public partial class Adoption : Form
    {
        private string loggedInUsername;
        public Adoption(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
            this.Load += Adoption_Load;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

        }

        private void Adoption_Load(object sender, EventArgs e)
        {
            DisplayAdoptionData();
        }

        private void DisplayAdoptionData()
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT animal_id AS 'Animal ID', animal_kind AS 'Animal Kind', name AS 'Name', breed AS 'Breed', age AS 'Age', size AS 'Size', sex AS 'Sex', coat_length AS 'Coat Length', color AS 'Color', health_status AS 'Health Status', adoption_status AS 'Adoption Status' FROM adopted_animals";
                MySqlCommand cmd = new MySqlCommand(query, con);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        //DataTable dt = new DataTable();
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

        private void PopulateAdoptionData(Excel._Worksheet oSheet)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();

                // Query to fetch data from the adoption_report view
                string adoptionQuery = "SELECT adoption_id, animal_id, animal_name, adopter_id, adopter_name, DATE(adoption_date) AS adoption_date, adoption_fee FROM adoption_report";
                MySqlCommand adoptionCmd = new MySqlCommand(adoptionQuery, con);

                // Query to fetch data from the adoption_summary view
                string summaryQuery = "SELECT * FROM adoption_summary";
                MySqlCommand summaryCmd = new MySqlCommand(summaryQuery, con);

                // Track the last row populated with adoption data
                int lastAdoptionDataRow = 15; // Row number to start writing data

                using (MySqlDataReader reader = adoptionCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int col = 1; col <= reader.FieldCount; col++)
                        {
                            // If it's the 6th column (Adoption Date), extract the date part
                            if (col == 6 && reader[col - 1] != DBNull.Value)
                            {
                                DateTime adoptionDate = Convert.ToDateTime(reader[col - 1]);
                                oSheet.Cells[lastAdoptionDataRow, col] = adoptionDate.ToShortDateString();
                            }
                            else
                            {
                                oSheet.Cells[lastAdoptionDataRow, col] = reader[col - 1].ToString();
                            }
                        }
                        lastAdoptionDataRow++; // Move to the next row
                    }
                    lastAdoptionDataRow++; // Add 1 row space after adoption data
                }

                // Execute query to fetch data from adoption_summary view
                using (MySqlDataReader summaryReader = summaryCmd.ExecuteReader())
                {
                    if (summaryReader.Read())
                    {
                        // Display first data (total_adoptions) from adoption_summary view
                        oSheet.Cells[lastAdoptionDataRow, 1] = "Total Adopted Animals";
                        oSheet.Cells[lastAdoptionDataRow, 1].Font.Bold = true;
                        oSheet.Cells[lastAdoptionDataRow, 2] = summaryReader["total_adoptions"].ToString();
                    }
                }
                using (MySqlDataReader summaryReader = summaryCmd.ExecuteReader())
                {
                    // Move to the next record to read the second data
                    if (summaryReader.Read())
                    {
                        // Display second data (total_adoption_fee) from adoption_summary view
                        oSheet.Cells[lastAdoptionDataRow, 6] = "Total Adoption Fee";
                        oSheet.Cells[lastAdoptionDataRow, 6].Font.Bold = true;
                        oSheet.Cells[lastAdoptionDataRow, 7] = summaryReader["total_adoption_fee"].ToString();
                    }
                }
            }
        }
        
                

        private void adoption_report_button_Click(object sender, EventArgs e)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            //Excel.Range oRng;

            try
            {
                oXL = new Excel.Application();
                oXL.Visible = true;

                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                oSheet.Name = "Monthly Adoption";

                // Merge cells A1 to H7
                oSheet.get_Range("A1", "H10").Merge();

                // Merge cells A10 to H11
                Excel.Range titleRange = oSheet.get_Range("A11", "H13");
                titleRange.Merge();

                // Set text to "Donation Report"
                oSheet.Cells[11, 1] = "Adoption Report";


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
                oSheet.get_Range("A1", "I10").Locked = true;

                // Add original header
                oSheet.Cells[14, 1] = "Adoption ID";
                oSheet.Cells[14, 2] = "Animal ID";
                oSheet.Cells[14, 3] = "Animal Name";
                oSheet.Cells[14, 4] = "Adopter ID";
                oSheet.Cells[14, 5] = "Adopter Name";
                oSheet.Cells[14, 6] = "Adoption Date";
                oSheet.Cells[14, 7] = "Adoption Fee";
                                
                // Add styles to original header
                Excel.Range headerRange = oSheet.get_Range("A14", "G14");
                headerRange.Font.Bold = true;
                headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                headerRange.Font.Color = System.Drawing.Color.White;
                headerRange.Interior.Color = System.Drawing.Color.FromArgb(132, 18, 18);

                // Unprotect the sheet to allow modifications
                oSheet.Unprotect();

                // Add donation data
                PopulateAdoptionData(oSheet);

                // Format cells
                Excel.Range range = oSheet.Range["A14:H25"];
                range.Columns.AutoFit();

                PlaceSignaturePlaceholder(oSheet);

                // Protect the sheet again
                oSheet.Protect();

                GenerateMonthlyAdoptionGraph(oWB);

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
            oSheet.Cells[signatureRow, 6] = "Signature:"; // Place the signature placeholder in the 9th column

            // Merge cells for signature area
            oSheet.Range[oSheet.Cells[signatureRow, 6], oSheet.Cells[signatureRow, 7]].Merge();

            // Apply formatting to signature area
            Excel.Range signatureRange = oSheet.Range[oSheet.Cells[signatureRow, 6], oSheet.Cells[signatureRow, 7]];
            signatureRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft; // Align signature text to the right
            signatureRange.Font.Bold = true;
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

        private void dashboard_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboardForm = new Dashboard(loggedInUsername);
            dashboardForm.ShowDialog();
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Open the NewForm when the button is clicked
            New_Adoption new_AdoptionForm = new New_Adoption(loggedInUsername);
            new_AdoptionForm.ShowDialog();
        }

        private void GenerateMonthlyAdoptionGraph(Excel._Workbook oWB)
        {
            // Create a new worksheet (Sheet 2) for the graph
            Excel._Worksheet oSheet2 = oWB.Sheets.Add();
            oSheet2.Name = "Monthly Adoption Graph";

            // Retrieve monthly adoption data from the database
            Dictionary<string, int> monthlyAdoptions = GetMonthlyAdoptions();

            // Populate the data on Sheet 2
            int rowIndex = 1;
            foreach (var pair in monthlyAdoptions)
            {
                oSheet2.Cells[rowIndex, 1] = pair.Key; // Month
                oSheet2.Cells[rowIndex, 2] = pair.Value; // Total Adoption Count
                rowIndex++;
            }

            // Create a bar graph
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)oSheet2.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = xlCharts.Add(100, 100, 300, 250);
            Excel.Chart chartPage = myChart.Chart;
            Excel.Range chartRange = oSheet2.Range[oSheet2.Cells[1, 1], oSheet2.Cells[rowIndex - 1, 2]];
            chartPage.SetSourceData(chartRange, Type.Missing);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            // Change the series name
            Excel.Series series = (Excel.Series)chartPage.SeriesCollection(1);
            series.Name = "Monthly Adoption";
        }

        private Dictionary<string, int> GetMonthlyAdoptions()
        {
            Dictionary<string, int> monthlyAdoptions = new Dictionary<string, int>();

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT DATE_FORMAT(adoption_date, '%Y-%m') AS Month, COUNT(*) AS TotalAdoptions FROM adoption GROUP BY Month";
                MySqlCommand cmd = new MySqlCommand(query, con);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string month = reader.GetString("Month");
                        int totalAdoptions = reader.GetInt32("TotalAdoptions");
                        monthlyAdoptions.Add(month, totalAdoptions);
                    }
                }
            }
            return monthlyAdoptions;
        }

        private void Adoption_Load_1(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Donations donationsForm = new Donations(loggedInUsername);
            donationsForm.ShowDialog();
            this.Close();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Animals animalsForm = new Animals(loggedInUsername);
            animalsForm.ShowDialog();
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
    }
}
