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
namespace LoaningApplicationProP
{
    public partial class Form1 : Form
    {

        private RFID myRFIDReader;
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        Item camera = new Item(Sizes.Medium, 122, "camera", 24, 1,Image.FromFile(@"C: \Users\Vlad.LUCA\Pictures\Images\canon_1263c006_eos_80d_dslr_camera_1225877.jpg"));
        Visitor u1 =new Visitor("Vlad", 500, "None","28007bd865");
        Visitor currentVisitor;
        //Dumy data 
        Shop shop = new Shop("Loaning");
        
        List<Visitor> users =new  List<Visitor>();
       // Item i1 = new Item(LoaningApplicationProP.Size.Small, 23, "camera");
        
        public Form1()
         {
            InitializeComponent(); try
            {
                myRFIDReader = new RFID();

               // myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                //myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
               // myRFIDReader.Tag += new RFIDTagEventHandler(ProcessThisTag);

               myRFIDReader.Tag += new RFIDTagEventHandler(ShowInfot);

               // listBox1.Items.Add("startup: so far so good.");
            }
            catch (PhidgetException) { MessageBox.Show("error at start-up.");  }

            try
            {
                myRFIDReader.Open(); //if successfully, it will call the Attach-event.
            }
            catch (PhidgetException) { MessageBox.Show("no RFID-reader opened??????????"); /*listBox1.Items.Add("no RFID-reader opened???????????");*/ }

     
           

        }


        //******************************************************


        // make databse conection and get a list of all the items available for loan.
        // maybe make a class for these objects

        //order button - updates the database with info of the loaned item that will have to
        //private void ShowWhoIsAttached(object sender, AttachEventArgs e)
        //{
        //    MessageBox.Show("RFIDReader attached!, device serial nr: " + myRFIDReader.DeviceSerialNumber);
        //}

        //private void ShowWhoIsDetached(object sender, DetachEventArgs e)
        //{
        //    MessageBox.Show("RFIDReader detached!, device serial nr: " + myRFIDReader.DeviceSerialNumber);
        //}

        private void ProcessThisTag(object sender, RFIDTagEventArgs e)
        {
            MessageBox.Show("rfid has tag-nr: " + e.Tag);
        }
        private void ShowInfot(object sender, RFIDTagEventArgs e)
        {
            //just for test will make a list of all users 
            foreach (Visitor u1 in users)
            {
                if (u1.RFID == e.Tag)
                {
                    lbName.Text = u1.FirstName;
                    lbFavoriteItem.Text = u1.FavoriteItem;
                    if (u1.RentedItems == null)
                    {
                        lbRentItems.Text = 0.ToString();
                    }
                    else
                        u1.RentedItems.Count().ToString();
                    currentVisitor = u1;
                    
                }
                else
                {
                    MessageBox.Show("NO ONE uses this RFID " + e.Tag);
                }
            }
        }

        public void SayHello(object sender, RFIDTagEventArgs e)
        {
            MessageBox.Show("Hello visitor with rfid-nr " + e.Tag +
                ".\nWelcome at our event ! ! !");
        }
    


    //******************************************************
    private void button1_Click(object sender, EventArgs e)
        {
            tbSuggest.Text = Application.ExecutablePath;
            try
            {
                //couls use this lower in the project
                string[]  tmp = ((lstItems.SelectedItem).ToString().Split(','));
                currentVisitor.LoanItem(shop, shop.GetItem(int.Parse(tmp[1])));
                lbRentItems.Text = currentVisitor.RentedItems.Count().ToString();               
                lstOwned.Items.Add($"{shop.GetItem(int.Parse(tmp[1]))}");

            }
            catch (NullReferenceException f) { MessageBox.Show(f.Message); }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
            OpenConnection();
            string myTake = "SELECT * FROM `tickets_visitor` WHERE 1";
            MySqlCommand command = new MySqlCommand(myTake, connection);
            //MySqlDataReader reader = command.ExecuteReader();
            //if (reader.Read())
            //{
            //    MessageBox.Show(reader[0].ToString());
            //}
            lstItems.Items.Add(camera);
            shop.AddItem(camera);
            users.Add(u1);
        }

        private void tbSuggest_TextChanged(object sender, EventArgs e)
        {

        }



        //Initialize values
        private void Initialize()
        {
            string connectionString = "server = studmysql01.fhict.local;"
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

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //build a way to store and take the information from selected items not hardcoded
            string[] tmp = ((lstItems.SelectedItem).ToString().Split(','));
            label7.Text = shop.GetItem(int.Parse(tmp[1])).ItemSize.ToString();
            label11.Text = shop.GetItem(int.Parse(tmp[1])).SellingPrice.ToString();
            pictureBox1.Image = shop.GetItem(int.Parse(tmp[1])).ItemImage;
            label13.Text = shop.GetItem(int.Parse(tmp[1])).Quantety.ToString();
            



        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           // lstItems.Items.Add(i1.Name);
        }

        private void btnSugestion_Click(object sender, EventArgs e)
        {
            lsOfWantedFeatures.Items.Add(tbSuggest.Text); 
        }

        private void lsOfWantedFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // should substract from the list 
            // make changes to the database 
            // put back in the application
            //
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
