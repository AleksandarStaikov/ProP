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
        private RfidManager rfidManager;


        public Form1()
        {
            InitializeComponent();
            connectionString = "server=studmysql01.fhict.local;database=dbi380752;username=dbi380752;password=123456";
            ev = new Events();
            rfidManager = new RfidManager();
            labelInfo.Text = "Press CheckIN!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rfid = new RFID();
            rfid.Open();
            rfid.Attach += RFIDstuffs;
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
        
        public void RFIDcheckIn(string rfidTag)
        {
            if (labelInfo.InvokeRequired)
            {
                labelInfo.Invoke((MethodInvoker)delegate ()
                {
                    RFIDcheckIn(rfidTag);
                });
            }
            else
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {

                        connection.Open();
                        visitorTag = rfidTag;
                        string displayQuery = "SELECT tickets_visitor.rfid_code, tickets_visitor.id," +
                                              " tickets_visitor.first_name, tickets_visitor.last_name, camping_spot.camping_id," +
                                              " camping_tent.size, camping_reservation.id, camping_tent.id " +
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
                                ev.AddVisitor(new Visitor() { FisrtName = (string)reader[2], LastName = (string)reader[3], ID = (int)reader[1], Rfid = (string)reader[0] });
                                labelInfo.Text = "Check In Successful";

                            }
                            else
                            {
                                MessageBox.Show("Check In Unsuccessful! Please make a reservation!");

                            }
                        }
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show("Failed to connect to the database!");
                }
            }
            rfidManager.tagFound -= RFIDcheckIn;
            labelInfo.Text = "";
        }
        //public void RFIDcheckOut(object sender, RFIDTagEventArgs e)
        //{
        //    try
        //    {
        //        using (MySqlConnection connection = new MySqlConnection(connectionString))
        //        {

        //            visitorTag = e.Tag;
        //            connection.Open();

        //            string displayQueryCheckOut = "SELECT tickets_visitor.rfid_code, tickets_visitor.id, tickets_visitor.first_name, " +
        //                                  "tickets_visitor.last_name, camping_spot.camping_id, camping_tent.size, " +
        //                                  "camping_reservation.id, camping_reservation.tent_id, camping_reservation.date_left " +
        //                              " FROM tickets_visitor  " +
        //                              " LEFT OUTER JOIN camping_reservation   ON (camping_reservation.visitor_id = tickets_visitor.id) " +
        //                              " LEFT OUTER JOIN camping_spot   ON (camping_reservation.spot_id = camping_spot.id) " +
        //                              " LEFT OUTER JOIN camping_tent  ON (camping_reservation.tent_id = camping_tent.id) " +
        //                              " WHERE tickets_visitor.rfid_code = '" + visitorTag + "'";

        //            cmd = new MySqlCommand(displayQueryCheckOut, connection);
        //            MySqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                if (reader[7].ToString() != "")
        //                {
        //                    if (reader[8].ToString() == "")
        //                    {
        //                        VisitorInfo.Text = "FirstName: " + reader[2] + " LastName: " + reader[3];
        //                        CampNo.Text = "Camp #: " + reader[4] + Environment.NewLine + "Tent with size: " + reader[5] + " returned";

        //                        connection.Close();
        //                        string getCurrrectTentID = FindTentID(connection);
        //                        connection.Open();
        //                        string updateTent = "UPDATE camping_tent SET returned_time = '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "' WHERE id = '" + getCurrrectTentID + "' ";
        //                        cmd = new MySqlCommand(updateTent, connection);
        //                        cmd.ExecuteNonQuery();
        //                        connection.Close();

        //                        string getVisitorId = RetriveVisitorId(connection);
        //                        connection.Open();
        //                        string updateRes = "UPDATE camping_reservation SET date_left = '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "' WHERE visitor_id = '" + getVisitorId + "'";
        //                        cmd = new MySqlCommand(updateRes, connection);
        //                        cmd.ExecuteNonQuery();
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        VisitorInfo.Text = "FirstName: " + reader[2] + " LastName: " + reader[3];
        //                        CampNo.Text = "Camp #: " + reader[4] + Environment.NewLine + "Tent with size: " + reader[5] + " returned";
        //                        MessageBox.Show("Already Checked Out");
        //                    }

        //                }

        //                else
        //                {
        //                    if (reader[8].ToString() == "")
        //                    {
        //                        VisitorInfo.Text = "FirstName: " + reader[2] + " LastName: " + reader[3];
        //                        CampNo.Text = "Camp #: " + reader[4] + Environment.NewLine + " The visitor doesn't  have a tent to return";

        //                        string getVisitorId = RetriveVisitorId(connection);
        //                        connection.Open();
        //                        string updateRes = "UPDATE camping_reservation SET date_left = '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "' WHERE visitor_id = '" + getVisitorId + "'";
        //                        cmd = new MySqlCommand(updateRes, connection);
        //                        cmd.ExecuteNonQuery();
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Already Checked Out");
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    catch (MySql.Data.MySqlClient.MySqlException)
        //    {
        //        MessageBox.Show("Failed to connect to the database!");
        //    }
        //    catch (MyException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        


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
        private void Insert(string rfidTag)
        {
            if (lbStatus.InvokeRequired)
            {
                lbStatus.Invoke((MethodInvoker)delegate ()
                {
                    Insert(rfidTag);
                });
            }
            else
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        FreeSpots f = new FreeSpots();
                        f.CampId = int.Parse(textBoxCampID.Text);
                        f.SpotNo = int.Parse(textBoxSpotNo.Text);
                        visitorTag = rfidTag;
                        double eventMoney = double.Parse(GetEventMoney(connection));
                        string visId = RetriveVisitorId(connection);
                        long lastIdtent = 0;
                        if (textBoxTentSize.Text != "")
                        {
                            if (f.SpotNo <= int.Parse(CheckSpotsAvailable(connection)))
                            {
                                if (eventMoney >= RESERVATIONCOST)
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
                                    string insertRes = "INSERT INTO camping_reservation (visitor_id, tent_id, spot_id) VALUES ('" + visId + "', '" + lastIdtent + "', '" + lastIdCamp + "')";
                                    cmd = new MySqlCommand(insertRes, connection);
                                    cmd.ExecuteNonQuery();

                                    string updateMoney = "UPDATE tickets_visitor SET event_money = event_money - '" + RESERVATIONCOST + "' WHERE rfid_code = '" + visitorTag + "'";
                                    cmd = new MySqlCommand(updateMoney, connection);
                                    cmd.ExecuteNonQuery();
                                    connection.Close();
                                }
                                else
                                {
                                    MessageBox.Show("You dont have enough money in your bank account!");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There are not more available spaces on this spot");
                            }
                            MessageBox.Show("Reservation successful!");
                        }

                        else
                        {
                            if (f.SpotNo <= int.Parse(CheckSpotsAvailable(connection)))
                            {
                                if (eventMoney >= RESERVATIONCOST)
                                {
                                    connection.Open();
                                    string insertSpot = "INSERT INTO camping_spot (camping_id, beds_taken) VALUES ('" + f.CampId + "', '" + f.SpotNo + "')";
                                    cmd = new MySqlCommand(insertSpot, connection);
                                    cmd.ExecuteNonQuery();
                                    long lastIdCamp = cmd.LastInsertedId;
                                    string updateCam = "UPDATE camping_camping SET free_beds = free_beds - '" + f.SpotNo + "' WHERE camping_number = '" + f.CampId + "'";
                                    cmd = new MySqlCommand(updateCam, connection);
                                    cmd.ExecuteNonQuery();
                                    string insertRes = "INSERT INTO camping_reservation (visitor_id, spot_id) VALUES (" + visId + ", " + lastIdCamp + ")";
                                    cmd = new MySqlCommand(insertRes, connection);
                                    cmd.ExecuteNonQuery();
                                    string updateMoney = "UPDATE tickets_visitor SET event_money = event_money - '" + RESERVATIONCOST + "' WHERE rfid_code = '" + visitorTag + "'";
                                    cmd = new MySqlCommand(updateMoney, connection);
                                    cmd.ExecuteNonQuery();
                                    connection.Close();
                                }
                                else
                                {
                                    MessageBox.Show("You dont have enough money in your bank account!");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There are not more available spaces on this spot");
                            }
                            MessageBox.Show("Reservation successful!");
                        }
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show("Failed to connect to the database!");
                }
                catch (FormatException e)
                {
                    MessageBox.Show(e.Message);
                    //MessageBox.Show("Type the correct input stuff in the correct places");
                }
                catch (MyException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                textBoxCampID.Text = "";
                textBoxSpotNo.Text = "";
                textBoxTentSize.Text = "";
                lbResStatus.Text = "";
                rfidManager.tagFound -= Insert;
                tabControl1.SelectedTab = tabPageCheckIn;

            }

        }
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            labelInfo.Text = "Scan your bracelet!";
            rfidManager.tagFound += RFIDcheckIn;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            rfidManager.tagFound += Insert;
            lbResStatus.Text = "Please tag your RFID braclet";
        }
        private void AddTent(string rfidTag)
        {
            visitorTag = rfidTag;
            if (lbStatus.InvokeRequired)
            {
                lbStatus.Invoke((MethodInvoker)delegate ()
                {
                    AddTent(rfidTag);
                });
            }
            else
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        GetResDetails add = RetriveResIDs(connection); ;
                        long lastIdtent = 0;
                        int money = 0;
                        double eventMoney = double.Parse(GetEventMoney(connection));
                        if (int.Parse(textBoxtent.Text) == 2 || int.Parse(textBoxtent.Text) == 4 || int.Parse(textBoxtent.Text) == 6)
                        {

                            if (textBoxtent.Text == "2")
                            {
                                money = 15;
                                if (add != null)
                                {
                                    if (eventMoney >= money)
                                    {
                                        connection.Open();
                                        string insertTent = "INSERT INTO camping_tent (size,taken_time) VALUES ('" + int.Parse(textBoxtent.Text) + "', '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "') ";
                                        cmd = new MySqlCommand(insertTent, connection);
                                        cmd.ExecuteNonQuery();
                                        lastIdtent = cmd.LastInsertedId;
                                        string updateRes = "UPDATE camping_reservation SET tent_id = '" + lastIdtent + "' WHERE visitor_id = '" + add.Visitor_id + "'";
                                        cmd = new MySqlCommand(updateRes, connection);
                                        cmd.ExecuteNonQuery();
                                        string updateMoney = "UPDATE tickets_visitor SET event_money = event_money - '" + money + "' WHERE rfid_code = '" + visitorTag + "'";
                                        cmd = new MySqlCommand(updateMoney, connection);
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Date and Time: " + System.DateTime.Now + Environment.NewLine +
                                    "Visitor with id: " + add.Visitor_id + Environment.NewLine +
                                    "Tent size: " + textBoxtent.Text + Environment.NewLine +
                                    "Tent ID: " + lastIdtent + Environment.NewLine +
                                    "Tent price: " + money);
                                        textBoxtent.Text = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("You dont have enough money in your bank account!");

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("First make a reservation, then add a tent!");
                                }

                            }
                            else if (textBoxtent.Text == "4")
                            {
                                money = 30;
                                if (add != null)
                                {
                                    if (eventMoney >= money)
                                    {
                                        string insertTent = "INSERT INTO camping_tent (size,taken_time) VALUES ('" + int.Parse(textBoxtent.Text) + "', '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "') ";
                                        cmd = new MySqlCommand(insertTent, connection);
                                        cmd.ExecuteNonQuery();
                                        lastIdtent = cmd.LastInsertedId;
                                        string updateRes = "UPDATE camping_reservation SET tent_id = '" + lastIdtent + "' WHERE visitor_id = '" + add.Visitor_id + "'";
                                        cmd = new MySqlCommand(updateRes, connection);
                                        cmd.ExecuteNonQuery();
                                        string updateMoney = "UPDATE tickets_visitor SET event_money = event_money - '" + money + "' WHERE rfid_code = '" + visitorTag + "'";
                                        cmd = new MySqlCommand(updateMoney, connection);
                                        cmd.ExecuteNonQuery();

                                        MessageBox.Show("Date and Time: " + System.DateTime.Now + Environment.NewLine +
                                    "Visitor with id: " + add.Visitor_id + Environment.NewLine +
                                    "Tent size: " + textBoxtent.Text + Environment.NewLine +
                                    "Tent ID: " + lastIdtent + Environment.NewLine +
                                    "Tent price: " + money);
                                        textBoxtent.Text = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("You dont have enough money in your bank account!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("First make a reservation, then add a tent!");
                                }


                            }
                            else if (textBoxtent.Text == "6")
                            {
                                money = 45;
                                if (add != null)
                                {
                                    if (eventMoney >= money)
                                    {
                                        string insertTent = "INSERT INTO camping_tent (size,taken_time) VALUES ('" + int.Parse(textBoxtent.Text) + "', '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "') ";
                                        cmd = new MySqlCommand(insertTent, connection);
                                        cmd.ExecuteNonQuery();
                                        lastIdtent = cmd.LastInsertedId;
                                        string updateRes = "UPDATE camping_reservation SET tent_id = '" + lastIdtent + "' WHERE visitor_id = '" + add.Visitor_id + "'";
                                        cmd = new MySqlCommand(updateRes, connection);
                                        cmd.ExecuteNonQuery();
                                        string updateMoney = "UPDATE tickets_visitor SET event_money = event_money - '" + money + "' WHERE rfid_code = '" + visitorTag + "'";
                                        cmd = new MySqlCommand(updateMoney, connection);
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Date and Time: " + System.DateTime.Now + Environment.NewLine +
                                    "Visitor with id: " + add.Visitor_id + Environment.NewLine +
                                    "Tent size: " + textBoxtent.Text + Environment.NewLine +
                                    "Tent ID: " + lastIdtent + Environment.NewLine +
                                    "Tent price: " + money);
                                        textBoxtent.Text = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("You dont have enough money in your bank account!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("First make a reservation, then add a tent!");
                                }
                            }
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
                textBoxtent.Text = "";
                StatusTent.Text = "";
                rfidManager.tagFound -= AddTent;
                tabControl1.SelectedTab = tabPageCheckIn;
            }

        }
        private void buttonTent_Click(object sender, EventArgs e)
        {
            rfidManager.tagFound += AddTent;
            StatusTent.Text = "Please tag your RFID braclet";
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
                string query = "SELECT camping_reservation.spot_id, camping_reservation.visitor_id, camping_reservation.id " +
                               "FROM camping_reservation " +
                               "JOIN tickets_visitor ON (tickets_visitor.id = camping_reservation.visitor_id) " +
                               "WHERE tickets_visitor.rfid_code = '" + visitorTag + "' ";
                cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() != false)
                {
                    ev.AddOnlyTent(new GetResDetails() { Spot_id = (int)reader[0], Visitor_id = (int)reader[1], Res_id = (int)reader[2] });
                    return ev.GetDetails();
                }
                connection.Close();
                return null;
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

        private void buttonReserve_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Start scanning...";
            tabControl1.SelectedTab = tabPageReserve;
            ShowFreeSpots();
        }

        private void buttonADDTent_Click(object sender, EventArgs e)
        {
            Status.Text = "Start scannig...";
            tabControl1.SelectedTab = tabPageAddTent;
        }
        private string GetEventMoney(MySqlConnection connection)
        {
            connection.Open();
            string getEventMoney = "SELECT event_money " +
                "FROM tickets_visitor " +
                "WHERE rfid_code = '" + visitorTag + "'";
            cmd = new MySqlCommand(getEventMoney, connection);
            string res = cmd.ExecuteScalar().ToString();
            connection.Close();
            return res;
        }
        //private void buttonCheckOut_Click(object sender, EventArgs e)
        //{
        //    rfid.Tag += RFIDcheckOut;
        //}
    }
}
