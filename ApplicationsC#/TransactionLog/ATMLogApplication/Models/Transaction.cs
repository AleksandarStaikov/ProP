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
            this.Money = money;
        }

        public int VisitorId { get; set; }

        public double Money { get; set; }
    }
}
