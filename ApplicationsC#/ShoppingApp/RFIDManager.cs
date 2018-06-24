using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phidget22;
using Phidget22.Events;

namespace ShoppingApp
{
    public class RFIDManager
    {
        public RFID rfid;
        public Action<string> tagFound;

        public RFIDManager()
        {
            rfid = new RFID();
            rfid.Attach += this.Attach;
            rfid.Tag += this.Taged;
            rfid.Open();
        }

        public void Taged(object sender, RFIDTagEventArgs e)
        {
            tagFound?.Invoke(e.Tag);
        }

        public void Attach(object sender, AttachEventArgs args)
        {
            try
            {
                this.rfid.AntennaEnabled = true;
            }
            catch (Exception)
            {

            }
        }
    }
}
