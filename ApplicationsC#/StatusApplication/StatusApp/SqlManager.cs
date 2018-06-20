using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using StatusApp.Models;

namespace StatusApp
{
    public class SqlManager
    {
        public MySqlConnection connection { get; set; }

        public string TicketsPurchased()
        {
            var query = "SELECT COUNT(*) " +
                        "FROM tickets_visitor";
            MySqlCommand command = new MySqlCommand(query, connection);
            return this.NormalizeRezult(command.ExecuteScalar());
        }

        public string CurrentAttendees()
        {
            var query = "SELECT COUNT(*) " +
                        "FROM tickets_visitor WHERE " +
                        "tickets_visitor.rfid_code IS NOT NULL";
            MySqlCommand command = new MySqlCommand(query, connection);
            return this.NormalizeRezult(command.ExecuteScalar());
        }

        public string MostPurchasedItem()
        {
            var query = "SELECT i.name " +
                        "FROM others_item i " +
                        "WHERE i.id = (select oh.item_id " +
                                      "FROM others_order o " +
                                      "INNER JOIN others_hold oh " +
                                          "ON(o.hold_id = oh.id) " +
                                      "GROUP BY oh.item_id " +
                                      "ORDER BY SUM(o.quantity) " +
                                      "LIMIT 1)";
            MySqlCommand command = new MySqlCommand(query, connection);
            return this.NormalizeRezult(command.ExecuteScalar());
        }

        public string MostLoanedMaterial()
        {
            var query = "SELECT i.name " +
                        "FROM others_loan l " +
                        "INNER JOIN others_loanitem i " +
                            "ON l.item_id = i.id " +
                        "GROUP BY i.id, i.name " +
                        "ORDER BY COUNT(l.id) DESC " +
                        "LIMIT 1";
            MySqlCommand command = new MySqlCommand(query, connection);
            return this.NormalizeRezult(command.ExecuteScalar());
        }

        public string MostPrefferedShop()
        {
            var query = "SELECT s.name " +
                        "FROM others_shop s " +
                        "WHERE s.id =(select oh.shop_id " +
                                      "FROM others_order o " +
                                      "INNER JOIN others_hold oh " +
                                          "ON(o.hold_id = oh.id) " +
                                      "GROUP BY oh.shop_id " +
                                      "ORDER BY SUM(o.quantity) " +
                                      "LIMIT 1)";

            MySqlCommand command = new MySqlCommand(query, connection);
            return this.NormalizeRezult(command.ExecuteScalar());
        }

        public string MoneySpendOnShops()
        {
            var query = "SELECT SUM(o.quantity * i.price) " +
                        "FROM others_order o " +
                        "INNER JOIN others_hold h " +
                            "ON o.hold_id = h.id " +
                        "INNER JOIN others_item i " +
                            "ON h.item_id = i.id";

            MySqlCommand command = new MySqlCommand(query, connection);
            return this.NormalizeRezult(command.ExecuteScalar());
        }

        public string MoneySpentForLoaning()
        {
            var query = "SELECT SUM(i.price) " +
                        "FROM others_loan l " +
                        "INNER JOIN others_loanitem i " +
                            "ON l.item_id = i.id";
            MySqlCommand command = new MySqlCommand(query, connection);
            return this.NormalizeRezult(command.ExecuteScalar());
        }

        public List<AtendeesForADay> AtendeesByDays()
        {
            var dates = new List<AtendeesForADay>();
            var query = $"SELECT CAST(entry_date AS DATE) as entry_date, COUNT(id) as atendees " +
                        $"FROM `tickets_entryticket` " +
                        $"WHERE entry_date IS NOT NULL " +
                        $"GROUP BY CAST(entry_date AS DATE) " +
                        $"ORDER BY CAST(entry_date AS DATE) " +
                        $"LIMIT 3";
            MySqlCommand command = new MySqlCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    dates.Add(new AtendeesForADay(DateTime.Parse(reader["entry_date"].ToString()), int.Parse(reader["atendees"].ToString())));
                }
            }
            return dates;
        }

        public List<ShopSalesByDay> MoneyAtShopsByDay()
        {
            var dates = new List<ShopSalesByDay>();
            var query = $"SELECT CAST(p.time AS DATE) AS date,  SUM(o.quantity * i.price) AS money " +
                        $"FROM others_order o " +
                        $"INNER JOIN others_hold h " +
                            $"ON o.hold_id = h.id " +
                        $"INNER JOIN others_item i " +
                            $" ON h.item_id = i.id " +
                        $"INNER JOIN others_purchase p " +
                            $"ON p.order_id = o.id " +
                        $"GROUP BY CAST(p.time AS DATE)";
            MySqlCommand command = new MySqlCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    dates.Add(new ShopSalesByDay(DateTime.Parse(reader["date"].ToString()), double.Parse(reader["money"].ToString())));
                }
            }
            return dates;   
        }

        public void NotReturnedItems()
        {
            var query = $"";
        }

        private string NormalizeRezult(object input)
        {
            if (input == null)
            {
                return "No data yet";
            }
            else if (input == DBNull.Value)
            {
                return "0";
            }
            else
            {
                return input.ToString();
            }
        }
    }
}