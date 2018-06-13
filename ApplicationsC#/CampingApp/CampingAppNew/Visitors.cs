using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CampingAppNew
{
    class Visitors
    {
        public int ReservationID { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public string Rfid { get; set; }

        public Visitors(string fname, string lname, string rfid, int id, int resId)
        {
            FisrtName = fname;
            LastName = lname;
            Rfid = rfid;
            ID = id;
            ReservationID = resId;
        }
        public Visitors() { }
    }
}
