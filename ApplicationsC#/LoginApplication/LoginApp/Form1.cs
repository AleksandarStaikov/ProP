using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
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
                rfidManager.tagFound += this.CheckInVisitor;
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
            turonOnCamera.Enabled = false;
            startScanning.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            startScanning.Enabled = false;
            stopScaning.Enabled = true;
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
                var query = SqlCommands.getUserIdByQr(qr);
                MySqlCommand command = new MySqlCommand(query, connection);
                string queryResult = ((int)command.ExecuteScalar()).ToString();
                this.entranceVisitor.CurrentId = queryResult;

                lbStatus.Text = "PLease tag your rfid braclet";
                this.rfidManager.tagFound += this.RFIDFound;
                this.rfidManager.tagFound -= this.CheckInVisitor;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Object reference not set to an instance of an object."))
                {
                    MessageBox.Show("This QR was not found or was already used");
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
                    this.rfidManager.tagFound += this.CheckInVisitor;
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

            lbStatus.Text = "Scan QR code or RFID braclet!";
            this.Notify("Entrance successful!");
            this.entranceVisitor.ResetFields();
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            startScanning.Enabled = true;
            stopScaning.Enabled = false;
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
                    long newVisitorId = command.LastInsertedId;

                    query = SqlCommands.AddNewTicket(newVisitorId);
                    command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    this.tabControl1.SelectedIndex = 0;
                    this.rfidManager.tagFound -= RegisterVisitor;
                    this.ClearRegistrationForm();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Duplicate entry"))
                    {
                        MessageBox.Show("This bracelet is already in the system");
                        this.lbRegStatus.Text = "Please tag your RFID braclet";
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void CheckInVisitor(string rfidTag)
        {
            if (lbStatus.InvokeRequired)
            {
                lbStatus.Invoke((MethodInvoker)delegate ()
                {
                    CheckInVisitor(rfidTag);
                });
            }
            else
            {
                try
                {
                    var query = SqlCommands.CheckIfRfidExists(rfidTag);
                    var command = new MySqlCommand(query, connection);
                    var result = command.ExecuteScalar();


                    if (result != null)
                    {
                        if (result == System.DBNull.Value)
                        {
                            var updateQuery = SqlCommands.CheckInVisitor(rfidTag);
                            var updateCommand = new MySqlCommand(updateQuery, connection);
                            updateCommand.ExecuteNonQuery();
                            this.lbStatus.Text = "Scan QR code or RFID bracelet!";
                            this.Notify("Check-in successful!");
                        }
                        else
                        {
                            if (((bool)result) == true)
                            {
                                this.lbStatus.Text = "Scan QR code or RFID bracelet!";
                                this.Notify("This RFID was already checked in, please check out first.");
                            }
                            else
                            {
                                var updateQuery = SqlCommands.CheckInVisitor(rfidTag);
                                var updateCommand = new MySqlCommand(updateQuery, connection);
                                updateCommand.ExecuteNonQuery();
                                this.lbStatus.Text = "Scan QR code or RFID bracelet!";
                                this.Notify("Check-in successful!");
                            }
                        }
                    }
                    else
                    {
                        this.lbStatus.Text = "Scan QR code or RFID bracelet!";
                        this.Notify("Check -in unsuccessful, this bracelet is not in the system, try again!");
                    }
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
            this.lbRegStatus.Text = "Scan QR code or RFID bracelet!";
            this.Notify("Checking successfull");
        }

        private void Notify(string text)
        {
            this.tmNotification.Start();
            this.lbNotify.Text = text;
            this.lbNotify.Visible = true;
        }

        private void tmNotification_Tick(object sender, EventArgs e)
        {
            this.lbNotify.Visible = false;
            this.tmNotification.Stop();
        }
    }
}
