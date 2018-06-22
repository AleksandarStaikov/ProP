namespace CheckOutApplication
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
            this.lbStatus = new System.Windows.Forms.Label();
            this.tmNotification = new System.Windows.Forms.Timer(this.components);
            this.lbNotify = new System.Windows.Forms.Label();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status:";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(84, 9);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(58, 22);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "label2";
            this.lbStatus.Visible = false;
            // 
            // tmNotification
            // 
            this.tmNotification.Interval = 4000;
            this.tmNotification.Tick += new System.EventHandler(this.tmNotification_Tick);
            // 
            // lbNotify
            // 
            this.lbNotify.AutoSize = true;
            this.lbNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotify.Location = new System.Drawing.Point(12, 31);
            this.lbNotify.Name = "lbNotify";
            this.lbNotify.Size = new System.Drawing.Size(58, 22);
            this.lbNotify.TabIndex = 2;
            this.lbNotify.Text = "label2";
            this.lbNotify.Visible = false;
            // 
            // lbItems
            // 
            this.lbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItems.FormattingEnabled = true;
            this.lbItems.ItemHeight = 20;
            this.lbItems.Location = new System.Drawing.Point(16, 56);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(161, 64);
            this.lbItems.TabIndex = 3;
            this.lbItems.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 174);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.lbNotify);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Timer tmNotification;
        private System.Windows.Forms.Label lbNotify;
        private System.Windows.Forms.ListBox lbItems;
    }
}

