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
            labelInfo.Text = "Press CHECKIN!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rfid = new RFID();
            rfid.Open();
            rfid.Attach += RFIDstuffs;
            tabControl1.Location = (new Point(ClientSize.Width / 2 - tabControl1.Width / 2,
                                    ClientSize.Height / 2 - tabControl1.Height / 2));
            tabControl1.Anchor = AnchorStyles.None;
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
                        if (reader.Read() == true)
                        {
                            if (reader[6].ToString() != "")
                            {
                                ev.AddVisitor(new Visitor() { FisrtName = (string)reader[2], LastName = (string)reader[3], ID = (int)reader[1], Rfid = (string)reader[0] });
                                timer1.Enabled = true;
                                timer1.Start();
                                labelstats.Text = "Check In Successful! You can proceed!";
                            }
                            else
                            {
                                timer1.Enabled = true;
                                timer1.Start();
                                labelstats.Text = "Check In Unsuccessful! Please make a reservation!";
                            }
                        }
                        else
                        {
                            timer1.Enabled = true;
                            timer1.Start();
                            MessageBox.Show("Not existing rfid tag!");
                        }
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show("Failed to connect to the database!");
                }
            }
            rfidManager.tagFound -= RFIDcheckIn;
        }
        //



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

                        if (comboBoxCampNo.SelectedItem != null && comboBoxSpotNo.SelectedItem != null)
                        {
                            FreeSpots f = new FreeSpots();
                            f.CampId = int.Parse(comboBoxCampNo.SelectedItem.ToString());
                            f.SpotNo = int.Parse(comboBoxSpotNo.SelectedItem.ToString());
                            visitorTag = rfidTag;
                            double eventMoney = double.Parse(GetEventMoney(connection));
                            string visId = RetriveVisitorId(connection);
                            long lastIdtent = 0;
                            if (comboBoxTentSize.SelectedItem != null)
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

                                        if (int.Parse(comboBoxTentSize.SelectedItem.ToString()) == 2 || int.Parse(comboBoxTentSize.SelectedItem.ToString()) == 4 || int.Parse(comboBoxTentSize.SelectedItem.ToString()) == 6)
                                        {
                                            string insertTent = "INSERT INTO camping_tent (size,taken_time) VALUES ('" + int.Parse(comboBoxTentSize.SelectedItem.ToString()) + "', '" + System.DateTime.Now.ToString("yyyy-MM-dd  hh-mm-ss") + "') ";
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
                                        MessageBox.Show("Reservation successful!");
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
                                        MessageBox.Show("Reservation successful!");
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
                                
                            }
                        }
                        else
                        {
                            MessageBox.Show("Choose an number from the dropdown lists!");
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
                comboBoxTentSize.SelectedItem = null;
                comboBoxSpotNo.SelectedItem = null;
                comboBoxCampNo.SelectedItem = null;
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
            lbResStatus.Text = "Please tag your RFID bracelet";
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
                        connection.Close();
                        double eventMoney = double.Parse(GetEventMoney(connection));
                        if (cbAddTentOnly.SelectedItem != null)
                        {
                            if (cbAddTentOnly.SelectedItem.ToString() == "2" || cbAddTentOnly.SelectedItem.ToString() == "4" || cbAddTentOnly.SelectedItem.ToString() == "6")
                            {
                                connection.Open();
                                if (cbAddTentOnly.SelectedItem.ToString() == "2")
                                {
                                    money = 15;
                                    if (add != null)
                                    {
                                        if (eventMoney >= money)
                                        {

                                            string insertTent = "INSERT INTO camping_tent (size,taken_time) VALUES ('" + int.Parse(cbAddTentOnly.SelectedItem.ToString()) + "', '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "') ";
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
                                        "Tent size: " + cbAddTentOnly.SelectedItem.ToString() + Environment.NewLine +
                                        "Tent ID: " + lastIdtent + Environment.NewLine +
                                        "Tent price: " + money);
                                            cbAddTentOnly.SelectedItem = null;
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
                                else if (cbAddTentOnly.SelectedItem.ToString() == "4")
                                {
                                    money = 30;
                                    if (add != null)
                                    {
                                        if (eventMoney >= money)
                                        {
                                            string insertTent = "INSERT INTO camping_tent (size,taken_time) VALUES ('" + int.Parse(cbAddTentOnly.SelectedItem.ToString()) + "', '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "') ";
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
                                        "Tent size: " + cbAddTentOnly.SelectedItem.ToString() + Environment.NewLine +
                                        "Tent ID: " + lastIdtent + Environment.NewLine +
                                        "Tent price: " + money);
                                            cbAddTentOnly.SelectedItem = null;
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
                                else if (cbAddTentOnly.SelectedItem.ToString() == "6")
                                {
                                    money = 45;
                                    if (add != null)
                                    {
                                        if (eventMoney >= money)
                                        {
                                            string insertTent = "INSERT INTO camping_tent (size,taken_time) VALUES ('" + int.Parse(cbAddTentOnly.SelectedItem.ToString()) + "', '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "') ";
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
                                        "Tent size: " + cbAddTentOnly.SelectedItem.ToString() + Environment.NewLine +
                                        "Tent ID: " + lastIdtent + Environment.NewLine +
                                        "Tent price: " + money);
                                            cbAddTentOnly.SelectedItem = null;
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
                        else
                        {
                            MessageBox.Show("Choose an option in the dropdown menu!");
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
                StatusTent.Text = "";
                rfidManager.tagFound -= AddTent;
                tabControl1.SelectedTab = tabPageCheckIn;
            }

        }
        private void buttonTent_Click(object sender, EventArgs e)
        {
            rfidManager.tagFound += AddTent;
            StatusTent.Text = "Please tag your RFID bracelet";
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
            string free_spots = "";
            try
            {
                connection.Open();
                string query = "SELECT free_beds " +
                    "FROM camping_camping " +
                    "WHERE camping_number = '" + comboBoxCampNo.SelectedItem.ToString() + "'";
                cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                free_spots = reader[0].ToString();
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
            lbStatus.Text = "";
            tabControl1.SelectedTab = tabPageReserve;
            ShowFreeSpots();
        }

        private void buttonADDTent_Click(object sender, EventArgs e)
        {
            Status.Text = "";
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                labelstats.Text = "";
                labelInfo.Text = "Press CHECKIN!";
            }
        }
        //private void buttonCheckOut_Click(object sender, EventArgs e)
        //{
        //    rfid.Tag += RFIDcheckOut;
        //}
    }
}
