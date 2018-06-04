using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.QrCode;
using MySql.Data;
using MySql.Data.MySqlClient;
using LoginApp.Models;

namespace LoginApp
{
    public partial class Form1 : Form
    {
        private const string PASSWORD = "123456";
        private const string USER = "dbi380752";
        private const string DB = "dbi380752";
        private const string HOST = "studmysql01.fhict.local";
        private string connectionString = $"server={HOST};database={DB};user id={USER};password={PASSWORD};connect timeout=30;SslMode=none";


        public Form1()
        {
            InitializeComponent();
        }

        private MySqlConnection connection;
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        private Action<string> qrFound;
        private EntranceVisitor entranceVisitor;
        private RegistrationVisitor registrationVisitor;
        private RFIDManager rfidManager;

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Image)eventArgs.Frame.Clone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                entranceVisitor = new EntranceVisitor();
                registrationVisitor = new RegistrationVisitor();
                rfidManager = new RFIDManager();
                connection.Open();
                qrFound += GetUser;

                CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo Device in CaptureDevice)
                {
                    comboBox1.Items.Add(Device.Name);
                }
                comboBox1.SelectedIndex = 0;
                FinalFrame = new VideoCaptureDevice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            lbStatus.Text = "Start scaning";
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button2.Enabled = false;
            button3.Enabled = true;
            lbStatus.Text = "Put your QR code infront of the camera";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader();
            if ((Bitmap)pictureBox1.Image == null)
            {
                return;
            }
            Result result = Reader.Decode((Bitmap)pictureBox1.Image);
            try
            {
                if (result != null)
                {
                    string decoded = result.ToString().Trim();
                    qrFound(decoded);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("It appears that this QR code has been already used, or it is not in the system!");
                timer1.Start();
            }
        }

        public void GetUser(string qr)
        {
            timer1.Stop();

            try
            {
                var query = SqlCommands.getUserIdByQrQuery(qr);
                MySqlCommand command = new MySqlCommand(query, connection);
                string queryResult = ((int)command.ExecuteScalar()).ToString();
                this.entranceVisitor.CurrentId = queryResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            lbStatus.Text = "PLease tag your rfid braclet";
            rfidManager.tagFound += RFIDFound;
        }

        public void RFIDFound(string rfid)
        {
            if (lbStatus.InvokeRequired)
            {
                lbStatus.Invoke((MethodInvoker)delegate ()
                {
                    RFIDFound(rfid);
                });
            }
            else
            {
                try
                {
                    lbStatus.Text = "Your rfid braclet has been checked, please wait.";
                    this.entranceVisitor.CurrentRFID = rfid;
                    this.rfidManager.tagFound -= RFIDFound;
                    this.AddRFIDToVisitor();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void AddRFIDToVisitor()
        {
            var query = SqlCommands.UpdateUserRFIDById(this.entranceVisitor.CurrentId, this.entranceVisitor.CurrentRFID);
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();

            var anotherQuery = SqlCommands.UpdateTicketEntryDate(this.entranceVisitor.CurrentId);
            var anotherCommand = new MySqlCommand(anotherQuery, connection);
            anotherCommand.ExecuteNonQuery();

            lbStatus.Text = "Entrance was successfull, please scan next!";
            this.entranceVisitor.ResetFields();
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button2.Enabled = true;
            button3.Enabled = false;
            lbStatus.Text = "Start scaning";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                this.registrationVisitor.FirstName = tbNewFName.Text;
                this.registrationVisitor.LastName = tbNewLName.Text;
                this.registrationVisitor.Email = tbNewEmail.Text;
                this.registrationVisitor.BirthDate = dtpNewBirthDate.Value;
                rfidManager.tagFound += RegisterVisitor;
                lbRegStatus.Text = "Please tag your RFID braclet";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RegisterVisitor(string rfidTag)
        {
            if (lbStatus.InvokeRequired)
            {
                lbStatus.Invoke((MethodInvoker)delegate ()
                {
                    RegisterVisitor(rfidTag);
                });
            }
            else
            {
                try
                {
                    this.lbRegStatus.Text = "RFID braclet tagged, please wait!";
                    this.registrationVisitor.RFID = rfidTag;

                    var query = SqlCommands.RegisterNewVisitor(this.registrationVisitor);
                    var command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    this.rfidManager.tagFound -= RegisterVisitor;
                    this.ClearRegistrationForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void ClearRegistrationForm()
        {
            this.tbNewEmail.Text = string.Empty;
            this.tbNewFName.Text = string.Empty;
            this.tbNewLName.Text = string.Empty;
            this.dtpNewBirthDate.Value = DateTime.Now;
            this.registrationVisitor.ResetData();
            this.lbRegStatus.Text = "Registratoin successful, proceed with the next visitor!";
        }
    }
}
