using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusApp.Models
{
    public class AtendeesForADay
    {
        public AtendeesForADay(DateTime date, int atendees)
        {
            this.Date = date;
            this.Atendees = atendees;
        }

        public DateTime Date { get; set; }

        public int Atendees { get; set; }
    }
}
