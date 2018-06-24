namespace CampingAppCheckOut
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCheckOut = new System.Windows.Forms.TabPage();
            this.labelHint = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonCheckOut = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageCheckOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCheckOut);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1044, 565);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageCheckOut
            // 
            this.tabPageCheckOut.BackColor = System.Drawing.Color.LightBlue;
            this.tabPageCheckOut.Controls.Add(this.labelHint);
            this.tabPageCheckOut.Controls.Add(this.labelStatus);
            this.tabPageCheckOut.Controls.Add(this.buttonCheckOut);
            this.tabPageCheckOut.Location = new System.Drawing.Point(4, 40);
            this.tabPageCheckOut.Name = "tabPageCheckOut";
            this.tabPageCheckOut.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCheckOut.Size = new System.Drawing.Size(1036, 521);
            this.tabPageCheckOut.TabIndex = 1;
            this.tabPageCheckOut.Text = "CHECKOUT";
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.Location = new System.Drawing.Point(335, 14);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(0, 32);
            this.labelHint.TabIndex = 2;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(335, 99);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 32);
            this.labelStatus.TabIndex = 1;
            // 
            // buttonCheckOut
            // 
            this.buttonCheckOut.BackColor = System.Drawing.Color.Purple;
            this.buttonCheckOut.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.buttonCheckOut.FlatAppearance.BorderSize = 3;
            this.buttonCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckOut.Location = new System.Drawing.Point(341, 181);
            this.buttonCheckOut.Name = "buttonCheckOut";
            this.buttonCheckOut.Size = new System.Drawing.Size(346, 202);
            this.buttonCheckOut.TabIndex = 0;
            this.buttonCheckOut.Text = "CHECKOUT";
            this.buttonCheckOut.UseVisualStyleBackColor = false;
            this.buttonCheckOut.Click += new System.EventHandler(this.buttonCheckOut_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1068, 589);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCheckOut.ResumeLayout(false);
            this.tabPageCheckOut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCheckOut;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonCheckOut;
        private System.Windows.Forms.Timer timer1;
    }
}

