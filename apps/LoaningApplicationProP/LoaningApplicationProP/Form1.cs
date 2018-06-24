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


namespace LoaningApplicationProP
{
    public partial class Form1 : Form
    {

        private RFID myRFIDReader;
        private MySqlConnection connection;
     

        List<Item> myItems = new List<Item>();
       
        Visitor currentVisitor;
        //Dumy data 
        Shop shop = new Shop("Loaning");

        List<Visitor> users = new List<Visitor>();
       
        public Form1()
        {
            InitializeComponent();
            try
            {
                myRFIDReader = new RFID();
               

                myRFIDReader.Tag += new RFIDTagEventHandler(ShowInfot);

                // listBox1.Items.Add("startup: so far so good.");
            }
            catch (PhidgetException) { MessageBox.Show("error at start-up."); }

            try
            {
                myRFIDReader.Open(); //if successfully, it will call the Attach-event.
            }
            catch (PhidgetException) { MessageBox.Show("no RFID-reader opened??????????"); /*listBox1.Items.Add("no RFID-reader opened???????????");*/ }

        }

        //******************************************************

        private void ProcessThisTag(object sender, RFIDTagEventArgs e)
        {
            MessageBox.Show("rfid has tag-nr: " + e.Tag);
        }
        private void ShowInfot(object sender, RFIDTagEventArgs e)
        {
            lbRentItems.Text = 0.ToString();
            int ok = 0;
            //just for test will make a list of all users 
            foreach (Visitor u1 in users)
            {
                if (u1.RFID == e.Tag)
                {
                    lbName.Text = u1.FirstName;
                    if (u1.RentedItems == null || u1.RentedItems.Count() == 0 )
                    {
                        lbRentItems.Text = 0.ToString();
                    }
                    else
                        lbRentItems.Text = u1.RentedItems.Count().ToString();
                    if (u1 != currentVisitor)
                    {
                        lstOwned.Items.Clear();
                        currentVisitor = u1;
                    }
                }
                else
                {                   
                    ok++;
                }
            }
            if (ok == users.Count)
            {
                MessageBox.Show("NO ONE uses this RFID " + e.Tag);
            }

          List<int> myIDs =  BringRentedItems(currentVisitor);
            //lstOwned.Items.Clear();
            int j=0;
            foreach (int i in myIDs)
            {
                Item currItem = shop.GetItem(i);
                if (!( currentVisitor.RentedItems.Contains(currItem) ))
                {
                    currentVisitor.RentedItems.Add(currItem);
                    
                }
                if(!(lstOwned.Items.Contains(currItem)))
                lstOwned.Items.Add(currItem);
                j = i;

            }


        }

        private Item FindFreeItem(string name)
        {
            foreach (Item i in myItems)
                if (i.Name == name)
                    if(i.Available =="A")
                {
                        i.Available = "T";
                    return i;
                }
            return null;
        }

        private int NrItems(string name)
        {
            int j = 0;
            foreach (Item i in myItems)
                if (i.Name == name)
                    if (i.Available == "A")
                    {
                        j++;
                        
                        
                    }
            return j;
        }


        //******************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            Item aItem = FindFreeItem((string)lstItems.SelectedItem);
            if (aItem == null)
                MessageBox.Show("No more items of this type");
            else
            try
            {
                //it takes the item does not substract from balance
                if (currentVisitor.LoanItem(shop, (aItem)))
                {
                    //changes the amount of rented items
                    lbRentItems.Text = currentVisitor.RentedItems.Count().ToString();
                    // add to the owned list and takes from the shop list 

                    DateTime d = DateTime.Today;
                    d = d.ToLocalTime();
                    int i =  d.Day;
                   
                    LoanItemDB(currentVisitor.ID,
                               (aItem).ItemID,
                              i); //should make it possible for the app user to chose the date he wants.
                    lstOwned.Items.Add((aItem));
                    lstItems.Items.Remove((aItem));
                    //it changes the number of items available .
                    label13.Text = NrItems(aItem.Name).ToString();
                    lstItems.SelectedIndex--;//not really usefull

                    

                }
                else
                {
                    MessageBox.Show("You cannot loan any more items." );
                }

            }
            catch (NullReferenceException f) { /*MessageBox.Show(f.Message);*/ }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();

