using System.CodeDom.Compiler;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Mailing_Manager
{
    public partial class Mail_Manager : Form
    {
#nullable disable

        private string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString; // Fetch the SQL connection string config file
        private string templateContent = string.Empty; // Variable to store the template content
        private byte[] attachmentFileBytes = null; // Variable to store the attachment file contents
        private string attachmentFileName = string.Empty; // Variable to store the attachment file name

        //Fetch SMPT data from config file
        string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
        int port = int.Parse(ConfigurationManager.AppSettings["Port"]);
        string senderEmail = ConfigurationManager.AppSettings["SenderEmail"];
        string senderName = ConfigurationManager.AppSettings["SenderName"];
        string username = ConfigurationManager.AppSettings["Username"];
        string password = ConfigurationManager.AppSettings["Password"];

        private System.Windows.Forms.Timer timer;
        private DateTime scheduledDateTime;
        public Mail_Manager()
        {
            InitializeComponent();
            PopulateCompanyNames();
            PopulateTableNames();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += ScheduleTimer_Tick;
        }

        private void ScheduleTimer_Tick(object sender, EventArgs e)
        {
            CheckScheduledTime();
        }

        private void CheckScheduledTime()
        {
            DateTime currentTime = DateTime.Now;
            DateTime selectedTime = Schedule_DateTime.Value;

            if (currentTime >= selectedTime)
            {
                ScheduleEmails();
                timer.Stop();
            }
        }

        private async void ScheduleEmails()
        {
            try
            {
                string selectedExtRegID = ExtRegID_TXT.Text;
                Lock();

                Scheduler_LB.Text = "Sending...";

                string extRegQuery = "SELECT Firstname, Lastname, Email FROM ExternalRegistration_CFASociety WHERE ExtRegID = @ExtRegID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(extRegQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ExtRegID", selectedExtRegID);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string firstname = reader.GetString(0);
                                string lastname = reader.GetString(1);
                                string email = reader.GetString(2);

                                using (SqlConnection insertConnection = new SqlConnection(connectionString))
                                {
                                    await insertConnection.OpenAsync();

                                    string populateLog =
                                    "INSERT INTO EmailLog (PresentationID, ExtRegID, Firstname, Lastname, EmailAddress, EmailType, EmailTemplate, AttachmentFile, Subject, TableName, Sent, CreateDate) " +
                                    "VALUES (@PresentationID, @ExtRegID, @Firstname, @Lastname, @EmailAddress, @EmailType, @EmailTemplate, @AttachmentFile, @Subject, @TableName, @Sent, @CreateDate)";

                                    using (SqlCommand insertCommand = new SqlCommand(populateLog, insertConnection))
                                    {
                                        insertCommand.Parameters.AddWithValue("@PresentationID", PresentationID_TXT.Text);
                                        insertCommand.Parameters.AddWithValue("@ExtRegID", selectedExtRegID);
                                        insertCommand.Parameters.AddWithValue("@Firstname", firstname);
                                        insertCommand.Parameters.AddWithValue("@Lastname", lastname);
                                        insertCommand.Parameters.AddWithValue("@EmailAddress", email);
                                        insertCommand.Parameters.AddWithValue("@EmailType", 1);
                                        insertCommand.Parameters.AddWithValue("@EmailTemplate", Template_TXT.Text);
                                        insertCommand.Parameters.AddWithValue("@AttachmentFile", Attachment_TXT.Text);
                                        insertCommand.Parameters.AddWithValue("@Subject", Subject_TXT.Text);
                                        insertCommand.Parameters.AddWithValue("@TableName", TableName_Combo.Text);
                                        insertCommand.Parameters.AddWithValue("@Sent", false);
                                        insertCommand.Parameters.AddWithValue("@CreateDate", DateTime.Now);

                                        // Create a new MailMessage for each recipient
                                        MailMessage mailmessage = new MailMessage(senderEmail, email);
                                        mailmessage.Subject = Subject_TXT.Text;

                                        // Replace the [Viewername] field in the template with the recipient's name
                                        string modifiedTemplate = templateContent.Replace("[ViewerName]", firstname + " " + lastname);

                                        // Create the HTML view from the modified template
                                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(modifiedTemplate, Encoding.UTF8, MediaTypeNames.Text.Html);

                                        // Attach the HTML view to the email
                                        mailmessage.AlternateViews.Add(htmlView);

                                        // Attach the attachment file, if available
                                        if (attachmentFileBytes != null)
                                        {
                                            // Create a memory stream from the attachment file bytes
                                            MemoryStream attachmentStream = new MemoryStream(attachmentFileBytes);

                                            // Create the attachment
                                            Attachment attachment = new Attachment(attachmentStream, attachmentFileName);

                                            // Add the attachment to the email
                                            mailmessage.Attachments.Add(attachment);
                                        }

                                        SmtpClient smtpclient = new SmtpClient(smtpServer, port);
                                        smtpclient.EnableSsl = true;
                                        smtpclient.Credentials = new System.Net.NetworkCredential()
                                        {
                                            UserName = username,
                                            Password = password
                                        };

                                        try
                                        {
                                            await smtpclient.SendMailAsync(mailmessage);

                                            insertCommand.Parameters["@Sent"].Value = true;

                                            // Execute the insert command
                                            await insertCommand.ExecuteNonQueryAsync();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("An error occurred while sending the email to " + email + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Unlock();
                Scheduler_LB.Text = "Complete!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Schedule_DateTime_ValueChanged(object sender, EventArgs e)
        {
            scheduledDateTime = Schedule_DateTime.Value;
        }

        private void Schedule_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(templateContent))
                {
                    MessageBox.Show("Please select a template.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (attachmentFileBytes == null)
                {
                    MessageBox.Show("Please select an attachment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the ExtReg field is empty
                if (string.IsNullOrWhiteSpace(ExtRegID_TXT.Text))
                {
                    MessageBox.Show("Please enter a valid ExtRegID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Start the timer to check for the scheduled time
                timer.Start();
                Scheduler_LB.Text = "Scheduled at " + scheduledDateTime.ToString();
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show("An error occurred with sheduling emails: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateCompanyNames()
        {
            try
            {
                // Create a new SQL connection and command objects
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("Company_List", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        // Execute the query and retrieve the data
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Bind the data to the drop-down list
                            while (reader.Read())
                            {
                            }
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show("An error occurred while populating company names: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateTableNames()
        {
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

            try
            {
                // Create a new SQL connection and command objects
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query and retrieve the table names
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the ComboBox
                        TableName_Combo.Items.Clear();

                        // Add table names to the ComboBox
                        while (reader.Read())
                        {
                            string tableName = reader.GetString(0);
                            TableName_Combo.Items.Add(tableName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show("An error occurred while populating table names: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedCompany = CompanyBox.SelectedItem?.ToString();

                if (selectedCompany != null)
                {

                    // Define the SQL query to retrieve the CompanyID based on the selected company
                    string companyIDQuery = "SELECT Company.CompanyID FROM Company WHERE Company.CompanyName = @CompanyName";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Retrieve the CompanyID using the first query
                        int companyID;
                        using (SqlCommand companyIDCommand = new SqlCommand(companyIDQuery, connection))
                        {
                            // Set the CompanyName parameter value
                            companyIDCommand.Parameters.AddWithValue("@CompanyName", selectedCompany);

                            // Execute the query and retrieve the CompanyID
                            object result = companyIDCommand.ExecuteScalar();
                            if (result != null && int.TryParse(result.ToString(), out companyID))
                            {
                                // Define the SQL query to retrieve the data from ExternalRegistration and Presentation tables
                                string query =
                                    "SELECT ExternalRegistration.ExtRegID, Presentation.PresentationID, Presentation.PresentationName " +
                                    "FROM Presentation " +
                                    "LEFT JOIN ExternalRegistration ON Presentation.PresentationID = ExternalRegistration.PresentationID " +
                                    "WHERE ExternalRegistration.CompanyID = @CompanyID";

                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    // Set the CompanyID parameter value
                                    command.Parameters.AddWithValue("@CompanyID", companyID);

                                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                                    {
                                        DataTable companyData = new DataTable();
                                        adapter.Fill(companyData);

                                        // Clear the existing rows in the DataGridView
                                        dataGridViewEvents.Rows.Clear();

                                        // Populate the DataGridView with the data from the DataTable
                                        foreach (DataRow row in companyData.Rows)
                                        {
                                            // Add a new row to the DataGridView
                                            int rowIndex = dataGridViewEvents.Rows.Add();

                                            // Set the values of each cell in the row
                                            dataGridViewEvents.Rows[rowIndex].Cells["ExtRegID"].Value = row["ExtRegID"];
                                            dataGridViewEvents.Rows[rowIndex].Cells["PresentationID"].Value = row["PresentationID"];
                                            dataGridViewEvents.Rows[rowIndex].Cells["PresentationName"].Value = row["PresentationName"];
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Selected company does not exist or invalid CompanyID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Browse_Template_BTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "HTML Files|*.html|Text Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string templatePath = openFileDialog.FileName;

                Template_TXT.Text = openFileDialog.SafeFileName;

                // Read the template file contents
                templateContent = File.ReadAllText(templatePath);
            }
        }

        private void Attachment_BTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "iCalendar Files|*.ics";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string attachmentPath = openFileDialog.FileName;

                Attachment_TXT.Text = openFileDialog.SafeFileName;

                // Read the attachment file contents into a byte array
                attachmentFileBytes = File.ReadAllBytes(attachmentPath);
                attachmentFileName = openFileDialog.SafeFileName;
            }
        }

        private void Test_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(templateContent))
            {
                MessageBox.Show("Please select a template.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the ToEmail field is empty
            if (string.IsNullOrWhiteSpace(ToEmail_TXT.Text))
            {
                MessageBox.Show("Please enter a valid recipient email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the ViewerName field is empty
            if (string.IsNullOrWhiteSpace(ViewerName_TXT.Text))
            {
                MessageBox.Show("Please enter a valid viewer name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Lock();
            MailMessage mailmessage = new MailMessage(senderEmail, ToEmail_TXT.Text);
            mailmessage.Subject = Subject_TXT.Text;

            // Replace the [Viewername] field in the template with the specified name
            string modifiedTemplate = templateContent.Replace("[ViewerName]", ViewerName_TXT.Text);

            // Create the HTML view from the modified template
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(modifiedTemplate, Encoding.UTF8, MediaTypeNames.Text.Html);

            // Attach the HTML view to the email
            mailmessage.AlternateViews.Add(htmlView);

            // Attach the attachment file, if available
            if (attachmentFileBytes != null)
            {
                // Create a memory stream from the attachment file bytes
                MemoryStream attachmentStream = new MemoryStream(attachmentFileBytes);

                // Create the attachment
                Attachment attachment = new Attachment(attachmentStream, attachmentFileName);

                // Add the attachment to the email
                mailmessage.Attachments.Add(attachment);
            }

            SmtpClient smtpclient = new SmtpClient(smtpServer, port);
            smtpclient.EnableSsl = true;
            smtpclient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = username,
                Password = password
            };

            try
            {
                smtpclient.Send(mailmessage);
                MessageBox.Show("Test Email sent successfully to: " + ToEmail_TXT.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unlock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sending the email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SendNow_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedExtRegID = ExtRegID_TXT.Text;
         

                if (string.IsNullOrWhiteSpace(templateContent))
                {
                    MessageBox.Show("Please select a template.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (attachmentFileBytes == null)
                {
                    MessageBox.Show("Please select an attachment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the ExtReg field is empty
                if (string.IsNullOrWhiteSpace(ExtRegID_TXT.Text))
                {
                    MessageBox.Show("Please enter a valid ExtRegID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Send_LB.Text = "Sending...";       
                Lock();

                string extRegQuery = "SELECT Firstname, Lastname, Email FROM ExternalRegistration_CFASociety WHERE ExtRegID = @ExtRegID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(extRegQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ExtRegID", selectedExtRegID);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string firstname = reader.GetString(0);
                                string lastname = reader.GetString(1);
                                string email = reader.GetString(2);

                                using (SqlConnection insertConnection = new SqlConnection(connectionString))
                                {
                                    await insertConnection.OpenAsync();

                                    string populateLog =
                                    "INSERT INTO EmailLog (PresentationID, ExtRegID, Firstname, Lastname, EmailAddress, EmailType, EmailTemplate, AttachmentFile, Subject, TableName, Sent, CreateDate) " +
                                    "VALUES (@PresentationID, @ExtRegID, @Firstname, @Lastname, @EmailAddress, @EmailType, @EmailTemplate, @AttachmentFile, @Subject, @TableName, @Sent, @CreateDate)";

                                    using (SqlCommand insertCommand = new SqlCommand(populateLog, insertConnection))
                                    {
                                        insertCommand.Parameters.AddWithValue("@PresentationID", PresentationID_TXT.Text);
                                        insertCommand.Parameters.AddWithValue("@ExtRegID", selectedExtRegID);
                                        insertCommand.Parameters.AddWithValue("@Firstname", firstname);
                                        insertCommand.Parameters.AddWithValue("@Lastname", lastname);
                                        insertCommand.Parameters.AddWithValue("@EmailAddress", email);
                                        insertCommand.Parameters.AddWithValue("@EmailType", 1);
                                        insertCommand.Parameters.AddWithValue("@EmailTemplate", Template_TXT.Text);
                                        insertCommand.Parameters.AddWithValue("@AttachmentFile", Attachment_TXT.Text);
                                        insertCommand.Parameters.AddWithValue("@Subject", Subject_TXT.Text);
                                        insertCommand.Parameters.AddWithValue("@TableName", TableName_Combo.Text);
                                        insertCommand.Parameters.AddWithValue("@Sent", false);
                                        insertCommand.Parameters.AddWithValue("@CreateDate", DateTime.Now);

                                        // Create a new MailMessage for each recipient
                                        MailMessage mailmessage = new MailMessage(senderEmail, email);
                                        mailmessage.Subject = Subject_TXT.Text;

                                        // Replace the [Viewername] field in the template with the recipient's name
                                        string modifiedTemplate = templateContent.Replace("[ViewerName]", firstname + " " + lastname);

                                        // Create the HTML view from the modified template
                                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(modifiedTemplate, Encoding.UTF8, MediaTypeNames.Text.Html);

                                        // Attach the HTML view to the email
                                        mailmessage.AlternateViews.Add(htmlView);

                                        // Attach the attachment file, if available
                                        if (attachmentFileBytes != null)
                                        {
                                            // Create a memory stream from the attachment file bytes
                                            MemoryStream attachmentStream = new MemoryStream(attachmentFileBytes);

                                            // Create the attachment
                                            Attachment attachment = new Attachment(attachmentStream, attachmentFileName);

                                            // Add the attachment to the email
                                            mailmessage.Attachments.Add(attachment);
                                        }

                                        SmtpClient smtpclient = new SmtpClient(smtpServer, port);
                                        smtpclient.EnableSsl = true;
                                        smtpclient.Credentials = new System.Net.NetworkCredential()
                                        {
                                            UserName = username,
                                            Password = password
                                        };

                                        try
                                        {
                                            await smtpclient.SendMailAsync(mailmessage);

                                            insertCommand.Parameters["@Sent"].Value = true;

                                            // Execute the insert command
                                            await insertCommand.ExecuteNonQueryAsync();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("An error occurred while sending the email to " + email + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Unlock();
                Send_LB.Text = "Complete!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateEmailLog_BTN_Click(object sender, EventArgs e)
        {
            // Define the SQL query
            string query = "SELECT * FROM EmailLog";

            try
            {
                // Create a new SQL connection and command objects
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query and retrieve the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Create a DataTable to store the data
                        DataTable dataTable = new DataTable();

                        // Load the data into the DataTable
                        dataTable.Load(reader);

                        // Bind the DataTable to the DataGridView
                        EmailLogBox.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show("An error occurred while populating Email Log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmailLogNotSent_BTN_Click(object sender, EventArgs e)
        {
            // Define the SQL query
            string query = "SELECT * FROM EmailLog WHERE Sent =0";

            try
            {
                // Create a new SQL connection and command objects
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query and retrieve the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Create a DataTable to store the data
                        DataTable dataTable = new DataTable();

                        // Load the data into the DataTable
                        dataTable.Load(reader);

                        // Bind the DataTable to the DataGridView
                        EmailLogBox.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show("An error occurred while populating Email Log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearEmailLog_BTN_Click(object sender, EventArgs e)
        {
            // Clear the data in the DataGridView
            EmailLogBox.DataSource = null;
        }

        private void Lock()
        {
            Browse_Template_BTN.Enabled = false;
            Attachment_BTN.Enabled = false;
            Test_btn.Enabled = false;
            SendNow_BTN.Enabled = false;
            Schedule_BTN.Enabled = false;
        }

        private void Unlock()
        {
            Browse_Template_BTN.Enabled = true;
            Attachment_BTN.Enabled = true;
            Test_btn.Enabled = true;
            SendNow_BTN.Enabled = true;
            Schedule_BTN.Enabled = true;
        }
    }
}