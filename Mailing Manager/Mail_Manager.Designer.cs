namespace Mailing_Manager
{
    partial class Mail_Manager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            CompanyBox = new ComboBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridViewEvents = new DataGridView();
            ExtRegID = new DataGridViewTextBoxColumn();
            PresentationID = new DataGridViewTextBoxColumn();
            PresentationName = new DataGridViewTextBoxColumn();
            Search_btn = new Button();
            Details = new GroupBox();
            groupBox6 = new GroupBox();
            Remaining_LB = new Label();
            label11 = new Label();
            EmailLogBox = new DataGridView();
            groupBox5 = new GroupBox();
            Scheduler_LB = new Label();
            Send_LB = new Label();
            label13 = new Label();
            label12 = new Label();
            groupBox4 = new GroupBox();
            Schedule_BTN = new Button();
            SendNow_BTN = new Button();
            label10 = new Label();
            Schedule_DateTime = new DateTimePicker();
            GenerateEmailLog_BTN = new Button();
            ClearEmailLog_BTN = new Button();
            EmailLogNotSent_BTN = new Button();
            groupBox3 = new GroupBox();
            Test_btn = new Button();
            label9 = new Label();
            label8 = new Label();
            ToEmail_TXT = new TextBox();
            ViewerName_TXT = new TextBox();
            PROPERTIES = new GroupBox();
            label7 = new Label();
            TableName_Combo = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            Attachment_BTN = new Button();
            Attachment_TXT = new TextBox();
            Browse_Template_BTN = new Button();
            Template_TXT = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            Subject_TXT = new TextBox();
            PresentationID_TXT = new TextBox();
            ExtRegID_TXT = new TextBox();
            ScheduleTimer = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).BeginInit();
            Details.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EmailLogBox).BeginInit();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            PROPERTIES.SuspendLayout();
            SuspendLayout();
            // 
            // CompanyBox
            // 
            CompanyBox.FormattingEnabled = true;
            CompanyBox.Location = new Point(81, 22);
            CompanyBox.Name = "CompanyBox";
            CompanyBox.Size = new Size(492, 23);
            CompanyBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(Search_btn);
            groupBox1.Controls.Add(CompanyBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(579, 746);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Company Events";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(63, 17);
            label1.TabIndex = 3;
            label1.Text = "Company";
            // 
            // groupBox2
            // 
            groupBox2.BackgroundImageLayout = ImageLayout.None;
            groupBox2.Controls.Add(dataGridViewEvents);
            groupBox2.Location = new Point(6, 82);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(567, 658);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Events";
            // 
            // dataGridViewEvents
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEvents.Columns.AddRange(new DataGridViewColumn[] { ExtRegID, PresentationID, PresentationName });
            dataGridViewEvents.Location = new Point(6, 22);
            dataGridViewEvents.Name = "dataGridViewEvents";
            dataGridViewEvents.RowTemplate.Height = 25;
            dataGridViewEvents.Size = new Size(555, 630);
            dataGridViewEvents.TabIndex = 0;
            // 
            // ExtRegID
            // 
            ExtRegID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ExtRegID.HeaderText = "ExtRegID";
            ExtRegID.Name = "ExtRegID";
            // 
            // PresentationID
            // 
            PresentationID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PresentationID.HeaderText = "PresentationID";
            PresentationID.Name = "PresentationID";
            // 
            // PresentationName
            // 
            PresentationName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PresentationName.HeaderText = "PresentationName";
            PresentationName.Name = "PresentationName";
            // 
            // Search_btn
            // 
            Search_btn.BackColor = SystemColors.ControlLight;
            Search_btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Search_btn.Location = new Point(481, 51);
            Search_btn.Name = "Search_btn";
            Search_btn.Size = new Size(92, 25);
            Search_btn.TabIndex = 1;
            Search_btn.Text = "Search";
            Search_btn.UseVisualStyleBackColor = false;
            Search_btn.Click += Search_btn_Click;
            // 
            // Details
            // 
            Details.Controls.Add(groupBox6);
            Details.Controls.Add(groupBox5);
            Details.Controls.Add(groupBox4);
            Details.Controls.Add(GenerateEmailLog_BTN);
            Details.Controls.Add(ClearEmailLog_BTN);
            Details.Controls.Add(EmailLogNotSent_BTN);
            Details.Controls.Add(groupBox3);
            Details.Controls.Add(PROPERTIES);
            Details.Location = new Point(597, 12);
            Details.Name = "Details";
            Details.Size = new Size(675, 740);
            Details.TabIndex = 2;
            Details.TabStop = false;
            Details.Text = "Details";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(Remaining_LB);
            groupBox6.Controls.Add(label11);
            groupBox6.Controls.Add(EmailLogBox);
            groupBox6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox6.Location = new Point(6, 480);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(663, 254);
            groupBox6.TabIndex = 23;
            groupBox6.TabStop = false;
            groupBox6.Text = "EMAIL LOG";
            // 
            // Remaining_LB
            // 
            Remaining_LB.AutoSize = true;
            Remaining_LB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Remaining_LB.Location = new Point(242, 21);
            Remaining_LB.Name = "Remaining_LB";
            Remaining_LB.Size = new Size(17, 17);
            Remaining_LB.TabIndex = 20;
            Remaining_LB.Text = "...";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(49, 21);
            label11.Name = "label11";
            label11.Size = new Size(173, 17);
            label11.TabIndex = 1;
            label11.Text = "Remaining Emails to be sent";
            // 
            // EmailLogBox
            // 
            EmailLogBox.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            EmailLogBox.DefaultCellStyle = dataGridViewCellStyle2;
            EmailLogBox.Location = new Point(6, 50);
            EmailLogBox.Name = "EmailLogBox";
            EmailLogBox.RowTemplate.Height = 25;
            EmailLogBox.Size = new Size(651, 193);
            EmailLogBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(Scheduler_LB);
            groupBox5.Controls.Add(Send_LB);
            groupBox5.Controls.Add(label13);
            groupBox5.Controls.Add(label12);
            groupBox5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox5.Location = new Point(381, 386);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(288, 88);
            groupBox5.TabIndex = 22;
            groupBox5.TabStop = false;
            groupBox5.Text = "STATUS";
            // 
            // Scheduler_LB
            // 
            Scheduler_LB.AutoSize = true;
            Scheduler_LB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Scheduler_LB.Location = new Point(119, 32);
            Scheduler_LB.Name = "Scheduler_LB";
            Scheduler_LB.Size = new Size(16, 15);
            Scheduler_LB.TabIndex = 18;
            Scheduler_LB.Text = "...";
            // 
            // Send_LB
            // 
            Send_LB.AutoSize = true;
            Send_LB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Send_LB.Location = new Point(119, 59);
            Send_LB.Name = "Send_LB";
            Send_LB.Size = new Size(16, 15);
            Send_LB.TabIndex = 19;
            Send_LB.Text = "...";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(6, 32);
            label13.Name = "label13";
            label13.Size = new Size(107, 17);
            label13.TabIndex = 19;
            label13.Text = "Scheduler Status:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(6, 61);
            label12.Name = "label12";
            label12.Size = new Size(79, 17);
            label12.TabIndex = 18;
            label12.Text = "Send Status:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(Schedule_BTN);
            groupBox4.Controls.Add(SendNow_BTN);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(Schedule_DateTime);
            groupBox4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox4.Location = new Point(6, 386);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(369, 88);
            groupBox4.TabIndex = 21;
            groupBox4.TabStop = false;
            groupBox4.Text = "SHEDULE AND SEND";
            // 
            // Schedule_BTN
            // 
            Schedule_BTN.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Schedule_BTN.Location = new Point(107, 55);
            Schedule_BTN.Name = "Schedule_BTN";
            Schedule_BTN.Size = new Size(129, 23);
            Schedule_BTN.TabIndex = 18;
            Schedule_BTN.Text = "Start Schedule Timer";
            Schedule_BTN.UseVisualStyleBackColor = true;
            Schedule_BTN.Click += Schedule_BTN_Click;
            // 
            // SendNow_BTN
            // 
            SendNow_BTN.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SendNow_BTN.Location = new Point(242, 55);
            SendNow_BTN.Name = "SendNow_BTN";
            SendNow_BTN.Size = new Size(108, 23);
            SendNow_BTN.TabIndex = 19;
            SendNow_BTN.Text = "Send Now";
            SendNow_BTN.UseVisualStyleBackColor = true;
            SendNow_BTN.Click += SendNow_BTN_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(6, 26);
            label10.Name = "label10";
            label10.Size = new Size(95, 17);
            label10.TabIndex = 18;
            label10.Text = "Schedule Time:";
            // 
            // Schedule_DateTime
            // 
            Schedule_DateTime.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Schedule_DateTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            Schedule_DateTime.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Schedule_DateTime.Format = DateTimePickerFormat.Custom;
            Schedule_DateTime.Location = new Point(107, 26);
            Schedule_DateTime.Name = "Schedule_DateTime";
            Schedule_DateTime.Size = new Size(243, 23);
            Schedule_DateTime.TabIndex = 0;
            Schedule_DateTime.ValueChanged += Schedule_DateTime_ValueChanged;
            // 
            // GenerateEmailLog_BTN
            // 
            GenerateEmailLog_BTN.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            GenerateEmailLog_BTN.Location = new Point(182, 357);
            GenerateEmailLog_BTN.Name = "GenerateEmailLog_BTN";
            GenerateEmailLog_BTN.Size = new Size(118, 23);
            GenerateEmailLog_BTN.TabIndex = 20;
            GenerateEmailLog_BTN.Text = "Generate Email Log";
            GenerateEmailLog_BTN.UseVisualStyleBackColor = true;
            GenerateEmailLog_BTN.Click += GenerateEmailLog_BTN_Click;
            // 
            // ClearEmailLog_BTN
            // 
            ClearEmailLog_BTN.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ClearEmailLog_BTN.Location = new Point(306, 357);
            ClearEmailLog_BTN.Name = "ClearEmailLog_BTN";
            ClearEmailLog_BTN.Size = new Size(126, 23);
            ClearEmailLog_BTN.TabIndex = 19;
            ClearEmailLog_BTN.Text = "Clear Email Log";
            ClearEmailLog_BTN.UseVisualStyleBackColor = true;
            ClearEmailLog_BTN.Click += ClearEmailLog_BTN_Click;
            // 
            // EmailLogNotSent_BTN
            // 
            EmailLogNotSent_BTN.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            EmailLogNotSent_BTN.Location = new Point(12, 357);
            EmailLogNotSent_BTN.Name = "EmailLogNotSent_BTN";
            EmailLogNotSent_BTN.Size = new Size(164, 23);
            EmailLogNotSent_BTN.TabIndex = 18;
            EmailLogNotSent_BTN.Text = "Get Email Log (Not Sent)";
            EmailLogNotSent_BTN.UseVisualStyleBackColor = true;
            EmailLogNotSent_BTN.Click += EmailLogNotSent_BTN_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(Test_btn);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(ToEmail_TXT);
            groupBox3.Controls.Add(ViewerName_TXT);
            groupBox3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(6, 233);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(663, 118);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "TEST";
            // 
            // Test_btn
            // 
            Test_btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Test_btn.Location = new Point(517, 86);
            Test_btn.Name = "Test_btn";
            Test_btn.Size = new Size(140, 23);
            Test_btn.TabIndex = 4;
            Test_btn.Text = "Prepare a Test";
            Test_btn.UseVisualStyleBackColor = true;
            Test_btn.Click += Test_btn_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(6, 58);
            label9.Name = "label9";
            label9.Size = new Size(60, 17);
            label9.TabIndex = 17;
            label9.Text = "To Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(6, 27);
            label8.Name = "label8";
            label8.Size = new Size(89, 17);
            label8.TabIndex = 15;
            label8.Text = "Viewer Name:";
            // 
            // ToEmail_TXT
            // 
            ToEmail_TXT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ToEmail_TXT.Location = new Point(107, 55);
            ToEmail_TXT.Name = "ToEmail_TXT";
            ToEmail_TXT.Size = new Size(550, 25);
            ToEmail_TXT.TabIndex = 16;
            // 
            // ViewerName_TXT
            // 
            ViewerName_TXT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ViewerName_TXT.Location = new Point(107, 24);
            ViewerName_TXT.Name = "ViewerName_TXT";
            ViewerName_TXT.Size = new Size(550, 25);
            ViewerName_TXT.TabIndex = 15;
            // 
            // PROPERTIES
            // 
            PROPERTIES.Controls.Add(label7);
            PROPERTIES.Controls.Add(TableName_Combo);
            PROPERTIES.Controls.Add(label6);
            PROPERTIES.Controls.Add(label5);
            PROPERTIES.Controls.Add(Attachment_BTN);
            PROPERTIES.Controls.Add(Attachment_TXT);
            PROPERTIES.Controls.Add(Browse_Template_BTN);
            PROPERTIES.Controls.Add(Template_TXT);
            PROPERTIES.Controls.Add(label4);
            PROPERTIES.Controls.Add(label3);
            PROPERTIES.Controls.Add(label2);
            PROPERTIES.Controls.Add(Subject_TXT);
            PROPERTIES.Controls.Add(PresentationID_TXT);
            PROPERTIES.Controls.Add(ExtRegID_TXT);
            PROPERTIES.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            PROPERTIES.Location = new Point(6, 22);
            PROPERTIES.Name = "PROPERTIES";
            PROPERTIES.Size = new Size(663, 205);
            PROPERTIES.TabIndex = 0;
            PROPERTIES.TabStop = false;
            PROPERTIES.Text = "PROPERTIES";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(6, 168);
            label7.Name = "label7";
            label7.Size = new Size(81, 17);
            label7.TabIndex = 14;
            label7.Text = "Table Name:";
            // 
            // TableName_Combo
            // 
            TableName_Combo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            TableName_Combo.FormattingEnabled = true;
            TableName_Combo.Location = new Point(107, 167);
            TableName_Combo.Name = "TableName_Combo";
            TableName_Combo.Size = new Size(550, 25);
            TableName_Combo.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(6, 140);
            label6.Name = "label6";
            label6.Size = new Size(76, 17);
            label6.TabIndex = 12;
            label6.Text = "Attachment:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(6, 111);
            label5.Name = "label5";
            label5.Size = new Size(64, 17);
            label5.TabIndex = 11;
            label5.Text = "Template:";
            // 
            // Attachment_BTN
            // 
            Attachment_BTN.Location = new Point(623, 138);
            Attachment_BTN.Name = "Attachment_BTN";
            Attachment_BTN.Size = new Size(34, 23);
            Attachment_BTN.TabIndex = 10;
            Attachment_BTN.Text = ". . .";
            Attachment_BTN.UseVisualStyleBackColor = true;
            Attachment_BTN.Click += Attachment_BTN_Click;
            // 
            // Attachment_TXT
            // 
            Attachment_TXT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Attachment_TXT.Location = new Point(107, 138);
            Attachment_TXT.Name = "Attachment_TXT";
            Attachment_TXT.Size = new Size(510, 25);
            Attachment_TXT.TabIndex = 9;
            // 
            // Browse_Template_BTN
            // 
            Browse_Template_BTN.Location = new Point(623, 109);
            Browse_Template_BTN.Name = "Browse_Template_BTN";
            Browse_Template_BTN.Size = new Size(34, 23);
            Browse_Template_BTN.TabIndex = 8;
            Browse_Template_BTN.Text = ". . .";
            Browse_Template_BTN.UseVisualStyleBackColor = true;
            Browse_Template_BTN.Click += Browse_Template_BTN_Click;
            // 
            // Template_TXT
            // 
            Template_TXT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Template_TXT.Location = new Point(107, 109);
            Template_TXT.Name = "Template_TXT";
            Template_TXT.Size = new Size(510, 25);
            Template_TXT.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 81);
            label4.Name = "label4";
            label4.Size = new Size(53, 17);
            label4.TabIndex = 6;
            label4.Text = "Subject:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 52);
            label3.Name = "label3";
            label3.Size = new Size(95, 17);
            label3.TabIndex = 5;
            label3.Text = "PresentationID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 23);
            label2.Name = "label2";
            label2.Size = new Size(63, 17);
            label2.TabIndex = 4;
            label2.Text = "ExtRegID:";
            // 
            // Subject_TXT
            // 
            Subject_TXT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Subject_TXT.Location = new Point(107, 80);
            Subject_TXT.Name = "Subject_TXT";
            Subject_TXT.Size = new Size(550, 25);
            Subject_TXT.TabIndex = 2;
            Subject_TXT.Text = "Reminder";
            // 
            // PresentationID_TXT
            // 
            PresentationID_TXT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            PresentationID_TXT.Location = new Point(107, 51);
            PresentationID_TXT.Name = "PresentationID_TXT";
            PresentationID_TXT.Size = new Size(550, 25);
            PresentationID_TXT.TabIndex = 1;
            // 
            // ExtRegID_TXT
            // 
            ExtRegID_TXT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ExtRegID_TXT.Location = new Point(107, 22);
            ExtRegID_TXT.Name = "ExtRegID_TXT";
            ExtRegID_TXT.Size = new Size(550, 25);
            ExtRegID_TXT.TabIndex = 0;
            // 
            // ScheduleTimer
            // 
            ScheduleTimer.Tick += ScheduleTimer_Tick;
            // 
            // Mail_Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 763);
            Controls.Add(Details);
            Controls.Add(groupBox1);
            Name = "Mail_Manager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mail Manager";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).EndInit();
            Details.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)EmailLogBox).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            PROPERTIES.ResumeLayout(false);
            PROPERTIES.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CompanyBox;
        private GroupBox groupBox1;
        private GroupBox Details;
        private GroupBox groupBox2;
        private DataGridView dataGridViewEvents;
        private Button Search_btn;
        private GroupBox PROPERTIES;
        private Label label1;
        private DataGridViewTextBoxColumn ExtRegID;
        private DataGridViewTextBoxColumn PresentationID;
        private DataGridViewTextBoxColumn PresentationName;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox Subject_TXT;
        private TextBox PresentationID_TXT;
        private TextBox ExtRegID_TXT;
        private TextBox Template_TXT;
        private Button Attachment_BTN;
        private TextBox Attachment_TXT;
        private Button Browse_Template_BTN;
        private Label label7;
        private ComboBox TableName_Combo;
        private Label label6;
        private Label label5;
        private GroupBox groupBox3;
        private Label label9;
        private Label label8;
        private TextBox ToEmail_TXT;
        private TextBox ViewerName_TXT;
        private Button Test_btn;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private DateTimePicker Schedule_DateTime;
        private Button GenerateEmailLog_BTN;
        private Button ClearEmailLog_BTN;
        private Button EmailLogNotSent_BTN;
        private Button Schedule_BTN;
        private Button SendNow_BTN;
        private Label label10;
        private System.Windows.Forms.Timer ScheduleTimer;
        private GroupBox groupBox6;
        private Label Remaining_LB;
        private Label label11;
        private DataGridView EmailLogBox;
        private Label Scheduler_LB;
        private Label Send_LB;
        private Label label13;
        private Label label12;
    }
}