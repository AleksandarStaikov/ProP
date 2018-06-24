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
    public class SqlMannager
    {
        public SqlMannager(MySqlConnection newConnection)
        {
            this.connection = newConnection;
        }

        private MySqlConnection connection { get; set; }

        
        public List<Item> LoadShopItems(int shopId)
        {
            var query = $"SELECT * " +
                      $"FROM others_hold h " +
                      $"INNER JOIN others_item i " +
                          $"ON h.item_id = i.id " +
                      $"WHERE h.shop_id = {shopId}";
            MySqlCommand command = new MySqlCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                var items = new List<Item>();
                while (reader.Read())
                {
                    int holdId = int.Parse(reader["id"].ToString());
                    int qtyInStock = int.Parse(reader["quantity_in_stock"].ToString());
                    string name = reader["name"].ToString();
                    double price = double.Parse(reader["price"].ToString());
                    string type = reader["Type"].ToString();
                    Image pic = this.byteArrayToImage(reader["Image"] as byte[]);

                    var item = new Item(price, name, qtyInStock, holdId, pic, type);
                    items.Add(item);
                }
                return items;
            }
        }

        public long GetUserIDByRfid(string tag)
        {
            var query = $"SELECT v.id " +
                        $"from tickets_visitor v " +
                        $"WHERE v.rfid_code = '{tag}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            var result = new Object();

            if((result = command.ExecuteScalar()) != null)
            {
                return long.Parse(result.ToString());
            }

            return -1;
        }

        public long AddAPurchase(long visitorID)
        {
            var query = $"INSERT INTO `others_purchase`(`time`, `visitor_id`) " +
                        $"VALUES('{DateTime.Now.ToString("yyyy-MM-dd")}', {visitorID})";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            return command.LastInsertedId;
        }

        public void AddOrder(Item item, long purchase_id)
        {
            var query = $"UPDATE others_hold h " +
                        $"set h.quantity_in_stock = h.quantity_in_stock - {item.Quantity} " +
                        $"WHERE h.id = {item.HoldId}";
            MySqlCommand updateCommand = new MySqlCommand(query, connection);
            updateCommand.ExecuteNonQuery();

            var insertQuery = $"INSERT INTO `others_order`(`quantity`, `hold_id`, `purchase_id`) " +
                    $"VALUES('{item.Quantity}', '{item.HoldId}', '{purchase_id}')";
            MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
            insertCommand.ExecuteNonQuery();
        }

        public void DecreaseVisitorMoney(long visitorId, double price)
        {
            var query = $"UPDATE tickets_visitor " +
                        $"set event_money = event_money - {price} " +
                        $"WHERE id = {visitorId}";
            MySqlCommand updateCommand = new MySqlCommand(query, connection);
            updateCommand.ExecuteNonQuery();
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
