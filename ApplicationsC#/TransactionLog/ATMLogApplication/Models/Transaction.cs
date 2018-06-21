using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLogApplication.Models
{
    public class Transaction
    {
        public Transaction(int visitorId, double money)
        {
            this.VisitorId = visitorId;
            this.Increasment = money;
        }

        public int VisitorId { get; set; }

        public double Increasment { get; set; }

        public double InitialBalance { get; set; }

        public override string ToString()
        {
            return $"Visitor {VisitorId}, had {InitialBalance}, now has {InitialBalance + Increasment}";
        }

        public string TransactionFailedString()
        {
            return $"Transaction for id {VisitorId} FAILED";
        }
    }
}
