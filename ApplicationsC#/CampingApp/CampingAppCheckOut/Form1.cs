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

namespace CampingAppCheckOut
{
    public partial class Form1 : Form
    {
        private string visitorTag;
        string connectionString;
        MySqlCommand cmd;
        private RfidManager rfidManager;
        public Form1()
        {
            InitializeComponent();
            connectionString = "server=studmysql01.fhict.local;database=dbi380752;username=dbi380752;password=123456;SslMode=none";
            rfidManager = new RfidManager();
            labelHint.Text = "Press CHECKOUT button!";
            
        }
        public void RFIDcheckOut(string rfidTag)
        {
            if (labelStatus.InvokeRequired)
            {
                labelStatus.Invoke((MethodInvoker)delegate ()
                {
                    RFIDcheckOut(rfidTag);
                });
            }
            else
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {

                        visitorTag = rfidTag;
                        connection.Open();

                        string displayQueryCheckOut = "SELECT camping_reservation.id " +
                                          " FROM tickets_visitor " +
                                          " JOIN camping_reservation ON (camping_reservation.visitor_id = tickets_visitor.id) " +
                                          " WHERE tickets_visitor.rfid_code = '" + visitorTag + "'";

                        cmd = new MySqlCommand(displayQueryCheckOut, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read() == true && reader[0].ToString() != "")
                        {
                            timer1.Enabled = true;
                            timer1.Start();
                            labelStatus.Text = "CHECKOUT SUCCESSFUL!";
                            rfidManager.tagFound -= RFIDcheckOut;
                            labelHint.Text = "";
                        }
                        else
                        {
                            timer1.Enabled = true;
                            timer1.Start();
                            labelStatus.Text = "CHECKOUT UNSUCCESSFUL!";
                            rfidManager.tagFound -= RFIDcheckOut;
                            labelHint.Text = "";
                        }
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Failed to connect to the database!");
            }
        }
    }

    private void buttonCheckOut_Click(object sender, EventArgs e)
    {
        rfidManager.tagFound += RFIDcheckOut;
        timer1.Enabled = true;
        timer1.Start();
        labelHint.Text = "Scan your bracelet!";
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        //duration--;
        if (timer1.Enabled)
        {
            timer1.Stop();
            labelHint.Text = "";
            labelStatus.Text = "";
            labelHint.Text = "Press CHECKOUT button!";
        }
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Location = (new Point(ClientSize.Width / 2 - tabControl1.Width / 2,
                                    ClientSize.Height / 2 - tabControl1.Height / 2));
            tabControl1.Anchor = AnchorStyles.None;
        }
    }
}
