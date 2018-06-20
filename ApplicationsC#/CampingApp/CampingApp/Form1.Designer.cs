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
            this.buttonReserve = new System.Windows.Forms.Button();
            this.buttonADDTent = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.tabPageReserve = new System.Windows.Forms.TabPage();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbResStatus = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBoxTentSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSpotNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCampID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageAddTent = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StatusTent = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxtent = new System.Windows.Forms.TextBox();
            this.buttonTent = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageCheckIn.SuspendLayout();
            this.tabPageReserve.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPageAddTent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCheckIn);
            this.tabControl1.Controls.Add(this.tabPageReserve);
            this.tabControl1.Controls.Add(this.tabPageAddTent);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(92, 27);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(983, 572);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageCheckIn
            // 
            this.tabPageCheckIn.BackColor = System.Drawing.Color.LightBlue;
            this.tabPageCheckIn.Controls.Add(this.buttonReserve);
            this.tabPageCheckIn.Controls.Add(this.buttonADDTent);
            this.tabPageCheckIn.Controls.Add(this.labelInfo);
            this.tabPageCheckIn.Controls.Add(this.buttonCheck);
            this.tabPageCheckIn.Location = new System.Drawing.Point(4, 31);
            this.tabPageCheckIn.Name = "tabPageCheckIn";
            this.tabPageCheckIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCheckIn.Size = new System.Drawing.Size(975, 537);
            this.tabPageCheckIn.TabIndex = 0;
            this.tabPageCheckIn.Text = "CHECKIN";
            // 
            // buttonReserve
            // 
            this.buttonReserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReserve.Location = new System.Drawing.Point(23, 160);
            this.buttonReserve.Name = "buttonReserve";
            this.buttonReserve.Size = new System.Drawing.Size(249, 175);
            this.buttonReserve.TabIndex = 12;
            this.buttonReserve.Text = "Reserve";
            this.buttonReserve.UseVisualStyleBackColor = true;
            this.buttonReserve.Click += new System.EventHandler(this.buttonReserve_Click);
            // 
            // buttonADDTent
            // 
            this.buttonADDTent.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonADDTent.Location = new System.Drawing.Point(698, 157);
            this.buttonADDTent.Name = "buttonADDTent";
            this.buttonADDTent.Size = new System.Drawing.Size(249, 178);
            this.buttonADDTent.TabIndex = 11;
            this.buttonADDTent.Text = "ADD Tent";
            this.buttonADDTent.UseVisualStyleBackColor = true;
            this.buttonADDTent.Click += new System.EventHandler(this.buttonADDTent_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(325, 18);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 31);
            this.labelInfo.TabIndex = 10;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheck.Location = new System.Drawing.Point(318, 140);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(330, 212);
            this.buttonCheck.TabIndex = 7;
            this.buttonCheck.Text = "CHECKIN";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
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
            this.tabPageReserve.Size = new System.Drawing.Size(975, 537);
            this.tabPageReserve.TabIndex = 1;
            this.tabPageReserve.Text = "RESERVE";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsert.Location = new System.Drawing.Point(2, 438);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(958, 93);
            this.buttonInsert.TabIndex = 8;
            this.buttonInsert.Text = "RESERVE";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox4.Controls.Add(this.lbResStatus);
            this.groupBox4.Controls.Add(this.lbStatus);
            this.groupBox4.Controls.Add(this.listBox1);
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
            // lbResStatus
            // 
            this.lbResStatus.AutoSize = true;
            this.lbResStatus.Location = new System.Drawing.Point(600, 119);
            this.lbResStatus.Name = "lbResStatus";
            this.lbResStatus.Size = new System.Drawing.Size(0, 31);
            this.lbResStatus.TabIndex = 13;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(600, 66);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 31);
            this.lbStatus.TabIndex = 12;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 30;
            this.listBox1.Location = new System.Drawing.Point(7, 66);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(551, 334);
            this.listBox1.TabIndex = 11;
            // 
            // textBoxTentSize
            // 
            this.textBoxTentSize.Location = new System.Drawing.Point(820, 363);
            this.textBoxTentSize.Name = "textBoxTentSize";
            this.textBoxTentSize.Size = new System.Drawing.Size(100, 37);
            this.textBoxTentSize.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(600, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tent size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Spots #";
            // 
            // textBoxSpotNo
            // 
            this.textBoxSpotNo.Location = new System.Drawing.Point(820, 278);
            this.textBoxSpotNo.Name = "textBoxSpotNo";
            this.textBoxSpotNo.Size = new System.Drawing.Size(100, 37);
            this.textBoxSpotNo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Camping #";
            // 
            // textBoxCampID
            // 
            this.textBoxCampID.Location = new System.Drawing.Point(820, 199);
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
            // tabPageAddTent
            // 
            this.tabPageAddTent.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.tabPageAddTent.Controls.Add(this.groupBox1);
            this.tabPageAddTent.Location = new System.Drawing.Point(4, 31);
            this.tabPageAddTent.Name = "tabPageAddTent";
            this.tabPageAddTent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddTent.Size = new System.Drawing.Size(975, 537);
            this.tabPageAddTent.TabIndex = 2;
            this.tabPageAddTent.Text = "ADD TENT";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.StatusTent);
            this.groupBox1.Controls.Add(this.Status);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxtent);
            this.groupBox1.Controls.Add(this.buttonTent);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(963, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // StatusTent
            // 
            this.StatusTent.AutoSize = true;
            this.StatusTent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTent.Location = new System.Drawing.Point(622, 113);
            this.StatusTent.Name = "StatusTent";
            this.StatusTent.Size = new System.Drawing.Size(0, 31);
            this.StatusTent.TabIndex = 15;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(622, 47);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 31);
            this.Status.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 31);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tent size";
            // 
            // textBoxtent
            // 
            this.textBoxtent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxtent.Location = new System.Drawing.Point(178, 71);
            this.textBoxtent.Multiline = true;
            this.textBoxtent.Name = "textBoxtent";
            this.textBoxtent.Size = new System.Drawing.Size(93, 58);
            this.textBoxtent.TabIndex = 12;
            this.textBoxtent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonTent
            // 
            this.buttonTent.Location = new System.Drawing.Point(307, 71);
            this.buttonTent.Name = "buttonTent";
            this.buttonTent.Size = new System.Drawing.Size(273, 58);
            this.buttonTent.TabIndex = 11;
            this.buttonTent.Text = "ADD ONLY TENT";
            this.buttonTent.UseVisualStyleBackColor = true;
            this.buttonTent.Click += new System.EventHandler(this.buttonTent_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(378, 31);
            this.label6.TabIndex = 16;
            this.label6.Text = "Choose between sizes: 2, 4, 6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1010, 596);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCheckIn.ResumeLayout(false);
            this.tabPageCheckIn.PerformLayout();
            this.tabPageReserve.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageAddTent.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCheckIn;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.TabPage tabPageReserve;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSpotNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCampID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTentSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPageAddTent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxtent;
        private System.Windows.Forms.Button buttonTent;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label lbResStatus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button buttonReserve;
        private System.Windows.Forms.Button buttonADDTent;
        private System.Windows.Forms.Label StatusTent;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label6;
    }
}

