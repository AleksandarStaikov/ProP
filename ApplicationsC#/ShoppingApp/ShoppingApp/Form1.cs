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
using System.Collections.Specialized;
using System.Drawing.Printing;

namespace ShoppingApp
{
    public partial class Form1 : Form
    {
        public ChoseShop shop;
        private RFID myRFIDReader;
        private MySqlConnection connection = new MySqlConnection();
        private SqlMannager sqlMannager;
        private RFIDManager rfidManager;
        List<Item> myItems;
        Visitor currentVisitor;
        List<Visitor> users = new List<Visitor>();
        List<Item> ordered;
        double totalPrice = 0;


        public Form1()
        {

            InitializeComponent();
            tabControl1.TabPages[2].Enter += new EventHandler(fillListBox);
            tabPage1.Text = "Drinks";
            tabPage2.Text = "Foods";
            tabPage3.Text = "Ordered items";
            myItems = new List<Item>();
            ordered = new List<Item>();
            try
            {
                //myRFIDReader = new RFID();


                //myRFIDReader.Tag += new RFIDTagEventHandler(ShowInfot);

                // listBox1.Items.Add("startup: so far so good.");
            }
            catch (PhidgetException) { MessageBox.Show("error at start-up."); }

            try
            {
                //myRFIDReader.Open(); //if successfully, it will call the Attach-event.
            }
            catch (PhidgetException) { MessageBox.Show("no RFID-reader opened??????????"); /*listBox1.Items.Add("no RFID-reader opened???????????");*/ }

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.connection = new MySqlConnection(this.GetConnectionString());
            this.OpenConnection();
            this.sqlMannager = new SqlMannager(connection);
            this.rfidManager = new RFIDManager();
         
            //Form1 frm = new Form1()
            //subscribe to events in chosenShop


            //FillListBoxes();
        }

