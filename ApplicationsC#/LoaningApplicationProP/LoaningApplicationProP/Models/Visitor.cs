using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaningApplicationProP.Models
{
    public class Visitor
    {

        public Visitor(long id, string fName, string lName, double Balance, string rfid)
        {
            this.ID = id;
            this.FirstName = fName;
            this.LastName = lName;
            this.Balance = Balance;
            this.RFID = rfid;
        }

        public long ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Balance { get; set; }

        public string RFID { get; set; }
    }
}
