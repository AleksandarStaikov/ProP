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
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using LoaningApplicationProP.Models;


namespace LoaningApplicationProP
{
    public partial class Form1 : Form
    {
        private const string PASSWORD = "123456";
        private const string USER = "dbi380752";
        private const string DB = "dbi380752";
        private const string HOST = "studmysql01.fhict.local";
        private string connectionString = $"server={HOST};database={DB};user id={USER};password={PASSWORD};connect timeout=30;SslMode=none";

        private RFID myRFIDReader;
        private MySqlConnection connection;
        private SqlManager sqlManager;
        private RFIDManager rfidManager;
        private Stand shop;
        private Visitor returningVisitor;

        public Form1()
        {
            InitializeComponent();
            try
            {
                myRFIDReader = new RFID();
            }
            catch (PhidgetException) { MessageBox.Show("error at start-up."); }

            try
            {
                //myRFIDReader.Open(); //if successfully, it will call the Attach-event.
            }
            catch (PhidgetException) { MessageBox.Show("no RFID-reader opened??????????"); /*listBox1.Items.Add("no RFID-reader opened???????????");*/ }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.connection = new MySqlConnection(this.connectionString);
                this.connection.Open();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to connect"))
                {
                    MessageBox.Show("Unable to connect with the database");
                    this.Close();
                }
                MessageBox.Show(ex.Message);
            }

            this.sqlManager = new SqlManager(connection);

            this.rfidManager = new RFIDManager();
            this.rfidManager.tagFound += this.DisplayVisitorData;

            this.shop = new Stand();
            this.shop.Items = sqlManager.GetItems();
            this.ListAvaliableItems();

