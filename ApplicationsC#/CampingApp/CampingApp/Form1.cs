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

namespace CampingApp
{
    public partial class Form1 : Form
    {
        private const int RESERVATIONCOST = 30;
        Events ev;
        private RFID rfid;
        private string visitorTag;
        string connectionString;
        MySqlCommand cmd;
        DataTable dt = new DataTable("CheckIn Info");


        public Form1()
        {
            InitializeComponent();
            connectionString = "server=studmysql01.fhict.local;database=dbi380752;username=dbi380752;password=123456";
            ev = new Events();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rfid = new RFID();
            rfid.Open();
            rfid.Attach += RFIDstuffs;
            rfid.TagLost += RFIDuntag;
            var newTabPage = new TabPage() { Text = "CHECKOUT" };

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
        public void GetTag(object sender, RFIDTagEventArgs e)
        {
            MessageBox.Show(e.Tag);
        }
        public void RFIDcheckIn(object sender, RFIDTagEventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    connection.Open();
                    visitorTag = e.Tag;

                    //MessageBox.Show(e.Tag);
                    string displayQuery = "SELECT tickets_visitor.rfid_code, tickets_visitor.id, tickets_visitor.first_name, tickets_visitor.last_name, camping_spot.camping_id, camping_tent.size, camping_reservation.id " +
                                      " FROM tickets_visitor  " +
                                      " LEFT OUTER JOIN camping_reservation   ON (camping_reservation.visitor_id = tickets_visitor.id) " +
                                      " LEFT OUTER JOIN camping_spot   ON (camping_reservation.spot_id = camping_spot.id) " +
                                      " LEFT OUTER JOIN camping_tent  ON (camping_reservation.tent_id = camping_tent.id) " +
                                      " WHERE tickets_visitor.rfid_code = '" + visitorTag + "'";

                    cmd = new MySqlCommand(displayQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader[6].ToString() != "")
                        {
                            ev.AddVisitor(new Visitor() { FisrtName = (string)reader[2], LastName = (string)reader[3], VisitorID = (int)reader[1], Rfid = (string)reader[0] });
                            labelCheckStatus.Text = "CheckIn status: Successful";
                            labelName.Text = "FirstName: " + reader[2] + " LastName: " + reader[3];
                            labelCheckInfo.Text = "Camp #: " + reader[4] + Environment.NewLine + "Tent size: " + reader[5];

                        }
                        else
                        {
                            labelName.Text = "FirstName: " + reader[2] + " LastName: " + reader[3];
                            labelCheckInfo.Text = "Camp #: " + reader[4] + Environment.NewLine + "Tent size: " + reader[5];
                            labelCheckStatus.Text = "CheckIn status: UnSuccessful";
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Failed to connect to the database!");
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public void RFIDcheckOut(object sender, RFIDTagEventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    visitorTag = e.Tag;
                    connection.Open();

                    string displayQueryCheckOut = "SELECT tickets_visitor.rfid_code, tickets_visitor.id, tickets_visitor.first_name, " +
                                          "tickets_visitor.last_name, camping_spot.camping_id, camping_tent.size, " +
                                          "camping_reservation.id, camping_reservation.tent_id, camping_reservation.date_left " +
                                      " FROM tickets_visitor  " +
                                      " LEFT OUTER JOIN camping_reservation   ON (camping_reservation.visitor_id = tickets_visitor.id) " +
                                      " LEFT OUTER JOIN camping_spot   ON (camping_reservation.spot_id = camping_spot.id) " +
                                      " LEFT OUTER JOIN camping_tent  ON (camping_reservation.tent_id = camping_tent.id) " +
                                      " WHERE tickets_visitor.rfid_code = '" + visitorTag + "'";

                    cmd = new MySqlCommand(displayQueryCheckOut, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader[7].ToString() != "")
                        {
                            if (reader[8].ToString() == "")
                            {
                                VisitorInfo.Text = "FirstName: " + reader[2] + " LastName: " + reader[3];
                                CampNo.Text = "Camp #: " + reader[4] + Environment.NewLine + "Tent with size: " + reader[5] + " returned";

                                connection.Close();
                                string getCurrrectTentID = FindTentID(connection);
                                connection.Open();
                                string updateTent = "UPDATE camping_tent SET returned_time = '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "' WHERE id = '" + getCurrrectTentID + "' ";
                                cmd = new MySqlCommand(updateTent, connection);
                                cmd.ExecuteNonQuery();
                                connection.Close();

                                string getVisitorId = RetriveVisitorId(connection);
                                connection.Open();
                                string updateRes = "UPDATE camping_reservation SET date_left = '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "' WHERE visitor_id = '" + getVisitorId + "'";
                                cmd = new MySqlCommand(updateRes, connection);
                                cmd.ExecuteNonQuery();
                                break;
                            }
                            else
                            {
                                VisitorInfo.Text = "FirstName: " + reader[2] + " LastName: " + reader[3];
                                CampNo.Text = "Camp #: " + reader[4] + Environment.NewLine + "Tent with size: " + reader[5] + " returned";
                                MessageBox.Show("Already Checked Out");
                            }
                            
                        }
                        
                        else
                        {
                            if (reader[8].ToString() == "")
                            {
                                VisitorInfo.Text = "FirstName: " + reader[2] + " LastName: " + reader[3];
                                CampNo.Text = "Camp #: " + reader[4] + Environment.NewLine + " The visitor doesn't  have a tent to return";

                                string getVisitorId = RetriveVisitorId(connection);
                                connection.Open();
                                string updateRes = "UPDATE camping_reservation SET date_left = '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "' WHERE visitor_id = '" + getVisitorId + "'";
                                cmd = new MySqlCommand(updateRes, connection);
                                cmd.ExecuteNonQuery();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Already Checked Out");
                            }
                                               
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Failed to connect to the database!");
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RFIDuntag(object sender, RFIDTagLostEventArgs e)
        {
            rfid.Tag -= RFIDcheckIn;
            rfid.Tag -= RFIDcheckOut;
        }


        private void ShowFreeSpots()
        {
            listBox1.Items.Clear();
            ev.ClearSpots();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    connection.Open();
                    string displayQuery = "Select camping_number, free_beds " +
                                      "From camping_camping ";
                    cmd = new MySqlCommand(displayQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ev.AddFreeSpots(new FreeSpots() { CampId = (int)reader[0], SpotNo = (int)reader[1] });
                    }

                    foreach (FreeSpots f in ev.GetListOfFreeSpots())
                    {
                        listBox1.Items.Add(f.AsString());
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Failed to connect to the database!");
            }

        }
        private void Insert()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    FreeSpots f = new FreeSpots();
                    f.CampId = int.Parse(textBoxCampID.Text);
                    f.SpotNo = int.Parse(textBoxSpotNo.Text);
                    string visId = RetriveVisitorId(connection);
                    long lastIdtent = 0;

                    if (textBoxTentSize.Text != "")
                    {
                        if (f.SpotNo <= int.Parse(CheckSpotsAvailable(connection)))
                        {
                            connection.Open();
                            string insertSpot = "INSERT INTO camping_spot (camping_id, beds_taken) VALUES ('" + f.CampId + "', '" + f.SpotNo + "')";
                            cmd = new MySqlCommand(insertSpot, connection);
                            cmd.ExecuteNonQuery();
                            long lastIdCamp = cmd.LastInsertedId;

                            string updateCam = "UPDATE camping_camping SET free_beds = free_beds - '" + f.SpotNo + "' WHERE camping_number = '" + f.CampId + "'";
                            cmd = new MySqlCommand(updateCam, connection);
                            cmd.ExecuteNonQuery();
                            
                            if (int.Parse(textBoxTentSize.Text) == 2 || int.Parse(textBoxTentSize.Text) == 4 || int.Parse(textBoxTentSize.Text) == 6)
                            {
                                string insertTent = "INSERT INTO camping_tent (size,taken_time) VALUES ('" + int.Parse(textBoxTentSize.Text) + "', '" + System.DateTime.Now.ToString("yyyy-MM-dd  hh-mm-ss") + "') ";
                                cmd = new MySqlCommand(insertTent, connection);
                                cmd.ExecuteNonQuery();
                                lastIdtent = cmd.LastInsertedId;
                            }
                            else
                            {
                                MessageBox.Show("You have three tent size options: 2 , 4 , 6! Choose one of them!");
                            }
                            string insertRes = "INSERT INTO camping_reservation (visitor_id, tent_id, spot_id, date_taken) VALUES ('" + visId + "', '" + lastIdtent + "', '" + lastIdCamp + "', '" + System.DateTime.Now.ToString("yyyy-MM-dd  hh-mm-ss") + "')";
                            cmd = new MySqlCommand(insertRes, connection);
                            cmd.ExecuteNonQuery();

                            string updateMoney = "UPDATE tickets_visitor SET event_money = event_money - '" + RESERVATIONCOST + "' WHERE rfid_code = '" + visitorTag + "'";
                            cmd = new MySqlCommand(updateMoney, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("There are not more available spaces on this spot");
                        }
                    }
                    else
                    {
                        if (f.SpotNo <= int.Parse(CheckSpotsAvailable(connection)))
                        {
                            connection.Open();
                            string insertSpot = "INSERT INTO camping_spot (camping_id, beds_taken) VALUES ('" + f.CampId + "', '" + f.SpotNo + "')";
                            cmd = new MySqlCommand(insertSpot, connection);
                            cmd.ExecuteNonQuery();
                            long lastIdCamp = cmd.LastInsertedId;
                            string updateCam = "UPDATE camping_camping SET free_beds = free_beds - '" + f.SpotNo + "' WHERE camping_number = '" + f.CampId + "'";
                            cmd = new MySqlCommand(updateCam, connection);
                            cmd.ExecuteNonQuery();
                            string insertRes = "INSERT INTO camping_reservation (visitor_id, spot_id, date_taken) VALUES (" + visId + ", " + lastIdCamp + ", '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "')";
                            cmd = new MySqlCommand(insertRes, connection);
                            cmd.ExecuteNonQuery();
                            string updateMoney = "UPDATE tickets_visitor SET event_money = event_money - '" + RESERVATIONCOST + "' WHERE rfid_code = '" + visitorTag + "'";
                            cmd = new MySqlCommand(updateMoney, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("There are not more available spaces on this spot");
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Failed to connect to the database!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Type the correct input stuff in the correct places");
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            rfid.Tag += RFIDcheckIn;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Insert();
            textBoxCampID.Text = "";
            textBoxSpotNo.Text = "";
            textBoxTentSize.Text = "";
            ShowFreeSpots();
        }

        private void buttonShowSpots_Click(object sender, EventArgs e)
        {
            ShowFreeSpots();
        }

        private void buttonTent_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    long lastIdtent = 0;
                    if (int.Parse(textBoxTentSize.Text) == 2 || int.Parse(textBoxTentSize.Text) == 4 || int.Parse(textBoxTentSize.Text) == 6)
                    {
                        connection.Close();
                        GetResDetails add = RetriveResIDs(connection);
                        connection.Open();
                        string insertTent = "INSERT INTO camping_tent (size,taken_time) VALUES ('" + int.Parse(textBoxTentSize.Text) + "', '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "') ";
                        cmd = new MySqlCommand(insertTent, connection);
                        cmd.ExecuteNonQuery();
                        lastIdtent = cmd.LastInsertedId;
                        string updateRes = "UPDATE camping_reservation SET tent_id = '"+lastIdtent+"' WHERE visitor_id = '"+add.Visitor_id+"'";
                        cmd = new MySqlCommand(updateRes, connection);
                        cmd.ExecuteNonQuery();
                        textBoxTentSize.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("You have three tent size options: 2 , 4 , 6! Choose one of them!");
                    }                 
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Failed to connect to the database!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Type the correct input stuff in the correct places");
            }

        }
        private string RetriveVisitorId(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                string query = "SELECT id " +
                          "FROM tickets_visitor " +
                          "WHERE rfid_code='" + visitorTag + "'";
                cmd = new MySqlCommand(query, connection);
                string res = cmd.ExecuteScalar().ToString();
                connection.Close();
                return res;
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Failed to connect to the database!");
                return null;
            }
        }
        private GetResDetails RetriveResIDs(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                string query = "SELECT spot_id, visitor_id " +
                               "FROM camping_reservation " +
                               "JOIN tickets_visitor ON (tickets_visitor.id = camping_reservation.visitor_id) " +
                               "WHERE tickets_visitor.rfid_code = '" + visitorTag + "' ";
                cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                ev.AddOnlyTent(new GetResDetails() { Spot_id = (int)reader[0], Visitor_id = (int)reader[1] });
                connection.Close();
                return ev.GetDetails();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Failed to connect to the database!");
                return null;
            }

        }
        private string CheckSpotsAvailable(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                string query = "SELECT free_beds " +
                    "FROM camping_camping " +
                    "WHERE camping_number = '" + textBoxCampID.Text + "'";
                cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string free_spots = reader[0].ToString();
                connection.Close();
                return free_spots;
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Failed to connect to the database!");
                return null;
            }
        }
        public string FindTentID(MySqlConnection connection)
        {
            string getVisitorId = RetriveVisitorId(connection);
            connection.Open();
            string findTentId = "SELECT tent_id " +
                "FROM camping_reservation " +
                "WHERE visitor_id = '" + getVisitorId + "'";
            cmd = new MySqlCommand(findTentId, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            string res = reader[0].ToString();
            connection.Close();
            return res;

        }
        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            rfid.Tag += RFIDcheckOut;
        }
    }
}
