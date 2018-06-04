using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Models;

namespace LoginApp
{
    public class SqlCommands
    {
        public static string getUserIdByQrQuery(string qr_code)
        {
            return $"SELECT visitor_id " +
            $"FROM tickets_entryticket " +
            $"WHERE qr_code = '{qr_code}' " +
            $"AND entry_date IS NULL";
        }

        public static string UpdateUserRFIDById(string VisitorID, string rfid_code)
        {
            return $"UPDATE tickets_visitor " +
                   $"SET rfid_code = '{rfid_code}' " +
                   $"WHERE id = '{VisitorID}'";
        }

        public static string UpdateTicketEntryDate(string VisitorID)
        {
            return $"UPDATE tickets_entryticket " +
                   $"SET entry_date = '{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}' " +
                   $"WHERE visitor_id = '{VisitorID}'";
        }

        public static string RegisterNewVisitor(RegistrationVisitor visitor)
        {
            return $"INSERT INTO tickets_visitor (first_name, last_name, email, rfid_code, birth_date, event_money) " +
                   $"values('{visitor.FirstName}', '{visitor.LastName}', '{visitor.Email}', '{visitor.RFID}', '{visitor.BirthDate.ToString("yyyy-MM-dd")}', 0)";
        }
    }
}
