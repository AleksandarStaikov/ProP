using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

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