        public void fillListBox(object e, EventArgs r)
        {
            lsbAllOrder.Items.Clear();
            foreach (Item i in lsbHaveDrinks.Items)
            {
                lsbAllOrder.Items.Add(i);
            }
            foreach (Item i in lsbHaveFood.Items)
            {
                lsbAllOrder.Items.Add(i);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        public string GetConnectionString()
        {

            return
              "server = 192.168.15.54;"
              + "database= dbi380752;"
              + "user id= dbi380752;"
              + "password =123456;"
              + "connect timeout = 30;"
              + "SslMode=none;";
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        System.Windows.Forms.MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        System.Windows.Forms.MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private void FillListBoxes()
        {
            foreach (var x in myItems)
            {
                if (x.Type == "Drink")
                {
                    lsbTakeDrinks.Items.Add(x);
                }
                else if (x.Type == "Food")
                {
                    lsbTakeFood.Items.Add(x);
                }
            }
        }

        private Item FindFreeItem(string name)
        {
            foreach (Item i in myItems)
                if (i.Name == name)
                    return i;
            return null;
        }

        // how to combine in one method?
        private void lsbTakeFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item aItm = ((Item)lsbTakeFood.SelectedItem);
            try
            {
                pictureBox2.Image = aItm.ItemImage;
            }
            catch
            {
                //  MessageBox.Show("There was a problem loading the image");

            }
        }
        // how to combine in one method?
        private void lsbTakeDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item aItm = ((Item)lsbTakeDrinks.SelectedItem);
            try
            {
                pictureBox1.Image = aItm.ItemImage;
            }
            catch (System.NullReferenceException)
            {
                //  MessageBox.Show("There was a problem loading the image");

            }
        }

        //add drinks
        private void button1_Click(object sender, EventArgs e)
        {
            if (nud1.Value == 0)
            {
                MessageBox.Show("Cannot add 0 items");
            }
            else
            {
                try
                {
                    Item temp = new Item(0, "nothing", 0, 0, null, "not");
                    Item temp2 = null;
                    int quant = temp.Quantity;

                    temp.SellingPrice = ((Item)lsbTakeDrinks.SelectedItem).SellingPrice;
                    temp.Quantity = Convert.ToInt32(nud1.Value);
                    temp.Name = ((Item)lsbTakeDrinks.SelectedItem).Name;
                    temp.ItemImage = ((Item)lsbTakeDrinks.SelectedItem).ItemImage;
                    temp.Type = ((Item)lsbTakeDrinks.SelectedItem).Type;
                    temp.HoldId = ((Item)lsbTakeDrinks.SelectedItem).HoldId;

                    // int quant = temp.Quantity;
                    //adds the selected item to the other list and in the orderd items list.
                    bool found = false;
                    foreach (Item i in ordered)
                    {
                        if (i.Name == temp.Name)
                        {

                            temp.Quantity += i.Quantity;
                            lsbHaveDrinks.Items.Remove(i);
                            temp2 = i;
                            found = true;
                        }

                    }
                    ordered.Remove(temp2);
                    ordered.Add(temp);

                    if (!found)
                        ordered[ordered.Count() - 1].Quantity = Convert.ToInt32(nud1.Value);

                    totalPrice += (!found)
                          ? ordered[ordered.Count() - 1].Quantity * ordered[ordered.Count() - 1].SellingPrice
                            : ordered[ordered.Count() - 1].Quantity * ordered[ordered.Count() - 1].SellingPrice - quant * ordered[ordered.Count() - 1].SellingPrice;

                    FillPrice();

                    lsbHaveDrinks.Items.Add(temp);

                    ((Item)lsbTakeDrinks.SelectedItem).TakeSomeItems(Convert.ToInt32(nud1.Value));
                    temp2 = ((Item)lsbTakeDrinks.SelectedItem);
                    lsbTakeDrinks.Items.Remove(((Item)lsbTakeDrinks.SelectedItem));
                    lsbTakeDrinks.Items.Add(temp2);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        //add food
        private void button4_Click(object sender, EventArgs e)
        {

            if (nud2.Value == 0)
            {
                MessageBox.Show("Cannot add 0 items");
            }
            else
            {
                try
                {
                    Item temp = new Item(0, "nothing", 0, 0, null, "not");
                    Item temp2 = null; ;
                    int quant = temp.Quantity;

                    temp.SellingPrice = ((Item)lsbTakeFood.SelectedItem).SellingPrice;
                    temp.Quantity = Convert.ToInt32(nud2.Value);
                    temp.Name = ((Item)lsbTakeFood.SelectedItem).Name;
                    temp.ItemImage = ((Item)lsbTakeFood.SelectedItem).ItemImage;
                    temp.Type = ((Item)lsbTakeFood.SelectedItem).Type;
                    temp.HoldId = ((Item)lsbTakeFood.SelectedItem).HoldId;


                    bool found = false;
                    foreach (Item i in ordered)
                    {
                        if (i.Name == temp.Name)
                        {
                            quant = i.Quantity;
                            temp.Quantity += i.Quantity;
                            lsbHaveFood.Items.Remove(i);
                            temp2 = i;
                            found = true;
                        }

                    }


                    //adds the selected item to the other list and in the orderd items list.

                    ordered.Remove(temp2);
                    ordered.Add(temp);

                    if (!found)
                        ordered[ordered.Count() - 1].Quantity = Convert.ToInt32(nud2.Value);

                    totalPrice += (!found)
                                ? ordered[ordered.Count() - 1].Quantity * ordered[ordered.Count() - 1].SellingPrice
                                : ordered[ordered.Count() - 1].Quantity * ordered[ordered.Count() - 1].SellingPrice - quant * ordered[ordered.Count() - 1].SellingPrice;

                    FillPrice();

                    lsbHaveFood.Items.Add(temp);
                    ((Item)lsbTakeFood.SelectedItem).TakeSomeItems(Convert.ToInt32(nud2.Value));

                    temp2 = ((Item)lsbTakeFood.SelectedItem);
                    lsbTakeFood.Items.Remove(((Item)lsbTakeFood.SelectedItem));
                    lsbTakeFood.Items.Add(temp2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// It changes the label values acordingly;
        /// </summary>
        public void FillPrice()
        {
            lbBalance.Text = totalPrice.ToString();
            lbBalance2.Text = totalPrice.ToString();
            labelBalance3.Text = totalPrice.ToString();
        }

        //find a way to genarilaze this
        public void RemoveFromLSBxItemsOnSelected(ListBox myListBox, int quantaty, Item temp)
        {
            if (temp.Quantity != 0)
            {
                totalPrice -= temp.SellingPrice * quantaty;
                temp.Quantity -= quantaty;
                if (temp.Quantity != 0)
                {
                    myListBox.Items.Remove(temp);
                    myListBox.Items.Add(temp);
                }
                else
                {
                    myListBox.Items.Remove(temp);
                }

            }
            else
            {
                myListBox.Items.Remove(temp);
            }
        }

        public void PutBackInOriginal(ListBox myTake, int quantaty, Item temp)
        {
            Item temp2 = null;
            foreach (Item item in myItems)
            {
                if (item.Name == temp.Name)
                {
                    //take from here and put in in lsb but first change the quant of this 
                    item.Quantity += quantaty;

                    temp2 = item;
                    break;
                }

            }

            foreach (Item item in myTake.Items)
            {
                if (item.Name == temp2.Name)
                {
                    myTake.Items.Remove(item);
                    myTake.Items.Add(temp2);
                    break;
                }
            }
        }
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            Item temp = ((Item)lsbHaveDrinks.SelectedItem);
            int quanta = temp.Quantity;
            // substract from total sum and update the item for listbox.
            try
            {

                this.RemoveFromLSBxItemsOnSelected(lsbHaveDrinks, quanta, temp);
                this.PutBackInOriginal(lsbTakeDrinks, quanta, temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            FillPrice();
        }

        //remove 1 drink
        private void button2_Click(object sender, EventArgs e)
        {
            Item temp = ((Item)lsbHaveDrinks.SelectedItem);
            
            // substract from total sum and update the item for listbox.
            try
            {

                this.RemoveFromLSBxItemsOnSelected(lsbHaveDrinks, 1, temp);
                this.PutBackInOriginal(lsbTakeDrinks, 1, temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            FillPrice();
        }






        private void button6_Click(object sender, EventArgs e)
        {
            this.rfidManager.tagFound += this.RunTransactions;
        }

        private void RunTransactions(string tag)
        {
            // x get the user rfid 
            // x get user id from db
            // x add a purchase (put the time and the visitor id)  -> purchase id 
            // x foreach item in order decrease amount and create orrder record
            // x detach method form event

            if (label18.InvokeRequired)
            {
                label18.Invoke((MethodInvoker)delegate ()
                {
                    this.RunTransactions(tag);
                });
            }
            else
            {
                var visitorId = this.sqlMannager.GetUserIDByRfid(tag);
            var purchaseId = this.sqlMannager.AddAPurchase(visitorId);

            foreach (var item in this.ordered)
            {
                this.sqlMannager.AddOrder(item, purchaseId);
            }
            this.sqlMannager.DecreaseVisitorMoney(visitorId, totalPrice);

            this.rfidManager.tagFound -= RunTransactions;
            MessageBox.Show("Transaction Successfull");
                lsbHaveFood.Items.Clear();
                lsbHaveDrinks.Items.Clear();
                
            }

            

            // clear form
        }

        private void btnSelectShop_Click(object sender, EventArgs e)
        {

        }

        private void SelectedShop()
        {
            this.myItems = sqlMannager.LoadShopItems(shop.Choice);
            this.FillListBoxes();
        }

        private void btnRemoveAll2_Click(object sender, EventArgs e)
        {
            Item temp = ((Item)lsbHaveFood.SelectedItem);
            int quanta = temp.Quantity;
            // substract from total sum and update the item for listbox.
            try
            {

                this.RemoveFromLSBxItemsOnSelected(lsbHaveFood, quanta, temp);
                this.PutBackInOriginal(lsbTakeFood, quanta, temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            FillPrice();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Item temp = ((Item)lsbHaveFood.SelectedItem);
            int quanta = temp.Quantity;
            // substract from total sum and update the item for listbox.
            try
            {

                this.RemoveFromLSBxItemsOnSelected(lsbHaveFood, 1, temp);
                this.PutBackInOriginal(lsbTakeFood, 1, temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            FillPrice();
        }

        private void btnChoseShop_Click(object sender, EventArgs e)
        {
            shop = new ChoseShop();
            shop.button1c += new ChoseShop.myChoiceEventHandler(SelectedShop);
            shop.button2c += new ChoseShop.myChoiceEventHandler(SelectedShop);
            shop.button3c += new ChoseShop.myChoiceEventHandler(SelectedShop);
            shop.button4c += new ChoseShop.myChoiceEventHandler(SelectedShop);
            btnChoseShop.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //****************************************************
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
            totalPrice = 0;
            FillPrice();
            //****************************************************

        }

     
        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            totalPrice = 0;
            int total = 0;          
            double change = 0;

            //this prints the reciept

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("Event Name: Mascarada", new Font("Courier New", 18), new SolidBrush(Color.Black), startX-4, startY);
            offset = offset + (int)fontHeight;
            graphic.DrawString("Shop: Food Shop", new Font("Courier New", 18), new SolidBrush(Color.Black), startX -4, startY = offset);
            string top = "Item Name".PadRight(30) + "Price";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            double totalprice = 0;
            foreach (Item item in lsbAllOrder.Items)
            {
                //create the string to print on the reciept
                string productDescription = item.Name;

                double productPrice = item.SellingPrice;

                //MessageBox.Show(item.Substring(item.Length - 5, 5) + "PROD TOTAL: " + productTotal);


                totalprice += productPrice;

                if (productDescription.Contains("  -"))
                {
                    string productLine = productDescription.Substring(0, 24);

                    graphic.DrawString(productLine, new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }
                else
                {
                    string productLine = productDescription + $"\t\t\t\t\t{productPrice}";

                    graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);
                   // graphic.DrawString(productPrice.ToString(), font, new SolidBrush(Color.Black), startX + 300, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }

            }


          

           

            //when we have drawn all of the items add the total

            offset = offset + 20; //make some room so that the total stands out.

            graphic.DrawString("Total to pay ".PadRight(30) + String.Format("{0:c}", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 30; //make some room so that the total stands out.        
                                  //  graphic.DrawString("CHANGE ".PadRight(30) + String.Format("{0:c}", change), font, new SolidBrush(Color.Black), startX, startY + offset);
                                  //  offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString("     Customer support telephone: 0603334567", new Font("Courier New", 9), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("     Customer support email: mascarada@yahoo.com", new Font("Courier New", 9), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 30;
            graphic.DrawString("     Thank-you for your custom,", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("       please come back soon!", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lbBalance_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lbBalance2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool maximized = false;
        private void button8_Click(object sender, EventArgs e)
        {
            if (maximized == false)
            {
                this.WindowState = FormWindowState.Maximized;
                maximized = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                maximized = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel4_Click(object sender, EventArgs e)
        {

        }
    }
}