            {

                BringItems();
                int i = 0;
                while (myItems.Count > i)
                {
                    //if (myItems[i].Available)
                    
                        if ( !(lstItems.Items.Contains(myItems[i].Name)) )
                        lstItems.Items.Add(myItems[i].Name);

                        shop.AddItem(myItems[i]);
                    
                    
                    i++;
                }
  
                bringUsers();
               // users.Add(u1);
             //  lsOfWantedFeatures.Items.Add (System.IO.Directory.GetCurrentDirectory());
            }
           
        }

        private void tbSuggest_TextChanged(object sender, EventArgs e)
        {


        }



        //Initialize values
        private void Initialize()
        {

            string connectionString =

          "server = 192.168.15.54;"
          + "database= dbi380752;"
          + "user id= dbi380752;"
          + "password =123456;"
          + "connect timeout = 30;"
          + "SslMode=none;";

            connection = new MySqlConnection(connectionString);


        }
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
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
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private Item FindItem(string name)
        {
            foreach (Item i in myItems)
                if (i.Name == name)
                {
                    return i;
                }
            return null;
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               Item i = FindItem((string)lstItems.SelectedItem);
                label7.Text = (i).ItemSize.ToString();
                label11.Text = (i).SellingPrice.ToString();
                pictureBox1.Image = (i).ItemImage;
                label13.Text = NrItems(i.Name).ToString();
            }
            catch {
               /* MessageBox.Show("You have to select a field.");*/
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // lstItems.Items.Add(i1.Name);
        }

        private void btnSugestion_Click(object sender, EventArgs e)
        {
            lsOfWantedFeatures.Items.Add(tbSuggest.Text);
            InsertFavItem(tbSuggest.Text);

        }

