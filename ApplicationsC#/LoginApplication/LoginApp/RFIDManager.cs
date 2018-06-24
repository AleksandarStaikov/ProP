namespace LoginApp
{
    using System;
    using Phidget22;
    using Phidget22.Events;

    public class RFIDManager
    {
        public RFID rfid;
        public Action<string> tagFound;

        public RFIDManager()
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

            }
        }
    }
}
