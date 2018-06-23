using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingApp
{
    public class FreeSpots
    {
        private int campID;
        private int spotNo;
        public int CampId
        {
            get
            {
                return campID;
            }
            set
            {
                if (value > 0 && value <= 48)
                {
                    campID = value;
                }
                else
                {
                    throw new MyException("You must choose camping number between 0 and 48");
                }
            }
        }
        public int SpotNo
        {
            get
            {
                return spotNo;
            }
            set
            {
                if (value >= 0 && value <= 6)
                {
                    spotNo = value;
                }
                else
                {
                    throw new MyException("You must choose sppot number between 0 and 6");
                }
            }
        }
        public FreeSpots() { }
        public string AsString()
        {
            return "Camping#: " + CampId + " FreeSpots: " + SpotNo;
        }
    }
}