        private void lsOfWantedFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Item anItem = ((Item)lstOwned.SelectedItem);
            try
            {
                //returns the selected item if possible 
                if (currentVisitor.ReturnItem((anItem)))
                {
                    //changes the label so that the number of rented items is lower
                    lbRentItems.Text = currentVisitor.RentedItems.Count().ToString();

                    //adds the item in the  items list  and takes it from the owned list box
                    ReturnItemDB(currentVisitor.ID, ((anItem).ItemID));
                    anItem.Available = "A";
                   // lstItems.Items.Add((anItem));
                    lstOwned.Items.Remove((anItem));
                    label13.Text = NrItems(anItem.Name).ToString();
                    //lstItems.SelectedIndex--;// not that useful but i try to change the selected idex because it throws an error.


                    //want to put the change in the database delete it from loan item 
                    //and change the staus to A(available)

                   
             
                }
                else
                {
                    MessageBox.Show("There are no more items to return.");
                }

            }
            catch (NullReferenceException f) {/* MessageBox.Show(f.Message); */}//to put item retrun maybe.
        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lstOwned_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label7.Text = ((Item)lstOwned.SelectedItem).ItemSize.ToString();
                label11.Text = ((Item)lstOwned.SelectedItem).SellingPrice.ToString();
                pictureBox1.Image = ((Item)lstOwned.SelectedItem).ItemImage;
                label13.Text = NrItems(((Item)lstOwned.SelectedItem).Name).ToString(); 
            }
            catch
            {
               
            }
        }
        //should put the items only by name and then just put information abut the number

        // takes input from the database and converts to an image
        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            ms.Position = 0;
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        //takes image from input and converts to byte fomat good for geting out of database
        private byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private Sizes findSize(string s)
        {
            if (s == "S")
            {
                return Sizes.Small;
            }
            else if (s == "M")
            {
                return Sizes.Medium;
            }
            else if (s == "B")
            {
                return Sizes.Big;
            }

            return Sizes.Small;
        }

        private void BringItems()
        {
            string SQL = "SELECT `id`, `name`, `price`, `Size`, `Image`, `status` FROM `others_loanitem` WHERE 1;";
            /*`status` = 'A'*/
            try
            {
                MySqlDataReader reader;
                MySqlDataReader reader2;
                OpenConnection();

                MySqlCommand command = new MySqlCommand(SQL, connection);

                if (command != null)
                {
                    Sizes size = Sizes.Small;
                    
                    
                    reader2 = command.ExecuteReader();
                    reader2.Read();

                    int nrItm = nrItems(reader2["name"].ToString(),reader2);
                    //find a way to put for every item
                    //found a way to work around it...
                

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {


                        if (!reader.HasRows)
                            throw new Exception("There are no BLOBs to save");


                        size = findSize(reader["Size"].ToString());


                        myItems.Add(
                            new Item(size,
                            Convert.ToDouble(reader["price"]),
                            reader["name"].ToString(),
                            nrItm ,/*have to put a sql statement that gives me the number of these objects*/
            Convert.ToInt32(reader["id"]),
                            byteArrayToImage(reader["Image"] as byte[]),
                            reader["status"].ToString()
                                     )
                                    );

                    }
                }


                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void bringUsers()
        {
            string SQL = "SELECT `id`, `first_name`, `last_name`, `email`, `rfid_code`, `birth_date`, `event_money`, `id` FROM `tickets_visitor` WHERE 1";
            /////
            try
            {
                MySqlDataReader reader;
                OpenConnection();
               

                MySqlCommand command = new MySqlCommand(SQL, connection);

                if (command != null)
                {         
                    reader = command.ExecuteReader();                  
                    while (reader.Read())
                    {


                        if (reader.HasRows)
                            
                            
                                users.Add(
                                new Visitor(reader["first_name"].ToString(),
                                (reader["last_name"]).ToString(),
                                Convert.ToDouble(reader["event_money"]),
                                (reader["rfid_code"]).ToString(),
                                Convert.ToInt32(reader["id"])
                                          )
                                        );
                            
                            

                        
                    }
                }


                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int nrItems(string s,MySqlDataReader reader)
        {
            string SQL = $"SELECT count( `name`) FROM `others_loanitem` WHERE `name` = '{s}'";
            /////
            try
            {
                reader.Close();      

                MySqlCommand command = new MySqlCommand(SQL, connection);

                if (command != null)
                {
                   return int.Parse(command.ExecuteScalar().ToString());


                 
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1;
        }

        private List<int> BringRentedItems(Visitor v)
        {
            List<int> pItemsID = new List<int>();
            try
            {
                string SQL1 = $"SELECT  `item_id` FROM `others_loan` WHERE `visitor_id` = '{v.ID}'";
                //string SQL2 = $"SELECT count( `name`) FROM `others_loanitem` WHERE `name` = '{s}'";
                //string SQL3 = $"SELECT count( `name`) FROM `others_loanitem` WHERE `name` = '{s}'";

              
            

            MySqlDataReader reader;
            /////
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(SQL1, connection);
                
                if (command != null)
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        pItemsID.Add(Convert.ToInt32(reader["item_id"]));
                            
                    }
                     connection.Close();
                        reader.Close();
                }
                    
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
            catch {/* MessageBox.Show("You must have a user.");*/ }
            return pItemsID;
        }

        public void ReturnItemDB(int vID, int iID)
        {
            string SQL = $"  DELETE FROM `others_loan` WHERE `visitor_id` = {vID} AND`item_id` = {iID};";
            string SQL2 = $" UPDATE `others_loanitem` SET `status`= 'A' WHERE `id` = {iID};";

        
            try
            {
                OpenConnection();

                MySqlCommand command = new MySqlCommand(SQL, connection);
                 int i = command.ExecuteNonQuery();
                command.CommandText = SQL2;
                command.ExecuteNonQuery();
                MessageBox.Show("Database affected");


                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoanItemDB(int vID, int iID, int startDate)
        {
            //sets the new balance based on the amount the item costs.
            string SQL = $" UPDATE `tickets_visitor` SET `event_money`={(currentVisitor.EventBalance) } WHERE `id` = {vID};";
            string SQL2 = $" UPDATE `others_loanitem` SET `status`= 'T' WHERE `id` = {iID};";
            //put functionality to chose the dates lor loaning
            string SQL3 = $"INSERT INTO `others_loan`(`start_date`, `end_date`, `item_id`, `visitor_id`) VALUES ('2018-06-{startDate}','2018-06-30',{iID},{vID})";


            try
            {
                OpenConnection();

                MySqlCommand command = new MySqlCommand(SQL, connection);
                int i = command.ExecuteNonQuery();
                command.CommandText = SQL2;
                command.ExecuteNonQuery();
                command.CommandText = SQL3;
                command.ExecuteNonQuery();
                MessageBox.Show("Database affected");


                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsertFavItem(string s)
        {
            //sets the new balance based on the amount the item costs.
            string SQL = $"INSERT INTO `others_requesteditem`( `description`) VALUES('{s}');";



            try
            {
                OpenConnection();

                MySqlCommand command = new MySqlCommand(SQL, connection);
                int i = command.ExecuteNonQuery();
                MessageBox.Show("Database affected");


                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void label13_Click(object sender, EventArgs e)
        {

        }
    }



}
