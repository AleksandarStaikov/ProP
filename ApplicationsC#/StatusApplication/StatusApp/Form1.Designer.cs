namespace StatusApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTickets = new System.Windows.Forms.Label();
            this.lbAttendees = new System.Windows.Forms.Label();
            this.lbPurchasedItem = new System.Windows.Forms.Label();
            this.lbPrefferedStore = new System.Windows.Forms.Label();
            this.lbMoneyAtStores = new System.Windows.Forms.Label();
            this.lbMoneyForLoaning = new System.Windows.Forms.Label();
            this.lbLoanedMaterial = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.lbUpdated = new System.Windows.Forms.Label();
            this.grAtendees = new System.Windows.Forms.DataGridView();
            this.grMoney = new System.Windows.Forms.DataGridView();
            this.grLostItems = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grAtendees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grLostItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(493, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event status ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tickets purchased";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 359);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Current attendees";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 185);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Most purchased item";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 223);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(292, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Most preffered store";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(409, 359);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(306, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Money spent at stores";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 261);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(334, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Money spent for loaning";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 299);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(306, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Most loaned material ";
            // 
            // lbTickets
            // 
            this.lbTickets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTickets.AutoSize = true;
            this.lbTickets.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTickets.Location = new System.Drawing.Point(445, 148);
            this.lbTickets.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTickets.Name = "lbTickets";
            this.lbTickets.Size = new System.Drawing.Size(96, 25);
            this.lbTickets.TabIndex = 8;
            this.lbTickets.Text = "label9";
            this.lbTickets.Visible = false;
            // 
            // lbAttendees
            // 
            this.lbAttendees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAttendees.AutoSize = true;
            this.lbAttendees.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAttendees.Location = new System.Drawing.Point(1035, 65);
            this.lbAttendees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAttendees.Name = "lbAttendees";
            this.lbAttendees.Size = new System.Drawing.Size(110, 25);
            this.lbAttendees.TabIndex = 9;
            this.lbAttendees.Text = "label10";
            this.lbAttendees.Visible = false;
            // 
            // lbPurchasedItem
            // 
            this.lbPurchasedItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPurchasedItem.AutoSize = true;
            this.lbPurchasedItem.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPurchasedItem.Location = new System.Drawing.Point(445, 186);
            this.lbPurchasedItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPurchasedItem.Name = "lbPurchasedItem";
            this.lbPurchasedItem.Size = new System.Drawing.Size(110, 25);
            this.lbPurchasedItem.TabIndex = 10;
            this.lbPurchasedItem.Text = "label11";
            this.lbPurchasedItem.Visible = false;
            // 
            // lbPrefferedStore
            // 
            this.lbPrefferedStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPrefferedStore.AutoSize = true;
            this.lbPrefferedStore.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrefferedStore.Location = new System.Drawing.Point(445, 224);
            this.lbPrefferedStore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPrefferedStore.Name = "lbPrefferedStore";
            this.lbPrefferedStore.Size = new System.Drawing.Size(110, 25);
            this.lbPrefferedStore.TabIndex = 11;
            this.lbPrefferedStore.Text = "label12";
            this.lbPrefferedStore.Visible = false;
            // 
            // lbMoneyAtStores
            // 
            this.lbMoneyAtStores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMoneyAtStores.AutoSize = true;
            this.lbMoneyAtStores.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoneyAtStores.Location = new System.Drawing.Point(1035, 111);
            this.lbMoneyAtStores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMoneyAtStores.Name = "lbMoneyAtStores";
            this.lbMoneyAtStores.Size = new System.Drawing.Size(110, 25);
            this.lbMoneyAtStores.TabIndex = 12;
            this.lbMoneyAtStores.Text = "label13";
            this.lbMoneyAtStores.Visible = false;
            // 
            // lbMoneyForLoaning
            // 
            this.lbMoneyForLoaning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMoneyForLoaning.AutoSize = true;
            this.lbMoneyForLoaning.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoneyForLoaning.Location = new System.Drawing.Point(445, 262);
            this.lbMoneyForLoaning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMoneyForLoaning.Name = "lbMoneyForLoaning";
            this.lbMoneyForLoaning.Size = new System.Drawing.Size(110, 25);
            this.lbMoneyForLoaning.TabIndex = 13;
            this.lbMoneyForLoaning.Text = "label14";
            this.lbMoneyForLoaning.Visible = false;
            // 
            // lbLoanedMaterial
            // 
            this.lbLoanedMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoanedMaterial.AutoSize = true;
            this.lbLoanedMaterial.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoanedMaterial.Location = new System.Drawing.Point(445, 300);
            this.lbLoanedMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLoanedMaterial.Name = "lbLoanedMaterial";
            this.lbLoanedMaterial.Size = new System.Drawing.Size(110, 25);
            this.lbLoanedMaterial.TabIndex = 14;
            this.lbLoanedMaterial.Text = "label15";
            this.lbLoanedMaterial.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(471, 67);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "Last updated on: ";
            // 
            // lbUpdated
            // 
            this.lbUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUpdated.AutoSize = true;
            this.lbUpdated.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdated.Location = new System.Drawing.Point(741, 65);
            this.lbUpdated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUpdated.Name = "lbUpdated";
            this.lbUpdated.Size = new System.Drawing.Size(110, 25);
            this.lbUpdated.TabIndex = 16;
            this.lbUpdated.Text = "label10";
            // 
            // grAtendees
            // 
            this.grAtendees.AllowUserToAddRows = false;
            this.grAtendees.AllowUserToDeleteRows = false;
            this.grAtendees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grAtendees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grAtendees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grAtendees.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.grAtendees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grAtendees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grAtendees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grAtendees.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(18)))));
            this.grAtendees.Location = new System.Drawing.Point(12, 395);
            this.grAtendees.Margin = new System.Windows.Forms.Padding(4);
            this.grAtendees.Name = "grAtendees";
            this.grAtendees.Size = new System.Drawing.Size(338, 173);
            this.grAtendees.TabIndex = 17;
            // 
            // grMoney
            // 
            this.grMoney.AllowUserToAddRows = false;
            this.grMoney.AllowUserToDeleteRows = false;
            this.grMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grMoney.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grMoney.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grMoney.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.grMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grMoney.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grMoney.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMoney.Location = new System.Drawing.Point(395, 395);
            this.grMoney.Margin = new System.Windows.Forms.Padding(4);
            this.grMoney.Name = "grMoney";
            this.grMoney.Size = new System.Drawing.Size(345, 173);
            this.grMoney.TabIndex = 18;
            // 
            // grLostItems
            // 
            this.grLostItems.AllowUserToAddRows = false;
            this.grLostItems.AllowUserToDeleteRows = false;
            this.grLostItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grLostItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grLostItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grLostItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.grLostItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grLostItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grLostItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grLostItems.Location = new System.Drawing.Point(776, 395);
            this.grLostItems.Margin = new System.Windows.Forms.Padding(4);
            this.grLostItems.Name = "grLostItems";
            this.grLostItems.Size = new System.Drawing.Size(344, 173);
            this.grLostItems.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(753, 359);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(404, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "Currently not returned items";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1173, 581);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grLostItems);
            this.Controls.Add(this.grMoney);
            this.Controls.Add(this.grAtendees);
            this.Controls.Add(this.lbUpdated);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbLoanedMaterial);
            this.Controls.Add(this.lbMoneyForLoaning);
            this.Controls.Add(this.lbMoneyAtStores);
            this.Controls.Add(this.lbPrefferedStore);
            this.Controls.Add(this.lbPurchasedItem);
            this.Controls.Add(this.lbAttendees);
            this.Controls.Add(this.lbTickets);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grAtendees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grLostItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTickets;
        private System.Windows.Forms.Label lbAttendees;
        private System.Windows.Forms.Label lbPurchasedItem;
        private System.Windows.Forms.Label lbPrefferedStore;
        private System.Windows.Forms.Label lbMoneyAtStores;
        private System.Windows.Forms.Label lbMoneyForLoaning;
        private System.Windows.Forms.Label lbLoanedMaterial;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbUpdated;
        private System.Windows.Forms.DataGridView grAtendees;
        private System.Windows.Forms.DataGridView grMoney;
        private System.Windows.Forms.DataGridView grLostItems;
        private System.Windows.Forms.Label label10;
    }
}

