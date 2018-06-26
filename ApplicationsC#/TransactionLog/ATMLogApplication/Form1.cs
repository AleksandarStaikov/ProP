using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATMLogApplication.Models;
using MySql.Data.MySqlClient;

namespace ATMLogApplication
{
    public partial class Form1 : Form
    {
        private const string PASSWORD = "123456";
        private const string USER = "dbi380752";
        private const string DB = "dbi380752";
        private const string HOST = "studmysql01.fhict.local";
        private string connectionString = $"server={HOST};database={DB};user id={USER};password={PASSWORD};connect timeout=30;SslMode=none";

        TextFileHelper stream;
        MySqlConnection connection;
        SQLManager sqlManager;
        string filename = string.Empty;

        public Form1()
        {
            InitializeComponent();
            stream = new TextFileHelper(filename);
            connection = new MySqlConnection(connectionString);
            sqlManager = new SQLManager(connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var browser = new OpenFileDialog();

            browser.Filter = "Text files (*.txt)|*.txt";
            browser.RestoreDirectory = true;
            browser.InitialDirectory = filename;

            if (browser.ShowDialog() == DialogResult.OK)
            {
                filename = browser.FileName;
                lbFileName.Text = browser.FileName;
                stream.FileName = browser.FileName;
                lbStatus.Text = "Transaction file selected, run transacions or choose another file";
                lbUpdated.Items.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                try
                {
                    lbStatus.Text = "Running transactions";
                    var log = this.stream.ReadFromFile();
                    var logId = this.sqlManager.AddTransactionLog(log);
                    foreach (var transaction in log.Transactions)
                    {
                        try
                        {
                            this.sqlManager.AddTransaction(transaction, logId);
                            this.lbUpdated.Items.Add(transaction.ToString());
                        }
                        catch (Exception transactionEx)
                        {
                            MessageBox.Show(transactionEx.Message);
                            this.lbUpdated.Items.Add(transaction.TransactionFailedString());
                        }
                    }
                    lbStatus.Text = "Transactions runned successfully";
                }
                catch (Exception ex)
                {
                    lbStatus.Text = "Running transactions failed";
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a file first");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.connection.Open();
            lbFileName.Text = filename;
            lbStatus.Text = "Select a transaction file";
            lbUpdated.AutoSize = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.connection.Close();
        }

        
    }
}
