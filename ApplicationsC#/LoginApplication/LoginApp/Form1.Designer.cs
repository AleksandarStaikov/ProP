namespace LoginApp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.turonOnCamera = new System.Windows.Forms.Button();
            this.startScanning = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.stopScaning = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbNotify = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRegister = new System.Windows.Forms.Button();
            this.tbNewEmail = new System.Windows.Forms.TextBox();
            this.tbNewLName = new System.Windows.Forms.TextBox();
            this.tbNewFName = new System.Windows.Forms.TextBox();
            this.dtpNewBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbRegStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmNotification = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(8, 158);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(789, 405);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(456, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // turonOnCamera
            // 
            this.turonOnCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turonOnCamera.Location = new System.Drawing.Point(8, 65);
            this.turonOnCamera.Name = "turonOnCamera";
            this.turonOnCamera.Size = new System.Drawing.Size(168, 28);
            this.turonOnCamera.TabIndex = 3;
            this.turonOnCamera.Text = "Turn On The Camera";
            this.turonOnCamera.UseVisualStyleBackColor = true;
            this.turonOnCamera.Click += new System.EventHandler(this.button1_Click);
            // 
            // startScanning
            // 
            this.startScanning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startScanning.Location = new System.Drawing.Point(182, 65);
            this.startScanning.Name = "startScanning";
            this.startScanning.Size = new System.Drawing.Size(122, 28);
            this.startScanning.TabIndex = 4;
            this.startScanning.Text = "Start scaning";
            this.startScanning.UseVisualStyleBackColor = true;
            this.startScanning.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-193, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Status:";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(75, 38);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(176, 24);
            this.lbStatus.TabIndex = 6;
            this.lbStatus.Text = "Turn on the camera";
            // 
            // stopScaning
            // 
            this.stopScaning.Enabled = false;
            this.stopScaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopScaning.Location = new System.Drawing.Point(310, 65);
            this.stopScaning.Name = "stopScaning";
            this.stopScaning.Size = new System.Drawing.Size(120, 28);
            this.stopScaning.TabIndex = 7;
            this.stopScaning.Text = "Stop scaning";
            this.stopScaning.UseVisualStyleBackColor = true;
            this.stopScaning.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 595);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbNotify);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.stopScaning);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.lbStatus);
            this.tabPage1.Controls.Add(this.turonOnCamera);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.startScanning);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(808, 569);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Check In";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbNotify
            // 
            this.lbNotify.AutoSize = true;
            this.lbNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotify.Location = new System.Drawing.Point(8, 116);
            this.lbNotify.Name = "lbNotify";
            this.lbNotify.Size = new System.Drawing.Size(60, 24);
            this.lbNotify.TabIndex = 9;
            this.lbNotify.Text = "label4";
            this.lbNotify.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Status:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRegister);
            this.tabPage2.Controls.Add(this.tbNewEmail);
            this.tabPage2.Controls.Add(this.tbNewLName);
            this.tabPage2.Controls.Add(this.tbNewFName);
            this.tabPage2.Controls.Add(this.dtpNewBirthDate);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.lbRegStatus);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(808, 569);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Purchase";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(120, 234);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // tbNewEmail
            // 
            this.tbNewEmail.Location = new System.Drawing.Point(120, 142);
            this.tbNewEmail.Name = "tbNewEmail";
            this.tbNewEmail.Size = new System.Drawing.Size(200, 20);
            this.tbNewEmail.TabIndex = 9;
            // 
            // tbNewLName
            // 
            this.tbNewLName.Location = new System.Drawing.Point(120, 114);
            this.tbNewLName.Name = "tbNewLName";
            this.tbNewLName.Size = new System.Drawing.Size(200, 20);
            this.tbNewLName.TabIndex = 8;
            // 
            // tbNewFName
            // 
            this.tbNewFName.Location = new System.Drawing.Point(120, 82);
            this.tbNewFName.Name = "tbNewFName";
            this.tbNewFName.Size = new System.Drawing.Size(200, 20);
            this.tbNewFName.TabIndex = 7;
            // 
            // dtpNewBirthDate
            // 
            this.dtpNewBirthDate.Location = new System.Drawing.Point(120, 171);
            this.dtpNewBirthDate.Name = "dtpNewBirthDate";
            this.dtpNewBirthDate.Size = new System.Drawing.Size(200, 20);
            this.dtpNewBirthDate.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 18);
            this.label8.TabIndex = 5;
            this.label8.Text = "Birth date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Last name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "First name:";
            // 
            // lbRegStatus
            // 
            this.lbRegStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbRegStatus.AutoSize = true;
            this.lbRegStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegStatus.Location = new System.Drawing.Point(9, 36);
            this.lbRegStatus.Name = "lbRegStatus";
            this.lbRegStatus.Size = new System.Drawing.Size(129, 18);
            this.lbRegStatus.TabIndex = 1;
            this.lbRegStatus.Text = "Please fill the form";
            this.lbRegStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Register a new visitor";
            // 
            // tmNotification
            // 
            this.tmNotification.Interval = 2000;
            this.tmNotification.Tick += new System.EventHandler(this.tmNotification_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 591);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button turonOnCamera;
        private System.Windows.Forms.Button startScanning;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button stopScaning;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox tbNewEmail;
        private System.Windows.Forms.TextBox tbNewLName;
        private System.Windows.Forms.TextBox tbNewFName;
        private System.Windows.Forms.DateTimePicker dtpNewBirthDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbRegStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbNotify;
        private System.Windows.Forms.Timer tmNotification;
    }
}

