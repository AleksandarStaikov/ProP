using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaningApplicationProP.Models
{
    public class Tent
    {
        public Tent(short size, int id)
        {
            this.Id = id;
            this.size = size;
        }

        public short size { get; set; }

        public int  Id { get; set; }
    }
}
