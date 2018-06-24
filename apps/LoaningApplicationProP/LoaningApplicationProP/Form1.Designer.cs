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
            this.btnOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbRentItems = new System.Windows.Forms.Label();
            this.lbSugest = new System.Windows.Forms.Label();
            this.tbSuggest = new System.Windows.Forms.TextBox();
            this.lsOfWantedFeatures = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCost = new System.Windows.Forms.Label();
            this.lstTents = new System.Windows.Forms.ListBox();
            this.btnTentRet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.glUser.SuspendLayout();
            this.glItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(9, 16);
            this.lstItems.Margin = new System.Windows.Forms.Padding(2);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(120, 212);
            this.lstItems.TabIndex = 0;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.PaleGreen;
            this.btnOrder.Location = new System.Drawing.Point(133, 191);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 37);
            this.btnOrder.TabIndex = 3;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number Of Rented Items:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(48, 29);
            this.lbName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(33, 13);
            this.lbName.TabIndex = 12;
            this.lbName.Text = "None";
            // 
            // lbRentItems
            // 
            this.lbRentItems.AutoSize = true;
            this.lbRentItems.Location = new System.Drawing.Point(137, 53);
            this.lbRentItems.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRentItems.Name = "lbRentItems";
            this.lbRentItems.Size = new System.Drawing.Size(13, 13);
            this.lbRentItems.TabIndex = 13;
            this.lbRentItems.Text = "0";
            // 
            // lbSugest
            // 
            this.lbSugest.AutoSize = true;
            this.lbSugest.Location = new System.Drawing.Point(361, 41);
            this.lbSugest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSugest.Name = "lbSugest";
            this.lbSugest.Size = new System.Drawing.Size(81, 13);
            this.lbSugest.TabIndex = 14;
            this.lbSugest.Text = "Sugest an Item:";
            // 
            // tbSuggest
            // 
            this.tbSuggest.Location = new System.Drawing.Point(348, 58);
            this.tbSuggest.Margin = new System.Windows.Forms.Padding(2);
            this.tbSuggest.Name = "tbSuggest";
            this.tbSuggest.Size = new System.Drawing.Size(108, 20);
            this.tbSuggest.TabIndex = 15;
            // 
            // lsOfWantedFeatures
            // 
            this.lsOfWantedFeatures.FormattingEnabled = true;
            this.lsOfWantedFeatures.Location = new System.Drawing.Point(212, 16);
            this.lsOfWantedFeatures.Margin = new System.Windows.Forms.Padding(2);
            this.lsOfWantedFeatures.Name = "lsOfWantedFeatures";
            this.lsOfWantedFeatures.Size = new System.Drawing.Size(120, 212);
            this.lsOfWantedFeatures.TabIndex = 16;
            this.lsOfWantedFeatures.SelectedIndexChanged += new System.EventHandler(this.lsOfWantedFeatures_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(361, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Wanted Objects";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.PaleGreen;
            this.btnReturn.Location = new System.Drawing.Point(133, 248);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 37);
            this.btnReturn.TabIndex = 22;
            this.btnReturn.Text = "Return Items";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Item Value:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 26);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Item Size:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 98);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Item Image:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 115);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // btnSugestion
            // 
            this.btnSugestion.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSugestion.Location = new System.Drawing.Point(348, 80);
            this.btnSugestion.Margin = new System.Windows.Forms.Padding(2);
            this.btnSugestion.Name = "btnSugestion";
            this.btnSugestion.Size = new System.Drawing.Size(107, 30);
            this.btnSugestion.TabIndex = 27;
            this.btnSugestion.Text = "Add";
            this.btnSugestion.UseVisualStyleBackColor = false;
            this.btnSugestion.Click += new System.EventHandler(this.btnSugestion_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(88, 51);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 73);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Item Quantity:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(88, 75);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "0";
            // 
            // lstOwned
            // 
            this.lstOwned.FormattingEnabled = true;
            this.lstOwned.Location = new System.Drawing.Point(10, 248);
            this.lstOwned.Margin = new System.Windows.Forms.Padding(2);
            this.lstOwned.Name = "lstOwned";
            this.lstOwned.Size = new System.Drawing.Size(120, 199);
            this.lstOwned.TabIndex = 32;
            this.lstOwned.SelectedIndexChanged += new System.EventHandler(this.lstOwned_SelectedIndexChanged);
            // 
            // glUser
            // 
            this.glUser.Controls.Add(this.label3);
            this.glUser.Controls.Add(this.label1);
            this.glUser.Controls.Add(this.lbName);
            this.glUser.Controls.Add(this.lbRentItems);
            this.glUser.Location = new System.Drawing.Point(464, 271);
            this.glUser.Margin = new System.Windows.Forms.Padding(2);
            this.glUser.Name = "glUser";
            this.glUser.Padding = new System.Windows.Forms.Padding(2);
            this.glUser.Size = new System.Drawing.Size(154, 102);
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
            this.glItem.Location = new System.Drawing.Point(464, 16);
            this.glItem.Margin = new System.Windows.Forms.Padding(2);
            this.glItem.Name = "glItem";
            this.glItem.Padding = new System.Windows.Forms.Padding(2);
            this.glItem.Size = new System.Drawing.Size(195, 243);
            this.glItem.TabIndex = 34;
            this.glItem.TabStop = false;
            this.glItem.Text = "Item";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.PaleGreen;
            this.btnRemove.Location = new System.Drawing.Point(133, 108);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 37);
            this.btnRemove.TabIndex = 35;
            this.btnRemove.Text = "<--";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAdd.Location = new System.Drawing.Point(133, 67);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 37);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.Text = "-->";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Cost";
            // 
            // lbCost
            // 
            this.lbCost.AutoSize = true;
            this.lbCost.Location = new System.Drawing.Point(345, 136);
            this.lbCost.Name = "lbCost";
            this.lbCost.Size = new System.Drawing.Size(35, 13);
            this.lbCost.TabIndex = 38;
            this.lbCost.Text = "label4";
            this.lbCost.Visible = false;
            // 
            // lstTents
            // 
            this.lstTents.FormattingEnabled = true;
            this.lstTents.Location = new System.Drawing.Point(212, 248);
            this.lstTents.Margin = new System.Windows.Forms.Padding(2);
            this.lstTents.Name = "lstTents";
            this.lstTents.Size = new System.Drawing.Size(120, 199);
            this.lstTents.TabIndex = 39;
            // 
            // btnTentRet
            // 
            this.btnTentRet.BackColor = System.Drawing.Color.PaleGreen;
            this.btnTentRet.Location = new System.Drawing.Point(134, 410);
            this.btnTentRet.Margin = new System.Windows.Forms.Padding(2);
            this.btnTentRet.Name = "btnTentRet";
            this.btnTentRet.Size = new System.Drawing.Size(75, 37);
            this.btnTentRet.TabIndex = 40;
            this.btnTentRet.Text = "Return Tent";
            this.btnTentRet.UseVisualStyleBackColor = false;
            this.btnTentRet.Click += new System.EventHandler(this.btnTentRet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 487);
            this.Controls.Add(this.btnTentRet);
            this.Controls.Add(this.lstTents);
            this.Controls.Add(this.lbCost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.glItem);
            this.Controls.Add(this.glUser);
            this.Controls.Add(this.lstOwned);
            this.Controls.Add(this.btnSugestion);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lsOfWantedFeatures);
            this.Controls.Add(this.tbSuggest);
            this.Controls.Add(this.lbSugest);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.lstItems);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "LoaningApplication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbFavoriteItem;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbRentItems;
        private System.Windows.Forms.Label lbSugest;
        private System.Windows.Forms.TextBox tbSuggest;
        private System.Windows.Forms.ListBox lsOfWantedFeatures;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCost;
        private System.Windows.Forms.ListBox lstTents;
        private System.Windows.Forms.Button btnTentRet;
    }
}

