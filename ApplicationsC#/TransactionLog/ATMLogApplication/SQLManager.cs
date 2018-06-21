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
            try
            {
                var query = $"INSERT INTO `others_deposit`(`amount`, `atm_log_id`, `visitor_id`) " +
                        $"VALUES ('{transaction.Increasment}', '{LogId}', '{transaction.VisitorId}')";
                var command = new MySqlCommand(query, Connection);
                command.ExecuteNonQuery();

                var selectQuery = $"SELECT `event_money` " +
                                  $"FROM `tickets_visitor` " +
                                  $"WHERE `id` = '{transaction.VisitorId}'";
                var selectCommand = new MySqlCommand(selectQuery, Connection);
                transaction.InitialBalance = double.Parse(selectCommand.ExecuteScalar().ToString());

                var updateQuery = $"UPDATE `tickets_visitor` " +
                              $"SET `event_money` = `event_money` + {transaction.Increasment} " +
                              $"WHERE `id` = '{transaction.VisitorId}'";
                var updateCommand = new MySqlCommand(updateQuery, Connection);
                updateCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("a foreign key constraint fails"))
                {
                    throw new Exception($"A visitor with Id {transaction.VisitorId} was not found");
                }
                throw new Exception(ex.Message);
            }
        }
    }
}
