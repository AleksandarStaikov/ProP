using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LoaningApplicationProP.Models;

namespace LoaningApplicationProP
{
    public class SqlManager
    {
        public SqlManager(MySqlConnection connection)
        {
            this.connection = connection;
        }

        private MySqlConnection connection { get; set; }


        public List<Models.Item> GetItems()
        {
            var items = new List<Models.Item>();
            var query = $"SELECT `id`, `name`, `price`, `status`, `Image` " +
                        $"FROM `others_loanitem` " +
                        $"WHERE status = 'A'";
            var command = new MySqlCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = items.FirstOrDefault(x => x.Name == reader["name"].ToString());
                    if (item == null)
                    {
                        items.Add(new Item(long.Parse(reader["id"].ToString()),
                                           reader["name"].ToString(),
                                           double.Parse(reader["price"].ToString()),
                                           reader["status"].ToString(),
                                           byteArrayToImage(reader["Image"] as byte[])));
                    }
                    else
                    {
                        item.Quantity++;
                    }
                }
            }
            return items;
        }

        public long GetVisitorIdByRfid(string tag)
        {
            var query = $"SELECT id " +
                        $"FROM `tickets_visitor` " +
                        $"WHERE rfid_code = '{tag}'";
            var command = new MySqlCommand(query, connection);
            return long.Parse(command.ExecuteScalar().ToString());
        }

        public Visitor GetVisitorByRfid(string tag)
        {
            var query = $"SELECT `id`, `first_name`, `last_name`, `event_money` " +
                        $"FROM `tickets_visitor` " +
                        $"WHERE rfid_code = '{tag}'";
            var command = new MySqlCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Visitor(long.Parse(reader["id"].ToString()),
                                       reader["first_name"].ToString(),
                                       reader["last_name"].ToString(),
                                       double.Parse(reader["event_money"].ToString()),
                                       tag);
                }
            }
            return null;
        }

        public List<Item> GetVisitorLoanedMaterials(long id)
        {
            var items = new List<Item>();
            var query = $"SELECT i.name, i.id , i.price, i.status, i.Image " +
                        $"FROM others_loan l " +
                        $"INNER JOIN others_loanitem i " +
                            $"ON l.item_id = i.id " +
                        $"WHERE l.end_date IS NULL " +
                        $"AND l.visitor_id = '{id}'";
            var command = new MySqlCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    items.Add(new Item(long.Parse(reader["id"].ToString()),
                                              reader["name"].ToString(),
                                              double.Parse(reader["price"].ToString()),
                                              reader["status"].ToString(),
                                              byteArrayToImage(reader["Image"] as byte[]
                                              )));
                }
            }
            return items;
        }

        public void LoanAnItem(Item item, long visitorId)
        {
            var insertQuery = $"INSERT INTO `others_loan`(`start_date` , `item_id`, `visitor_id`) " +
                              $"VALUES ('{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}', '{item.ItemID}', '{visitorId}')";
            var insertCommand = new MySqlCommand(insertQuery, connection);
            insertCommand.ExecuteNonQuery();

            var updateQuery = $"UPDATE `others_loanitem` " +
                              $"SET status = 'T' " +
                              $"WHERE id = '{item.ItemID}'";
            var updateCommand = new MySqlCommand(updateQuery, connection);
            updateCommand.ExecuteNonQuery();

            var userUpdateQuery = $"UPDATE `tickets_visitor` " +
                                  $"SET event_money = event_money - {item.SellingPrice} " +
                                  $"WHERE id = '{visitorId}'";
            var userUpdateCommand = new MySqlCommand(userUpdateQuery, connection);
            userUpdateCommand.ExecuteNonQuery();
        }

        public void ReturnItem(Item item, long visitorId)
        {
            var insertQuery = $"UPDATE `others_loan` " +
                              $"SET end_date = '{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}' " +
                              $"WHERE item_id = '{item.ItemID}' " +
                              $"AND end_date IS NULL";
            var insertCommand = new MySqlCommand(insertQuery, connection);
            insertCommand.ExecuteNonQuery();

            var updateQuery = $"UPDATE `others_loanitem` " +
                              $"SET status = 'A' " +
                              $"WHERE id = '{item.ItemID}'";
            var updateCommand = new MySqlCommand(updateQuery, connection);
            updateCommand.ExecuteNonQuery();

            var userUpdateQuery = $"UPDATE `tickets_visitor` " +
                                  $"SET event_money = event_money + {double.Parse($"{(item.SellingPrice * 70 / 100):F2}")} " +
                                  $"WHERE id = '{visitorId}'";
            var userUpdateCommand = new MySqlCommand(userUpdateQuery, connection);
            userUpdateCommand.ExecuteNonQuery();
        }

        public List<Tent> GetVisitorTent(long id)
        {
            var tents = new List<Tent>();
            var query = $"SELECT t.id, t.size " +
                        $"FROM tickets_visitor v " +
                        $"INNER JOIN camping_reservation r " +
                            $"ON v.id = r.visitor_id " +
                        $"INNER JOIN camping_tent t " +
                            $"ON r.tent_id = t.id " +
                        $"WHERE t.returned_time IS NULL " +
                        $"AND v.id = {id}";
            var command = new MySqlCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tents.Add(new Tent(short.Parse(reader["size"].ToString()), int.Parse(reader["id"].ToString())));
                }
            }

            return tents;
        }

        public void ReturnTent(Tent tent, long visitorId)
        {
            var tentUpdateQuery = $"UPDATE `camping_tent` " +
                                  $"SET returned_time = '{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}'" +
                                  $"WHERE id = {tent.Id}";
            var tentUpdateCommand = new MySqlCommand(tentUpdateQuery, connection);
            tentUpdateCommand.ExecuteNonQuery();

            var userUpdateQuery = $"UPDATE `tickets_visitor` " +
                                  $"SET event_money = event_money + {tent.size * 5.25} " +
                                  $"WHERE id = '{visitorId}'";
            var userUpdateCommand = new MySqlCommand(userUpdateQuery, connection);
            userUpdateCommand.ExecuteNonQuery();
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            ms.Position = 0;
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
