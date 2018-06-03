namespace CampingApp
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCheckIn = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelCheckInfo = new System.Windows.Forms.Label();
            this.labelCheckStatus = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelName = new System.Windows.Forms.Label();
            this.tabPageReserve = new System.Windows.Forms.TabPage();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonTent = new System.Windows.Forms.Button();
            this.buttonShowSpots = new System.Windows.Forms.Button();
            this.textBoxTentSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSpotNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCampID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonCheckOut = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TentSize = new System.Windows.Forms.Label();
            this.CampNo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.VisitorInfo = new System.Windows.Forms.Label();
            this.labelStatusCheckOut = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageCheckIn.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageReserve.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCheckIn);
            this.tabControl1.Controls.Add(this.tabPageReserve);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(983, 569);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageCheckIn
            // 
            this.tabPageCheckIn.BackColor = System.Drawing.Color.LightBlue;
            this.tabPageCheckIn.Controls.Add(this.groupBox3);
            this.tabPageCheckIn.Controls.Add(this.buttonCheck);
            this.tabPageCheckIn.Controls.Add(this.groupBox1);
            this.tabPageCheckIn.Location = new System.Drawing.Point(4, 31);
            this.tabPageCheckIn.Name = "tabPageCheckIn";
            this.tabPageCheckIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCheckIn.Size = new System.Drawing.Size(975, 534);
            this.tabPageCheckIn.TabIndex = 0;
            this.tabPageCheckIn.Text = "CHECKIN";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox3.Controls.Add(this.labelCheckInfo);
            this.groupBox3.Controls.Add(this.labelCheckStatus);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(4, 177);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(782, 354);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Camping Info";
            // 
            // labelCheckInfo
            // 
            this.labelCheckInfo.AutoSize = true;
            this.labelCheckInfo.Location = new System.Drawing.Point(20, 110);
            this.labelCheckInfo.Name = "labelCheckInfo";
            this.labelCheckInfo.Size = new System.Drawing.Size(0, 31);
            this.labelCheckInfo.TabIndex = 7;
            // 
            // labelCheckStatus
            // 
            this.labelCheckStatus.AutoSize = true;
            this.labelCheckStatus.Location = new System.Drawing.Point(20, 57);
            this.labelCheckStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCheckStatus.Name = "labelCheckStatus";
            this.labelCheckStatus.Size = new System.Drawing.Size(0, 31);
            this.labelCheckStatus.TabIndex = 6;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheck.Location = new System.Drawing.Point(793, 3);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(171, 524);
            this.buttonCheck.TabIndex = 7;
            this.buttonCheck.Text = "CHECKIN";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(782, 166);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visitor Info";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 71);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 31);
            this.labelName.TabIndex = 0;
            // 
            // tabPageReserve
            // 
            this.tabPageReserve.BackColor = System.Drawing.Color.LightBlue;
            this.tabPageReserve.Controls.Add(this.buttonInsert);
            this.tabPageReserve.Controls.Add(this.groupBox4);
            this.tabPageReserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageReserve.Location = new System.Drawing.Point(4, 31);
            this.tabPageReserve.Name = "tabPageReserve";
            this.tabPageReserve.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReserve.Size = new System.Drawing.Size(975, 534);
            this.tabPageReserve.TabIndex = 1;
            this.tabPageReserve.Text = "RESERVE";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsert.Location = new System.Drawing.Point(3, 435);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(958, 93);
            this.buttonInsert.TabIndex = 8;
            this.buttonInsert.Text = "RESERVE";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Controls.Add(this.buttonTent);
            this.groupBox4.Controls.Add(this.buttonShowSpots);
            this.groupBox4.Controls.Add(this.textBoxTentSize);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.textBoxSpotNo);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.textBoxCampID);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(7, 7);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(953, 424);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reservation on the spot";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 30;
            this.listBox1.Location = new System.Drawing.Point(17, 83);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(551, 274);
            this.listBox1.TabIndex = 11;
            // 
            // buttonTent
            // 
            this.buttonTent.Location = new System.Drawing.Point(587, 299);
            this.buttonTent.Name = "buttonTent";
            this.buttonTent.Size = new System.Drawing.Size(348, 58);
            this.buttonTent.TabIndex = 10;
            this.buttonTent.Text = "ADD ONLY TENT";
            this.buttonTent.UseVisualStyleBackColor = true;
            this.buttonTent.Click += new System.EventHandler(this.buttonTent_Click);
            // 
            // buttonShowSpots
            // 
            this.buttonShowSpots.Location = new System.Drawing.Point(106, 363);
            this.buttonShowSpots.Name = "buttonShowSpots";
            this.buttonShowSpots.Size = new System.Drawing.Size(372, 55);
            this.buttonShowSpots.TabIndex = 8;
            this.buttonShowSpots.Text = "SHOW FREE SPOTS";
            this.buttonShowSpots.UseVisualStyleBackColor = true;
            this.buttonShowSpots.Click += new System.EventHandler(this.buttonShowSpots_Click);
            // 
            // textBoxTentSize
            // 
            this.textBoxTentSize.Location = new System.Drawing.Point(820, 231);
            this.textBoxTentSize.Name = "textBoxTentSize";
            this.textBoxTentSize.Size = new System.Drawing.Size(100, 37);
            this.textBoxTentSize.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(600, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tent size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Spots #";
            // 
            // textBoxSpotNo
            // 
            this.textBoxSpotNo.Location = new System.Drawing.Point(820, 156);
            this.textBoxSpotNo.Name = "textBoxSpotNo";
            this.textBoxSpotNo.Size = new System.Drawing.Size(100, 37);
            this.textBoxSpotNo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Camping #";
            // 
            // textBoxCampID
            // 
            this.textBoxCampID.Location = new System.Drawing.Point(820, 83);
            this.textBoxCampID.Name = "textBoxCampID";
            this.textBoxCampID.Size = new System.Drawing.Size(100, 37);
            this.textBoxCampID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Free Spots";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonCheckOut);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(975, 534);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "CHECKOUT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonCheckOut
            // 
            this.buttonCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheckOut.Location = new System.Drawing.Point(790, 3);
            this.buttonCheckOut.Name = "buttonCheckOut";
            this.buttonCheckOut.Size = new System.Drawing.Size(181, 524);
            this.buttonCheckOut.TabIndex = 11;
            this.buttonCheckOut.Text = "CHECKOUT";
            this.buttonCheckOut.UseVisualStyleBackColor = true;
            this.buttonCheckOut.Click += new System.EventHandler(this.buttonCheckOut_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox5.Controls.Add(this.labelStatusCheckOut);
            this.groupBox5.Controls.Add(this.TentSize);
            this.groupBox5.Controls.Add(this.CampNo);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(4, 173);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(782, 354);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Camping Info";
            // 
            // TentSize
            // 
            this.TentSize.AutoSize = true;
            this.TentSize.Location = new System.Drawing.Point(20, 110);
            this.TentSize.Name = "TentSize";
            this.TentSize.Size = new System.Drawing.Size(0, 31);
            this.TentSize.TabIndex = 7;
            // 
            // CampNo
            // 
            this.CampNo.AutoSize = true;
            this.CampNo.Location = new System.Drawing.Point(20, 57);
            this.CampNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CampNo.Name = "CampNo";
            this.CampNo.Size = new System.Drawing.Size(0, 31);
            this.CampNo.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox2.Controls.Add(this.VisitorInfo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(782, 166);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visitor Info";
            // 
            // VisitorInfo
            // 
            this.VisitorInfo.AutoSize = true;
            this.VisitorInfo.Location = new System.Drawing.Point(8, 71);
            this.VisitorInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VisitorInfo.Name = "VisitorInfo";
            this.VisitorInfo.Size = new System.Drawing.Size(0, 31);
            this.VisitorInfo.TabIndex = 0;
            // 
            // labelStatusCheckOut
            // 
            this.labelStatusCheckOut.AutoSize = true;
            this.labelStatusCheckOut.Location = new System.Drawing.Point(20, 166);
            this.labelStatusCheckOut.Name = "labelStatusCheckOut";
            this.labelStatusCheckOut.Size = new System.Drawing.Size(0, 31);
            this.labelStatusCheckOut.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(993, 577);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCheckIn.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageReserve.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCheckIn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelCheckStatus;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TabPage tabPageReserve;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelCheckInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSpotNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCampID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTentSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonShowSpots;
        private System.Windows.Forms.Button buttonTent;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonCheckOut;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label TentSize;
        private System.Windows.Forms.Label CampNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label VisitorInfo;
        private System.Windows.Forms.Label labelStatusCheckOut;
    }
}

