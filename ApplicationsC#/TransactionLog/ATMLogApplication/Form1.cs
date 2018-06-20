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
        string initialFileName = "MyTextFile.txt";

        public Form1()
        {
            InitializeComponent();
            stream = new TextFileHelper(initialFileName);
            connection = new MySqlConnection(connectionString);
            sqlManager = new SQLManager(connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var browser = new OpenFileDialog();

            browser.Filter = "Text files (*.txt)|*.txt";
            browser.RestoreDirectory = true;
            browser.InitialDirectory = initialFileName;

            if (browser.ShowDialog() == DialogResult.OK)
            {
                lbFileName.Text = browser.FileName;
                stream.FileName = browser.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var log = this.stream.ReadFromFile();
            var logId = this.sqlManager.AddTransactionLog(log);
            foreach (var transaction in log.Transactions)
            {
                this.sqlManager.AddTransaction(transaction, logId);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.connection.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.connection.Close();
        }
    }
}
