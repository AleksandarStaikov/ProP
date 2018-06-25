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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCheckIn = new System.Windows.Forms.TabPage();
            this.labelstats = new System.Windows.Forms.Label();
            this.buttonReserve = new System.Windows.Forms.Button();
            this.buttonADDTent = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.tabPageReserve = new System.Windows.Forms.TabPage();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxTentSize = new System.Windows.Forms.ComboBox();
            this.comboBoxSpotNo = new System.Windows.Forms.ComboBox();
            this.comboBoxCampNo = new System.Windows.Forms.ComboBox();
            this.lbResStatus = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageAddTent = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAddTentOnly = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.StatusTent = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonTent = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPageCheckIn);
            this.tabControl1.Controls.Add(this.tabPageReserve);
            this.tabControl1.Controls.Add(this.tabPageAddTent);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(92, 27);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(1082, 596);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageCheckIn
            // 
            this.tabPageCheckIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(18)))));
            this.tabPageCheckIn.BackgroundImage = global::CampingApp.Properties.Resources.Background4;
            this.tabPageCheckIn.Controls.Add(this.labelstats);
            this.tabPageCheckIn.Controls.Add(this.buttonReserve);
            this.tabPageCheckIn.Controls.Add(this.buttonADDTent);
            this.tabPageCheckIn.Controls.Add(this.labelInfo);
            this.tabPageCheckIn.Controls.Add(this.buttonCheck);
            this.tabPageCheckIn.Location = new System.Drawing.Point(4, 31);
            this.tabPageCheckIn.Name = "tabPageCheckIn";
            this.tabPageCheckIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCheckIn.Size = new System.Drawing.Size(1074, 561);
            this.tabPageCheckIn.TabIndex = 0;
            this.tabPageCheckIn.Text = "CHECKIN";
            // 
            // labelstats
            // 
            this.labelstats.AutoSize = true;
            this.labelstats.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelstats.Location = new System.Drawing.Point(287, 80);
            this.labelstats.Name = "labelstats";
            this.labelstats.Size = new System.Drawing.Size(0, 31);
            this.labelstats.TabIndex = 13;
            // 
            // buttonReserve
            // 
            this.buttonReserve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(229)))), ((int)(((byte)(56)))));
            this.buttonReserve.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.buttonReserve.FlatAppearance.BorderSize = 0;
            this.buttonReserve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReserve.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReserve.Location = new System.Drawing.Point(23, 160);
            this.buttonReserve.Name = "buttonReserve";
            this.buttonReserve.Size = new System.Drawing.Size(249, 175);
            this.buttonReserve.TabIndex = 12;
            this.buttonReserve.Text = "MAKE RESERVE";
            this.buttonReserve.UseVisualStyleBackColor = false;
            this.buttonReserve.Click += new System.EventHandler(this.buttonReserve_Click);
            // 
            // buttonADDTent
            // 
            this.buttonADDTent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(229)))), ((int)(((byte)(56)))));
            this.buttonADDTent.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.buttonADDTent.FlatAppearance.BorderSize = 0;
            this.buttonADDTent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonADDTent.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonADDTent.Location = new System.Drawing.Point(773, 158);
            this.buttonADDTent.Name = "buttonADDTent";
            this.buttonADDTent.Size = new System.Drawing.Size(249, 178);
            this.buttonADDTent.TabIndex = 11;
            this.buttonADDTent.Text = "ADD TENT";
            this.buttonADDTent.UseVisualStyleBackColor = false;
            this.buttonADDTent.Click += new System.EventHandler(this.buttonADDTent_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(372, 14);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 31);
            this.labelInfo.TabIndex = 10;
            // 
            // buttonCheck
            // 
            this.buttonCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(229)))), ((int)(((byte)(56)))));
            this.buttonCheck.FlatAppearance.BorderColor = System.Drawing.Color.LightYellow;
            this.buttonCheck.FlatAppearance.BorderSize = 0;
            this.buttonCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheck.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheck.Location = new System.Drawing.Point(363, 141);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(330, 212);
            this.buttonCheck.TabIndex = 7;
            this.buttonCheck.Text = "CHECKIN";
            this.buttonCheck.UseVisualStyleBackColor = false;
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
            this.tabPageReserve.Size = new System.Drawing.Size(1074, 561);
            this.tabPageReserve.TabIndex = 1;
            this.tabPageReserve.Text = "RESERVE";
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(229)))), ((int)(((byte)(56)))));
            this.buttonInsert.FlatAppearance.BorderColor = System.Drawing.Color.LightYellow;
            this.buttonInsert.FlatAppearance.BorderSize = 0;
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsert.Location = new System.Drawing.Point(2, 438);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(1041, 93);
            this.buttonInsert.TabIndex = 8;
            this.buttonInsert.Text = "RESERVE";
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox4.BackgroundImage = global::CampingApp.Properties.Resources.Background4;
            this.groupBox4.Controls.Add(this.comboBoxTentSize);
            this.groupBox4.Controls.Add(this.comboBoxSpotNo);
            this.groupBox4.Controls.Add(this.comboBoxCampNo);
            this.groupBox4.Controls.Add(this.lbResStatus);
            this.groupBox4.Controls.Add(this.lbStatus);
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("OCR A Extended", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1068, 555);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reservation on the spot";
            // 
            // comboBoxTentSize
            // 
            this.comboBoxTentSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(229)))), ((int)(((byte)(56)))));
            this.comboBoxTentSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTentSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxTentSize.Font = new System.Drawing.Font("OCR A Extended", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTentSize.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxTentSize.FormattingEnabled = true;
            this.comboBoxTentSize.Items.AddRange(new object[] {
            "2",
            "4",
            "6"});
            this.comboBoxTentSize.Location = new System.Drawing.Point(908, 238);
            this.comboBoxTentSize.Name = "comboBoxTentSize";
            this.comboBoxTentSize.Size = new System.Drawing.Size(121, 37);
            this.comboBoxTentSize.TabIndex = 16;
            // 
            // comboBoxSpotNo
            // 
            this.comboBoxSpotNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(229)))), ((int)(((byte)(56)))));
            this.comboBoxSpotNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpotNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxSpotNo.Font = new System.Drawing.Font("OCR A Extended", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSpotNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxSpotNo.FormattingEnabled = true;
            this.comboBoxSpotNo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBoxSpotNo.Location = new System.Drawing.Point(741, 238);
            this.comboBoxSpotNo.Name = "comboBoxSpotNo";
            this.comboBoxSpotNo.Size = new System.Drawing.Size(121, 37);
            this.comboBoxSpotNo.TabIndex = 15;
            // 
            // comboBoxCampNo
            // 
            this.comboBoxCampNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(229)))), ((int)(((byte)(56)))));
            this.comboBoxCampNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCampNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxCampNo.Font = new System.Drawing.Font("OCR A Extended", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCampNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxCampNo.FormattingEnabled = true;
            this.comboBoxCampNo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48"});
            this.comboBoxCampNo.Location = new System.Drawing.Point(570, 238);
            this.comboBoxCampNo.Name = "comboBoxCampNo";
            this.comboBoxCampNo.Size = new System.Drawing.Size(121, 37);
            this.comboBoxCampNo.TabIndex = 14;
            // 
            // lbResStatus
            // 
            this.lbResStatus.AutoSize = true;
            this.lbResStatus.Location = new System.Drawing.Point(600, 119);
            this.lbResStatus.Name = "lbResStatus";
            this.lbResStatus.Size = new System.Drawing.Size(0, 25);
            this.lbResStatus.TabIndex = 13;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(600, 66);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 25);
            this.lbStatus.TabIndex = 12;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(102)))));
            this.listBox1.Font = new System.Drawing.Font("OCR A Extended", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(7, 66);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(551, 316);
            this.listBox1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(884, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tent size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(747, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Spots #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(564, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Camping #";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Free Spots";
            // 
            // tabPageAddTent
            // 
            this.tabPageAddTent.BackColor = System.Drawing.Color.LightBlue;
            this.tabPageAddTent.Controls.Add(this.groupBox1);
            this.tabPageAddTent.Location = new System.Drawing.Point(4, 31);
            this.tabPageAddTent.Name = "tabPageAddTent";
            this.tabPageAddTent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddTent.Size = new System.Drawing.Size(1074, 561);
            this.tabPageAddTent.TabIndex = 2;
            this.tabPageAddTent.Text = "ADD TENT";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox1.BackgroundImage = global::CampingApp.Properties.Resources.Background4;
            this.groupBox1.Controls.Add(this.cbAddTentOnly);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.StatusTent);
            this.groupBox1.Controls.Add(this.Status);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonTent);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1068, 555);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ADD TENT";
            // 
            // cbAddTentOnly
            // 
            this.cbAddTentOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(229)))), ((int)(((byte)(56)))));
            this.cbAddTentOnly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddTentOnly.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbAddTentOnly.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAddTentOnly.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbAddTentOnly.FormattingEnabled = true;
            this.cbAddTentOnly.Items.AddRange(new object[] {
            "2",
            "4",
            "6"});
            this.cbAddTentOnly.Location = new System.Drawing.Point(217, 47);
            this.cbAddTentOnly.Name = "cbAddTentOnly";
            this.cbAddTentOnly.Size = new System.Drawing.Size(121, 37);
            this.cbAddTentOnly.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(370, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(506, 30);
            this.label6.TabIndex = 16;
            this.label6.Text = "Choose between sizes: 2, 4, 6";
            // 
            // StatusTent
            // 
            this.StatusTent.AutoSize = true;
            this.StatusTent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTent.Location = new System.Drawing.Point(346, 127);
            this.StatusTent.Name = "StatusTent";
            this.StatusTent.Size = new System.Drawing.Size(0, 31);
            this.StatusTent.TabIndex = 15;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(352, 127);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 31);
            this.Status.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 30);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tent size";
            // 
            // buttonTent
            // 
            this.buttonTent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(229)))), ((int)(((byte)(56)))));
            this.buttonTent.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.buttonTent.FlatAppearance.BorderSize = 0;
            this.buttonTent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTent.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTent.Location = new System.Drawing.Point(375, 151);
            this.buttonTent.Name = "buttonTent";
            this.buttonTent.Size = new System.Drawing.Size(230, 90);
            this.buttonTent.TabIndex = 11;
            this.buttonTent.Text = "ADD ";
            this.buttonTent.UseVisualStyleBackColor = false;
            this.buttonTent.Click += new System.EventHandler(this.buttonTent_Click);
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
            this.BackgroundImage = global::CampingApp.Properties.Resources.Background2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1082, 596);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPageAddTent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonTent;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label lbResStatus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button buttonReserve;
        private System.Windows.Forms.Button buttonADDTent;
        private System.Windows.Forms.Label StatusTent;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelstats;
        private System.Windows.Forms.ComboBox cbAddTentOnly;
        private System.Windows.Forms.ComboBox comboBoxTentSize;
        private System.Windows.Forms.ComboBox comboBoxSpotNo;
        private System.Windows.Forms.ComboBox comboBoxCampNo;
    }
}

