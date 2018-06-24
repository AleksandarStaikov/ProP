using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLogApplication.Models
{
    public class Log
    {
        public Log()
        {
            this.Transactions = new List<Transaction>();
        }

        public List<Transaction> Transactions { get; set; }

        public string BankAccountNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Deposits
        {
            get
            {
                return this.Transactions.Count;
            }
        }
    }
}
