using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phidget22;
using Phidget22.Events;

namespace CampingApp
{
    public class RfidManager
    {
        public RFID rfid;
        public Action<string> tagFound;

        public RfidManager()
        {
            rfid = new RFID();

            rfid.Attach += Attach;
            rfid.Tag += Tag;
            rfid.Open();
        }


        public void Tag(object sender, RFIDTagEventArgs e)
        {
            if (tagFound != null)
            {
                tagFound(e.Tag);
            }
        }

        public void Attach(object sender, AttachEventArgs e)
        {
            try
            {
                rfid.AntennaEnabled = true;
            }
            catch (PhidgetException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
