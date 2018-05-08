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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbFavoriteItem = new System.Windows.Forms.Label();
            this.lbBalance = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbRentItems = new System.Windows.Forms.Label();
            this.lbSugest = new System.Windows.Forms.Label();
            this.tbSuggest = new System.Windows.Forms.TextBox();
            this.lsOfWantedFeatures = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbPay = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.ItemHeight = 16;
            this.lstItems.Location = new System.Drawing.Point(12, 51);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(159, 324);
            this.lstItems.TabIndex = 0;
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
            this.label1.Location = new System.Drawing.Point(455, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "CreditBalance:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(455, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number Of Rented Items:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Favorite Item:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbFavoriteItem
            // 
            this.lbFavoriteItem.AutoSize = true;
            this.lbFavoriteItem.Location = new System.Drawing.Point(561, 217);
            this.lbFavoriteItem.Name = "lbFavoriteItem";
            this.lbFavoriteItem.Size = new System.Drawing.Size(31, 17);
            this.lbFavoriteItem.TabIndex = 10;
            this.lbFavoriteItem.Text = "N/A";
            this.lbFavoriteItem.Click += new System.EventHandler(this.lbFavoriteItem_Click);
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.Location = new System.Drawing.Point(561, 181);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(31, 17);
            this.lbBalance.TabIndex = 11;
            this.lbBalance.Text = "N/A";
            this.lbBalance.Click += new System.EventHandler(this.lbBalance_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(510, 150);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(69, 17);
            this.lbName.TabIndex = 12;
            this.lbName.Text = "Jane Doe";
            this.lbName.Click += new System.EventHandler(this.lbName_Click);
            // 
            // lbRentItems
            // 
            this.lbRentItems.AutoSize = true;
            this.lbRentItems.Location = new System.Drawing.Point(629, 248);
            this.lbRentItems.Name = "lbRentItems";
            this.lbRentItems.Size = new System.Drawing.Size(16, 17);
            this.lbRentItems.TabIndex = 13;
            this.lbRentItems.Text = "0";
            this.lbRentItems.Click += new System.EventHandler(this.lbRentItems_Click);
            // 
            // lbSugest
            // 
            this.lbSugest.AutoSize = true;
            this.lbSugest.Location = new System.Drawing.Point(455, 65);
            this.lbSugest.Name = "lbSugest";
            this.lbSugest.Size = new System.Drawing.Size(106, 17);
            this.lbSugest.TabIndex = 14;
            this.lbSugest.Text = "Sugest an Item:";
            this.lbSugest.Click += new System.EventHandler(this.lbSugest_Click);
            // 
            // tbSuggest
            // 
            this.tbSuggest.Location = new System.Drawing.Point(458, 89);
            this.tbSuggest.Name = "tbSuggest";
            this.tbSuggest.Size = new System.Drawing.Size(143, 22);
            this.tbSuggest.TabIndex = 15;
            this.tbSuggest.TextChanged += new System.EventHandler(this.tbSuggest_TextChanged);
            // 
            // lsOfWantedFeatures
            // 
            this.lsOfWantedFeatures.FormattingEnabled = true;
            this.lsOfWantedFeatures.ItemHeight = 16;
            this.lsOfWantedFeatures.Location = new System.Drawing.Point(290, 51);
            this.lsOfWantedFeatures.Name = "lsOfWantedFeatures";
            this.lsOfWantedFeatures.Size = new System.Drawing.Size(159, 308);
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
            this.label6.Location = new System.Drawing.Point(697, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Amount to pay:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lbPay
            // 
            this.lbPay.AutoSize = true;
            this.lbPay.Location = new System.Drawing.Point(806, 274);
            this.lbPay.Name = "lbPay";
            this.lbPay.Size = new System.Drawing.Size(16, 17);
            this.lbPay.TabIndex = 20;
            this.lbPay.Text = "0";
            this.lbPay.Click += new System.EventHandler(this.lbPay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.PaleGreen;
            this.btnCancel.Location = new System.Drawing.Point(184, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 46);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel Order";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(700, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Item Value:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(700, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Item Size:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(667, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "Item Image:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(632, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(876, 383);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbPay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lsOfWantedFeatures);
            this.Controls.Add(this.tbSuggest);
            this.Controls.Add(this.lbSugest);
            this.Controls.Add(this.lbRentItems);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbBalance);
            this.Controls.Add(this.lbFavoriteItem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstItems);
            this.Name = "Form1";
            this.Text = "LoaningApplication";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbFavoriteItem;
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbRentItems;
        private System.Windows.Forms.Label lbSugest;
        private System.Windows.Forms.TextBox tbSuggest;
        private System.Windows.Forms.ListBox lsOfWantedFeatures;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbPay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