            tabControl1.TabPages[0].Text = "Loaning";
            tabControl1.TabPages[1].Text = "Returning";

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
            }
        }

        private void DisplayVisitorData(string tag)
        {
            if (this.btnOrder.InvokeRequired)
            {
                this.btnOrder.Invoke((MethodInvoker)delegate ()
                {
                    DisplayVisitorData(tag);
                });
            }
            else
            {
                try
                {
                    this.returningVisitor = sqlManager.GetVisitorByRfid(tag);
                    this.lbName.Text = $"{returningVisitor.FirstName} {returningVisitor.LastName}";
                    this.shop.UserItems = this.sqlManager.GetVisitorLoanedMaterials(returningVisitor.ID);
                    this.shop.UserTents = this.sqlManager.GetVisitorTent(returningVisitor.ID);
                    this.lbRentItems.Text = this.shop.UserItems.Count.ToString();
                    this.ListOwnedItems();
                    this.ListUserTents();
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Bracelet not found!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.shop.WantedItems.Count < 1)
            {
                return;
            }
            this.rfidManager.tagFound -= DisplayVisitorData;
            this.rfidManager.tagFound += this.ExecuteOrder;
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex >= 0)
            {
                var item = this.shop.GetAvaliableItems()[lstItems.SelectedIndex];
                this.label11.Text = (item).SellingPrice.ToString();
                this.pictureBox1.Image = (item).ItemImage;
                this.label13.Text = item.Quantity.ToString();
            }
        }

        private void lstOwned_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex >= 0)
            {
                var item = this.shop.UserItems[this.lstOwned.SelectedIndex];
                this.label11.Text = item.SellingPrice.ToString();
                this.pictureBox1.Image = item.ItemImage;
                this.label13.Text = item.Quantity.ToString();
            }
        }

        private void lsOfWantedFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsOfWantedFeatures.SelectedIndex >= 0)
            {
                var item = this.shop.WantedItems[this.lsOfWantedFeatures.SelectedIndex];
                this.label11.Text = item.SellingPrice.ToString();
                this.pictureBox1.Image = item.ItemImage;
                this.label13.Text = item.Quantity.ToString();
            }
        }

        private void btnSugestion_Click(object sender, EventArgs e)
        {
            InsertFavItem(tbSuggest.Text);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (this.lstOwned.SelectedIndex < 0)
            {
                return;
            }
            if (this.lstOwned.SelectedIndex >= 0)
            {
                var item = shop.UserItems[this.lstOwned.SelectedIndex];
                this.sqlManager.ReturnItem(item, this.returningVisitor.ID);

                this.shop.UserItems.Remove(item);
                this.ListOwnedItems();
                this.shop.Items = sqlManager.GetItems();
                this.ListAvaliableItems();
            }
        }

        public void InsertFavItem(string s)
        {
            string SQL = $"INSERT INTO `others_requesteditem`( `description`) VALUES('{s}');";

            try
            {
                MySqlCommand command = new MySqlCommand(SQL, connection);
                int i = command.ExecuteNonQuery();
                MessageBox.Show("Database affected");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListAvaliableItems()
        {
            this.lstItems.Items.Clear();
            foreach (var item in this.shop.Items)
            {
                this.lstItems.Items.Add(item.Name);
            }
        }

        private void ListOwnedItems()
        {
            this.lstOwned.Items.Clear();
            foreach (var item in this.shop.UserItems)
            {
                this.lstOwned.Items.Add(item.Name);
            }
        }

        private void ListWantedItems()
        {
            this.lsOfWantedFeatures.Items.Clear();
            foreach (var item in this.shop.WantedItems)
            {
                this.lsOfWantedFeatures.Items.Add(item.Name);
            }
            this.lbCost.Text = this.shop.WantedItems.Sum(x => x.SellingPrice * x.Quantity).ToString();
            this.lbCost.Visible = true;
        }

        private void ListUserTents()
        {
            this.lstTents.Items.Clear();
            foreach (var item in this.shop.UserTents)
            {
                this.lstTents.Items.Add($"Tent {item.size}-Person");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.lstItems.SelectedIndex < 0)
            {
                return;
            }
            var selectedIndex = this.lstItems.SelectedIndex;
            var wantedItem = shop.WantedItems.FirstOrDefault(x => x.Name == this.shop.Items[selectedIndex].Name);
            if (wantedItem == null)
            {
                var copy = ObjectCopier.Clone<Item>(this.shop.Items[selectedIndex]);
                copy.Quantity = 1;
                this.shop.WantedItems.Add(copy);
            }
            else
            {
                wantedItem.Quantity++;
            }

            if (this.shop.Items[selectedIndex].Quantity == 1)
            {
                this.shop.Items.Remove(this.shop.Items[selectedIndex]);
            }
            else
            {
                this.shop.Items[selectedIndex].Quantity--;
            }

            this.ListAvaliableItems();
            this.ListWantedItems();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.lsOfWantedFeatures.SelectedIndex < 0)
            {
                return;
            }
            var selectedIndex = this.lsOfWantedFeatures.SelectedIndex;
            var unwantedItem = this.shop.Items.FirstOrDefault(x => x.Name == this.shop.WantedItems[selectedIndex].Name);
            if (unwantedItem == null)
            {
                var copy = ObjectCopier.Clone<Item>(this.shop.WantedItems[selectedIndex]);
                copy.Quantity = 1;
                this.shop.Items.Add(copy);
            }
            else
            {
                unwantedItem.Quantity++;
            }

            if (this.shop.WantedItems[selectedIndex].Quantity > 1)
            {
                this.shop.WantedItems[selectedIndex].Quantity--;
            }
            else
            {
                this.shop.WantedItems.RemoveAt(selectedIndex);
            }

            this.ListAvaliableItems();
            this.ListWantedItems();
        }

        private void ExecuteOrder(string tag)
        {
            if (this.btnOrder.InvokeRequired)
            {
                this.btnOrder.Invoke((MethodInvoker)delegate ()
                {
                    ExecuteOrder(tag);
                });
            }
            else
            {
                try
                {
                    var visitor = this.sqlManager.GetVisitorByRfid(tag);

                    if (visitor.Balance >= this.shop.WantedItems.Sum(x => x.SellingPrice * x.Quantity))
                    {
                        foreach (var item in this.shop.WantedItems)
                        {
                            this.sqlManager.LoanAnItem(item, visitor.ID);
                        }
                    }
                    this.rfidManager.tagFound -= this.ExecuteOrder;
                    this.rfidManager.tagFound += this.DisplayVisitorData;
                    this.shop.WantedItems.Clear();
                    this.ListWantedItems();
                    this.shop.Items = this.sqlManager.GetItems();
                    this.ListAvaliableItems();
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Bracelet not found");
                }
            }
        }

        private void btnTentRet_Click(object sender, EventArgs e)
        {
            if (this.lstTents.SelectedIndex < 0)
            {
                return;
            }
            if (this.lstTents.SelectedIndex >= 0)
            {
                this.sqlManager.ReturnTent(this.shop.UserTents[this.lstTents.SelectedIndex], returningVisitor.ID);
                this.shop.UserTents.Remove(this.shop.UserTents[this.lstTents.SelectedIndex]);
                this.ListUserTents();
            }
        }

        private void lbName_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbRentItems_Click(object sender, EventArgs e)
        {

        }

        private void lbCost_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void glUser_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbSuggest_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
