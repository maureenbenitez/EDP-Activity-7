using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

namespace A4_Graphical_User_Interface
{
    public partial class Donations : Form
    {
        private string loggedInUsername;
        public Donations(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
            this.Load += Donation_Load;
        }

        private void Donation_Load(object sender, EventArgs e)
        {
            DisplayDonationData();
        }

        private void DisplayDonationData()
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT donation_id AS 'Donation ID', donor_name AS 'Donor Name', donor_contact AS 'Donor Contact', donation_date AS 'Donation Date', donation_type AS 'Donation Type', donation_amount AS 'Donation Amount', donation_method AS 'Donation Method', purpose AS 'Purpose' FROM donation";
                MySqlCommand cmd = new MySqlCommand(query, con);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);

                        dt.Columns["Donation ID"].SetOrdinal(0);
                        dt.Columns["Donor Name"].SetOrdinal(1);
                        dt.Columns["Donor Contact"].SetOrdinal(2);
                        dt.Columns["Donation Date"].SetOrdinal(3);
                        dt.Columns["Donation Type"].SetOrdinal(4);
                        dt.Columns["Donation Amount"].SetOrdinal(5);
                        dt.Columns["Donation Method"].SetOrdinal(6);
                        dt.Columns["Purpose"].SetOrdinal(7);
 
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

