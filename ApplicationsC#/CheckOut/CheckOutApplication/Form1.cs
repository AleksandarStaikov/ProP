using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CheckOutApplication
{
    public partial class Form1 : Form
    {
        private const string PASSWORD = "123456";
        private const string USER = "dbi380752";
        private const string DB = "dbi380752";
        private const string HOST = "studmysql01.fhict.local";
        private string connectionString = $"server={HOST};database={DB};user id={USER};password={PASSWORD};connect timeout=30;SslMode=none";

        private const string DEFAULT_WAITING_STATUS = "Tag your braclet to check-out";
        private const string UNRETURNED_ITEMS = ", you have unreturned items";
        private const string CHECKOUT_SUCCESSFUL = "Successfully checked-out";
        private const string BRACLET_TAGGED = "Braclet tagged, please wait";

        private MySqlConnection connection;
        private SqlManager sqlManager;
        private RfidManager rfidManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.connection = new MySqlConnection(connectionString);
                this.sqlManager = new SqlManager(connection);
                this.rfidManager = new RfidManager();

                this.rfidManager.tagFound += this.VisitorTagged;
                this.connection.Open();
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Unable to connect"))
                {
                    MessageBox.Show("Unable to connect to the database");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }

            this.lbStatus.Text = DEFAULT_WAITING_STATUS;
            this.lbStatus.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void VisitorTagged(string tag)
        {
            if (lbStatus.InvokeRequired)
            {
                lbStatus.Invoke((MethodInvoker)delegate ()
                {
                    this.VisitorTagged(tag);
                });
            }
            else
            {
                this.lbStatus.Text = BRACLET_TAGGED;

                try
                {
                    var items = this.sqlManager.GetVisitorsItems(tag);
                    this.sqlManager.CheckOutVisitor(tag);

                    if (items != null)
                    {
                        this.lbItems.DataSource = items;
                        this.lbItems.Visible = true;
                        this.Notify(CHECKOUT_SUCCESSFUL + UNRETURNED_ITEMS);
                    }
                    else
                    {
                        this.Notify(CHECKOUT_SUCCESSFUL);
                    }
                    this.lbStatus.Text = DEFAULT_WAITING_STATUS;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

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
            this.lbItems.Visible = false;
            this.tmNotification.Stop();
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
