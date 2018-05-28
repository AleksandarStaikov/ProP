namespace LoaningApplicationProP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lstItems = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbRentItems = new System.Windows.Forms.Label();
            this.lbSugest = new System.Windows.Forms.Label();
            this.tbSuggest = new System.Windows.Forms.TextBox();
            this.lsOfWantedFeatures = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbPay = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSugestion = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lstOwned = new System.Windows.Forms.ListBox();
            this.glUser = new System.Windows.Forms.GroupBox();
            this.glItem = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.glUser.SuspendLayout();
            this.glItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.ItemHeight = 16;
            this.lstItems.Location = new System.Drawing.Point(12, 51);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(159, 260);
            this.lstItems.TabIndex = 0;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightGreen;
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(159, 33);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.PaleGreen;
            this.btnOrder.Location = new System.Drawing.Point(184, 65);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(100, 46);
            this.btnOrder.TabIndex = 3;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number Of Rented Items:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(64, 36);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(69, 17);
            this.lbName.TabIndex = 12;
            this.lbName.Text = "Jane Doe";
            // 
            // lbRentItems
            // 
            this.lbRentItems.AutoSize = true;
            this.lbRentItems.Location = new System.Drawing.Point(183, 92);
            this.lbRentItems.Name = "lbRentItems";
            this.lbRentItems.Size = new System.Drawing.Size(16, 17);
            this.lbRentItems.TabIndex = 13;
            this.lbRentItems.Text = "0";
            // 
            // lbSugest
            // 
            this.lbSugest.AutoSize = true;
            this.lbSugest.Location = new System.Drawing.Point(455, 51);
            this.lbSugest.Name = "lbSugest";
            this.lbSugest.Size = new System.Drawing.Size(106, 17);
            this.lbSugest.TabIndex = 14;
            this.lbSugest.Text = "Sugest an Item:";
            // 
            // tbSuggest
            // 
            this.tbSuggest.Location = new System.Drawing.Point(455, 71);
            this.tbSuggest.Name = "tbSuggest";
            this.tbSuggest.Size = new System.Drawing.Size(143, 22);
            this.tbSuggest.TabIndex = 15;
            // 
            // lsOfWantedFeatures
            // 
            this.lsOfWantedFeatures.FormattingEnabled = true;
            this.lsOfWantedFeatures.ItemHeight = 16;
            this.lsOfWantedFeatures.Location = new System.Drawing.Point(290, 51);
            this.lsOfWantedFeatures.Name = "lsOfWantedFeatures";
            this.lsOfWantedFeatures.Size = new System.Drawing.Size(159, 260);
            this.lsOfWantedFeatures.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Wanted Objects";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(315, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 29);
            this.label6.TabIndex = 19;
            this.label6.Text = "Amount to pay:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lbPay
            // 
            this.lbPay.AutoSize = true;
            this.lbPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPay.Location = new System.Drawing.Point(491, 522);
            this.lbPay.Name = "lbPay";
            this.lbPay.Size = new System.Drawing.Size(26, 29);
            this.lbPay.TabIndex = 20;
            this.lbPay.Text = "0";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.PaleGreen;
            this.btnReturn.Location = new System.Drawing.Point(177, 334);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 46);
            this.btnReturn.TabIndex = 22;
            this.btnReturn.Text = "Return Items";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Item Value:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Item Size:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "Item Image:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(47, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // btnSugestion
            // 
            this.btnSugestion.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSugestion.Location = new System.Drawing.Point(455, 99);
            this.btnSugestion.Name = "btnSugestion";
            this.btnSugestion.Size = new System.Drawing.Size(143, 37);
            this.btnSugestion.TabIndex = 27;
            this.btnSugestion.Text = "Add";
            this.btnSugestion.UseVisualStyleBackColor = false;
            this.btnSugestion.Click += new System.EventHandler(this.btnSugestion_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(117, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 17);
            this.label11.TabIndex = 29;
            this.label11.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 17);
            this.label12.TabIndex = 30;
            this.label12.Text = "Item Quantity:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(117, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 17);
            this.label13.TabIndex = 31;
            this.label13.Text = "0";
            // 
            // lstOwned
            // 
            this.lstOwned.FormattingEnabled = true;
            this.lstOwned.ItemHeight = 16;
            this.lstOwned.Location = new System.Drawing.Point(13, 334);
            this.lstOwned.Name = "lstOwned";
            this.lstOwned.Size = new System.Drawing.Size(158, 228);
            this.lstOwned.TabIndex = 32;
            // 
            // glUser
            // 
            this.glUser.Controls.Add(this.label3);
            this.glUser.Controls.Add(this.label1);
            this.glUser.Controls.Add(this.lbName);
            this.glUser.Controls.Add(this.lbRentItems);
            this.glUser.Location = new System.Drawing.Point(604, 334);
            this.glUser.Name = "glUser";
            this.glUser.Size = new System.Drawing.Size(205, 135);
            this.glUser.TabIndex = 33;
            this.glUser.TabStop = false;
            this.glUser.Text = "Visitor";
            // 
            // glItem
            // 
            this.glItem.Controls.Add(this.label9);
            this.glItem.Controls.Add(this.label8);
            this.glItem.Controls.Add(this.label7);
            this.glItem.Controls.Add(this.label13);
            this.glItem.Controls.Add(this.pictureBox1);
            this.glItem.Controls.Add(this.label11);
            this.glItem.Controls.Add(this.label10);
            this.glItem.Controls.Add(this.label12);
            this.glItem.Location = new System.Drawing.Point(604, 20);
            this.glItem.Name = "glItem";
            this.glItem.Size = new System.Drawing.Size(260, 299);
            this.glItem.TabIndex = 34;
            this.glItem.TabStop = false;
            this.glItem.Text = "Item";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(876, 581);
            this.Controls.Add(this.glItem);
            this.Controls.Add(this.glUser);
            this.Controls.Add(this.lstOwned);
            this.Controls.Add(this.btnSugestion);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lbPay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lsOfWantedFeatures);
            this.Controls.Add(this.tbSuggest);
            this.Controls.Add(this.lbSugest);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstItems);
            this.Name = "Form1";
            this.Text = "LoaningApplication";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.glUser.ResumeLayout(false);
            this.glUser.PerformLayout();
            this.glItem.ResumeLayout(false);
            this.glItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbFavoriteItem;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbRentItems;
        private System.Windows.Forms.Label lbSugest;
        private System.Windows.Forms.TextBox tbSuggest;
        private System.Windows.Forms.ListBox lsOfWantedFeatures;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbPay;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSugestion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox lstOwned;
        private System.Windows.Forms.GroupBox glUser;
        private System.Windows.Forms.GroupBox glItem;
    }
}

