using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntranceAppGui
{
    class CommentedMethods
    {
        //public void BringItems()
        //{
        //    int currID = 0;
        //    string SQL = "SELECT `id`, `name`, `price`, `Image`, `Type` FROM `others_item` WHERE 1;";
        //    string SQL1 = "SELECT `quantity_in_stock`,`item_id` FROM `others_hold` WHERE 1;";
        //    /*`status` = 'A'*/
        //    try
        //    {
        //        MySqlDataReader reader;
        //        MySqlDataReader reader2;
        //        MySqlDataReader[] reader3 = new MySqlDataReader[100];
        //        object[] v = new object[100];
        //        int[] quantity = new int[100];
        //        OpenConnection();

        //        MySqlCommand command = new MySqlCommand(SQL, connection);

        //        if (command != null)
        //        {



        //            reader2 = command.ExecuteReader();
        //            reader2.Read();

        //            int nrItm = nrItems(reader2["name"].ToString(), reader2);
        //            //find a way to put for every item
        //            //found a way to work around it...

        //            int i = 0;

        //            reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                int j = 0;

        //                if (!reader.HasRows)
        //                    throw new Exception("There are no BLOBs to save");

        //                reader3[i] = reader;
        //                //foreach (object o in reader)
        //                //{
        //                //    v[i, j] = o.ToString();
        //                //    j++;
        //                //}
        //                i++;



        //                myItems.Add(
        //                    new Item(
        //                    Convert.ToDouble(reader["price"]),
        //                    reader["name"].ToString(),
        //                    nrItm,/*have to put a sql statement that gives me the number of these objects*/
        //    Convert.ToInt32(reader["id"]),
        //                    byteArrayToImage(reader["Image"] as byte[]),
        //                    reader["Type"].ToString()
        //                             )
        //                            );

        //            }

        //            reader.Close();

        //            //reader3 = command.;

        //            // reader3.CopyTo(v,100);
        //            //List<string> list = (from IDataRecord r in reader3
        //            //                     select (string)r["FieldName"]
        //            //).ToList();
        //            command.CommandText = SQL1;
        //            reader2 = command.ExecuteReader();

        //            while (reader2.Read())
        //            {

        //                if (!reader2.HasRows)
        //                    throw new Exception("There are no BLOBs to save");

        //                for (int j = 0; j <= myItems.Count() - 1; ++j)
        //                    if (Convert.ToInt32(myItems[j].HoldId) == Convert.ToInt32(reader2["item_id"]))
        //                    {
        //                        myItems[j].Quantety = Convert.ToInt32(reader2["quantity_in_stock"]);
        //                        //  quantity[Convert.ToInt32(v[i, 0])] = Convert.ToInt32(reader2["quantity_in_stock"]);
        //                    }


        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
        //            "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        //    }
        //}

        //public void bringUsers()
        //{
        //    string SQL = "SELECT `id`, `first_name`, `last_name`, `email`, `rfid_code`, `birth_date`, `event_money`, `id` FROM `tickets_visitor` WHERE 1";
        //    /////
        //    try
        //    {
        //        MySqlDataReader reader;
        //        MySqlCommand command = new MySqlCommand(SQL, connection);

        //        if (command != null)
        //        {
        //            reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    users.Add(new Visitor(reader["first_name"].ToString(),
        //                              (reader["last_name"]).ToString(),
        //                              Convert.ToDouble(reader["event_money"]),
        //                              (reader["rfid_code"]).ToString(),
        //                              Convert.ToInt32(reader["id"])));
        //                }
        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
        //            "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        //    }
        //}

        //private void ShowInfot(object sender, RFIDTagEventArgs e)
        //{
        //    // lbRentItems.Text = 0.ToString();
        //    int ok = 0;
        //    //just for test will make a list of all users 
        //    foreach (Visitor u1 in users)
        //    {
        //        if (u1.RFID == e.Tag)
        //        {
        //            MessageBox.Show($"The user{e.Tag} has connected");
        //            lbBalance.Text = 0.ToString();
        //            lbBalance2.Text = 0.ToString();
        //            labelBalance3.Text = 0.ToString();
        //            lbName.Text = u1.FirstName + " " + u1.LastName;
        //            lbName2.Text = u1.FirstName + " " + u1.LastName;
        //            labelName3.Text = u1.FirstName + " " + u1.LastName;
        //            currentVisitor = u1;

        //        }
        //        else
        //        {
        //            ok++;
        //        }
        //    }
        //    if (ok == users.Count)
        //    {
        //        MessageBox.Show("NO ONE uses this RFID " + e.Tag);
        //    }


        //}
    }
}