        private void PopulateDonationData(Excel._Worksheet oSheet)
        {
            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();

                // Retrieve data from the donation table
                string donationQuery = "SELECT * FROM donation";
                MySqlCommand donationCommand = new MySqlCommand(donationQuery, con);

                using (MySqlDataReader donationReader = donationCommand.ExecuteReader())
                {
                    int row = 15; // Start row for data in Excel sheet, with 8 rows space above

                    while (donationReader.Read())
                    {
                        // Populate Excel sheet with donation data
                        for (int i = 0; i < donationReader.FieldCount; i++)
                        {
                            if (i == 3) // Check if it's the Donation Date column
                            {
                                // Format the date to show only the date part
                                DateTime donationDate = Convert.ToDateTime(donationReader[i]);
                                oSheet.Cells[row, i + 1] = donationDate.ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                oSheet.Cells[row, i + 1] = donationReader[i].ToString();
                            }
                        }

                        row++; // Move to the next row for the next donation
                    }
                }

                // Retrieve data from the donation_report view
                string reportQuery = "SELECT * FROM donation_report";
                MySqlCommand reportCommand = new MySqlCommand(reportQuery, con);

                using (MySqlDataReader reportReader = reportCommand.ExecuteReader())
                {
                    int row = 15; // Start row for data in Excel sheet, with 8 rows space above
                    decimal totalDonationAmount = 0;
                    int totalDonors = 0;

                    // Move to the next empty row after the data from the donation table
                    while (oSheet.Cells[row, 1].Value != null)
                    {
                        row++;
                    }

                    //row += 8; // Move down 8 more rows to create space
                    row++;

                    // Display the total donation amount label and value above the donation type column
                    oSheet.Cells[row, 5] = "Total Donation Amount";
                    oSheet.Cells[row, 5].Font.Bold = true;

                    // Display the total donors label
                    oSheet.Cells[row, 1] = "Total Donors";
                    oSheet.Cells[row, 1].Font.Bold = true;

                    // Move to the next row for the donation report data
                    row++;

                    while (reportReader.Read())
                    {
                        // Sum up the values in the total_donors column
                        int donors;
                        if (int.TryParse(reportReader["total_donors"].ToString(), out donors))
                        {
                            totalDonors += donors;
                        }

                        // Sum up the total donation amount
                        decimal donationAmount;
                        if (decimal.TryParse(reportReader["total_donation_amount"].ToString(), out donationAmount))
                        {
                            totalDonationAmount += donationAmount;
                        }

                        // Populate Excel sheet with donation report data
                        oSheet.Cells[row, 5] = reportReader["donation_type"].ToString();
                        oSheet.Cells[row, 6] = reportReader["total_donation_amount"].ToString();
                        row++; // Move to the next row for the next donation report
                    }

                    // Display the total donors value
                    oSheet.Cells[row - 4, 2] = totalDonors.ToString();
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

                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                // Merge cells A1 to H7
                oSheet.get_Range("A1", "H10").Merge();

                // Merge cells A10 to H11
                Excel.Range titleRange = oSheet.get_Range("A11", "H13");
                titleRange.Merge();

                // Set text to "Donation Report"
                oSheet.Cells[11, 1] = "Donation Report";
                

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
                oSheet.Name = "Donation Report";

                // Add original header
                oSheet.Cells[14, 1] = "Donation ID";
                oSheet.Cells[14, 2] = "Donor Name";
                oSheet.Cells[14, 3] = "Donor Contact";
                oSheet.Cells[14, 4] = "Donation Date";
                oSheet.Cells[14, 5] = "Donation Type";
                oSheet.Cells[14, 6] = "Donation Amount";
                oSheet.Cells[14, 7] = "Donation Method";
                oSheet.Cells[14, 8] = "Purpose";

                // Add styles to original header
                Excel.Range headerRange = oSheet.get_Range("A14", "H14");
                headerRange.Font.Bold = true;
                headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                headerRange.Font.Color = System.Drawing.Color.White;
                headerRange.Interior.Color = System.Drawing.Color.FromArgb(132, 18, 18);

                // Unprotect the sheet to allow modifications
                oSheet.Unprotect();

                // Add donation data
                PopulateDonationData(oSheet);

                // Format cells
                Excel.Range range = oSheet.Range["A14:H25"];
                range.Columns.AutoFit();

                PlaceSignaturePlaceholder(oSheet);

                // Protect the sheet again
                oSheet.Protect();

                // Generate the graph on Sheet 2
                GenerateMonthlyDonationGraph(oWB);

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
            oSheet.Range[oSheet.Cells[signatureRow, 7], oSheet.Cells[signatureRow, 8]].Merge();

            // Apply formatting to signature area
            Excel.Range signatureRange = oSheet.Range[oSheet.Cells[signatureRow, 7], oSheet.Cells[signatureRow, 8]];
            signatureRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft; // Align signature text to the right
            signatureRange.Font.Bold = true;
        }

        private void datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void add_button_Click(object sender, EventArgs e)
        {
            // Open the NewForm when the button is clicked
            New_Donation new_DonationForm = new New_Donation(loggedInUsername);
            new_DonationForm.ShowDialog();
        }

        private void GenerateMonthlyDonationGraph(Excel._Workbook oWB)
        {
            // Create a new worksheet (Sheet 2) for the graph
            Excel._Worksheet oSheet2 = oWB.Sheets.Add();
            oSheet2.Name = "Monthly Donation Graph";

            // Retrieve monthly donation data from the database
            Dictionary<string, decimal> monthlyDonations = GetMonthlyDonations();

            // Populate the data on Sheet 2
            int rowIndex = 1;
            foreach (var pair in monthlyDonations)
            {
                oSheet2.Cells[rowIndex, 1] = pair.Key; // Month
                oSheet2.Cells[rowIndex, 2] = pair.Value; // Total Donation Amount
                rowIndex++;
            }

            // Create a bar graph
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)oSheet2.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = xlCharts.Add(100, 100, 300, 250);
            Excel.Chart chartPage = myChart.Chart;
            Excel.Range chartRange = oSheet2.Range[oSheet2.Cells[1, 1], oSheet2.Cells[rowIndex - 1, 2]];
            chartPage.SetSourceData(chartRange, Type.Missing);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            // Change the series name to "Money"
            Excel.Series series = (Excel.Series)chartPage.SeriesCollection(1);
            series.Name = "Money Donation";
        }

        private Dictionary<string, decimal> GetMonthlyDonations()
        {
            Dictionary<string, decimal> monthlyDonations = new Dictionary<string, decimal>();

            using (MySqlConnection con = MySQL_Connection.GetConnection())
            {
                con.Open();
                string query = "SELECT DATE_FORMAT(donation_date, '%Y-%m') AS Month, SUM(donation_amount) AS TotalAmount FROM donation WHERE donation_type = 'Money' GROUP BY Month";
                MySqlCommand cmd = new MySqlCommand(query, con);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string month = reader.GetString("Month");
                        decimal totalAmount = reader.GetDecimal("TotalAmount");
                        monthlyDonations.Add(month, totalAmount);
                    }
                }
            }
            return monthlyDonations;
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
            this.Hide();
            Animals animalsForm = new Animals(loggedInUsername);
            animalsForm.ShowDialog();
            this.Close();
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

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
