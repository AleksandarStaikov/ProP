using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CheckOutApplication
{
    public class SqlManager
    {
        public SqlManager(MySqlConnection connection)
        {
            this.connection = connection;
        }

        private MySqlConnection connection { get; set; }

        public List<string> GetVisitorsItems(string rfidTag)
        {
            var items = new List<string>();
            var query = $"SELECT i.name " +
                        $"FROM others_loan l " +
                        $"INNER JOIN tickets_visitor v " +
                            $"ON l.visitor_id = v.id " +
                        $"INNER JOIN others_loanitem i " +
                            $"ON l.item_id = i.id " +
                        $"WHERE v.rfid_code = '{rfidTag}' " +
                        $"AND l.end_date IS NULL";
            var command = new MySqlCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    items.Add(reader["name"].ToString());
                }
            }

            return items.Count == 0 ? null : items;
        }

        public void CheckOutVisitor(string rfidTag)
        {
            var query = $"UPDATE tickets_visitor " +
                        $"SET checked_in = {false} " +
                        $"WHERE rfid_code = '{rfidTag}'";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}
