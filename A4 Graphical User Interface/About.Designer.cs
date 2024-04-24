namespace A4_Graphical_User_Interface
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.employee_button = new FontAwesome.Sharp.IconButton();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.animal_button = new FontAwesome.Sharp.IconButton();
            this.logout_button = new FontAwesome.Sharp.IconButton();
            this.report_button = new FontAwesome.Sharp.IconButton();
            this.about_button = new FontAwesome.Sharp.IconButton();
            this.dashboard_button = new FontAwesome.Sharp.IconButton();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(224)))), ((int)(((byte)(214)))));
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Location = new System.Drawing.Point(363, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1491, 924);
            this.panel5.TabIndex = 14;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(819, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(670, 720);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.label1.Location = new System.Drawing.Point(53, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 40);
            this.label1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(3, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 608);
            this.panel2.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Uighur", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(724, 446);
            this.label2.TabIndex = 18;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Swis721 Blk BT", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.label10.Location = new System.Drawing.Point(110, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(547, 56);
            this.label10.TabIndex = 13;
            this.label10.Text = "About FurEver Home";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.employee_button);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.animal_button);
            this.panel1.Controls.Add(this.logout_button);
            this.panel1.Controls.Add(this.report_button);
            this.panel1.Controls.Add(this.about_button);
            this.panel1.Controls.Add(this.dashboard_button);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 1080);
            this.panel1.TabIndex = 15;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Swis721 Blk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Donate;
            this.iconButton2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(224)))), ((int)(((byte)(214)))));
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 50;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(26, 619);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(258, 72);
            this.iconButton2.TabIndex = 26;
            this.iconButton2.Text = "              Donations";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // employee_button
            // 
            this.employee_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.employee_button.FlatAppearance.BorderSize = 0;
            this.employee_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employee_button.Font = new System.Drawing.Font("Swis721 Blk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_button.ForeColor = System.Drawing.Color.White;
            this.employee_button.IconChar = FontAwesome.Sharp.IconChar.User;
            this.employee_button.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(224)))), ((int)(((byte)(214)))));
            this.employee_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.employee_button.IconSize = 50;
            this.employee_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employee_button.Location = new System.Drawing.Point(26, 380);
            this.employee_button.Name = "employee_button";
            this.employee_button.Size = new System.Drawing.Size(258, 73);
            this.employee_button.TabIndex = 24;
            this.employee_button.Text = "         Employee";
            this.employee_button.UseVisualStyleBackColor = false;
            this.employee_button.Click += new System.EventHandler(this.employee_button_Click_1);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(300, 170);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 20;
            this.pictureBox5.TabStop = false;
            // 
            // animal_button
            // 
            this.animal_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.animal_button.FlatAppearance.BorderSize = 0;
            this.animal_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.animal_button.Font = new System.Drawing.Font("Swis721 Blk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animal_button.ForeColor = System.Drawing.Color.White;
            this.animal_button.IconChar = FontAwesome.Sharp.IconChar.Paw;
            this.animal_button.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(224)))), ((int)(((byte)(214)))));
            this.animal_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.animal_button.IconSize = 50;
            this.animal_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.animal_button.Location = new System.Drawing.Point(26, 459);
            this.animal_button.Name = "animal_button";
            this.animal_button.Size = new System.Drawing.Size(258, 72);
            this.animal_button.TabIndex = 19;
            this.animal_button.Text = "              Animals";
            this.animal_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.animal_button.UseVisualStyleBackColor = false;
            this.animal_button.Click += new System.EventHandler(this.animal_button_Click_1);
            // 
            // logout_button
            // 
            this.logout_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.logout_button.FlatAppearance.BorderSize = 0;
            this.logout_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_button.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.logout_button.Font = new System.Drawing.Font("Swis721 Blk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_button.ForeColor = System.Drawing.Color.White;
            this.logout_button.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.logout_button.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(224)))), ((int)(((byte)(214)))));
            this.logout_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.logout_button.IconSize = 50;
            this.logout_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout_button.Location = new System.Drawing.Point(26, 940);
            this.logout_button.Name = "logout_button";
            this.logout_button.Size = new System.Drawing.Size(258, 73);
            this.logout_button.TabIndex = 18;
            this.logout_button.Text = "     Log-out";
            this.logout_button.UseVisualStyleBackColor = false;
            this.logout_button.Click += new System.EventHandler(this.logout_button_Click_1);
            // 
            // report_button
            // 
            this.report_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.report_button.FlatAppearance.BorderSize = 0;
            this.report_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.report_button.Font = new System.Drawing.Font("Swis721 Blk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_button.ForeColor = System.Drawing.Color.White;
            this.report_button.IconChar = FontAwesome.Sharp.IconChar.House;
            this.report_button.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(224)))), ((int)(((byte)(214)))));
            this.report_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.report_button.IconSize = 50;
            this.report_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.report_button.Location = new System.Drawing.Point(26, 540);
            this.report_button.Name = "report_button";
            this.report_button.Size = new System.Drawing.Size(248, 73);
            this.report_button.TabIndex = 17;
            this.report_button.Text = "              Animal \r\n              Adoption";
            this.report_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.report_button.UseVisualStyleBackColor = false;
            this.report_button.Click += new System.EventHandler(this.report_button_Click);
            // 
            // about_button
            // 
            this.about_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.about_button.FlatAppearance.BorderSize = 0;
            this.about_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.about_button.Font = new System.Drawing.Font("Swis721 Blk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about_button.ForeColor = System.Drawing.Color.White;
            this.about_button.IconChar = FontAwesome.Sharp.IconChar.BookOpenReader;
            this.about_button.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(224)))), ((int)(((byte)(214)))));
            this.about_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.about_button.IconSize = 50;
            this.about_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.about_button.Location = new System.Drawing.Point(26, 301);
            this.about_button.Name = "about_button";
            this.about_button.Size = new System.Drawing.Size(258, 73);
            this.about_button.TabIndex = 16;
            this.about_button.Text = "   About";
            this.about_button.UseVisualStyleBackColor = false;
            this.about_button.Click += new System.EventHandler(this.about_button_Click_1);
            // 
            // dashboard_button
            // 
            this.dashboard_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.dashboard_button.FlatAppearance.BorderSize = 0;
            this.dashboard_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard_button.Font = new System.Drawing.Font("Swis721 Blk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_button.ForeColor = System.Drawing.Color.White;
            this.dashboard_button.IconChar = FontAwesome.Sharp.IconChar.Dashboard;
            this.dashboard_button.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(224)))), ((int)(((byte)(214)))));
            this.dashboard_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.dashboard_button.IconSize = 50;
            this.dashboard_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboard_button.Location = new System.Drawing.Point(26, 222);
            this.dashboard_button.Name = "dashboard_button";
            this.dashboard_button.Size = new System.Drawing.Size(258, 73);
            this.dashboard_button.TabIndex = 15;
            this.dashboard_button.Text = "          Dashboard";
            this.dashboard_button.UseVisualStyleBackColor = false;
            this.dashboard_button.Click += new System.EventHandler(this.dashboard_button_Click_1);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(224)))), ((int)(((byte)(214)))));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Name = "About";
            this.Text = "About";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton employee_button;
        private System.Windows.Forms.PictureBox pictureBox5;
        private FontAwesome.Sharp.IconButton animal_button;
        private FontAwesome.Sharp.IconButton logout_button;
        private FontAwesome.Sharp.IconButton report_button;
        private FontAwesome.Sharp.IconButton about_button;
        private FontAwesome.Sharp.IconButton dashboard_button;
    }
}