using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Drawing;

namespace ShoppingApp
{
    class DatabaseInteraction
    {
        public MySqlConnection connection { get; set; }
        public DatabaseInteraction(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public void Initialize()
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

        public bool OpenConnection()
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
                        System.Windows.Forms.MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        System.Windows.Forms.MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }


        public void bringUsers( ref List<Visitor> users)
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
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            ms.Position = 0;
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public void BringItems( ref List<Item> myItems)
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



                    reader2 = command.ExecuteReader();
                    reader2.Read();

                    int nrItm = nrItems(reader2["name"].ToString(), reader2);
                    //find a way to put for every item
                    //found a way to work around it...


                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {


                        if (!reader.HasRows)
                            throw new Exception("There are no BLOBs to save");





                        myItems.Add(
                            new Item(
                            Convert.ToDouble(reader["price"]),
                            reader["name"].ToString(),
                            nrItm,/*have to put a sql statement that gives me the number of these objects*/
            Convert.ToInt32(reader["id"]),
                            byteArrayToImage(reader["Image"] as byte[]),
                            reader["status"].ToString()
                                     )
                                    );

                    }
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        public int nrItems(string s, MySqlDataReader reader)
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
                System.Windows.Forms.MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return -1;
        }
    }
}
