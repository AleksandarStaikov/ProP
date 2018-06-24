using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidget22;
using Phidget22.Events;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CampingAppNew
{
    public partial class FormHome : Form
    {
        RFID rfid;
        string connectionString;
        MySqlCommand cmd;
        Queries queries;
        Reservation res;
        FormHome fh;
        public FormHome()
        {
            fh = new FormHome();
            res = new Reservation();
            connectionString = "server=studmysql01.fhict.local;database=dbi380752;username=dbi380752;password=123456";
            queries = new Queries();
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rfid = new RFID();
            rfid.Open();
            rfid.Attach += RFIDstuffs;
            rfid.TagLost += RFIDuntag;
        }
        public void RFIDstuffs(object sender, AttachEventArgs e)
        {
            RFID attachedDevice = (RFID)sender;
            try
            {
                rfid.AntennaEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RFIDuntag(object sender, RFIDTagLostEventArgs e)
        {
            rfid.Tag -= CheckIN;
        }
        public void CheckIN(object sender, RFIDTagEventArgs e)
        {
            try
            {
                queries.AddVisitors();
                Visitors v = new Visitors();
                if (v.ReservationID != 0 && v.Rfid == e.Tag)
                {
                    MessageBox.Show("Check In Successful! Welcome to our camping!");
                }
                else
                {
                    MessageBox.Show("Check In Unsuccessful! Make a reservation first ");

                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Failed to connect to the database!");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            rfid.Tag += CheckIN;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fh.Hide();
            res.Show();
        }
    }
}
