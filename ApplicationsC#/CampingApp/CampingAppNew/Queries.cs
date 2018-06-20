using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace CampingAppNew
{
    class Queries
    {
        string connectionString = "server=studmysql01.fhict.local;database=dbi380752;username=dbi380752;password=123456";
        List<Visitors> visitors = new List<Visitors>();
        MySqlCommand cmd;

        public void AddVisitors()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string displayQuery = "SELECT tickets_visitor.rfid_code, tickets_visitor.id," +
                                      " tickets_visitor.first_name, tickets_visitor.last_name," +
                                      " camping_reservation.id " +
                                      " FROM tickets_visitor  " +
                                      " LEFT OUTER JOIN camping_reservation   ON (camping_reservation.visitor_id = tickets_visitor.id) " +
                                      " LEFT OUTER JOIN camping_spot   ON (camping_reservation.spot_id = camping_spot.id) " +
                                      " LEFT OUTER JOIN camping_tent  ON (camping_reservation.tent_id = camping_tent.id) ";

                cmd = new MySqlCommand(displayQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    visitors.Add(new Visitors(reader[2].ToString(), reader[3].ToString(),
                        reader[0].ToString(), (int)reader[1], (int)reader[4]));
                }
            }
        }

    }
}
