using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ATMLogApplication
{
    using Models;

    public class SQLManager
    {
        public SQLManager(MySqlConnection sqlConnection)
        {
            this.Connection = sqlConnection;
        }

        public MySqlConnection Connection { get; set; }

        public long AddTransactionLog(Log log)
        {
            var query = $"INSERT INTO `others_atmlog`(`bank_account`, `start_of_period`, `end_of_period`, `deposit_amount`) " +
                        $"VALUES ('{log.BankAccountNumber}','{log.StartDate.ToString("yyyy-MM-dd HH-mm-ss")}','{log.EndDate.ToString("yyyy-MM-dd HH-mm-ss")}','{log.Deposits}')";
            var command = new MySqlCommand(query, Connection);
            command.ExecuteNonQuery();
            return command.LastInsertedId;
        }

        public void AddTransaction(Transaction transaction, long LogId)
        {
            var query = $"INSERT INTO `others_deposit`(`amount`, `atm_log_id`, `visitor_id`) " +
                        $"VALUES ('{transaction.Money}', '{LogId}', '{transaction.VisitorId}')";
            var command = new MySqlCommand(query, Connection);
            command.ExecuteNonQuery();

            var updateQuery = $"UPDATE `tickets_visitor` " +
                              $"SET `event_money` = `event_money` + {transaction.Money} " +
                              $"WHERE `id` = '{transaction.VisitorId}'";
            var updateCommand = new MySqlCommand(updateQuery, Connection);
            updateCommand.ExecuteNonQuery();
        }
    }
}
