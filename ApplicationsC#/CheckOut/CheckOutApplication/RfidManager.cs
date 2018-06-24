﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phidget22;
using Phidget22.Events;

namespace CheckOutApplication
{
    public class RfidManager
    {
        private RFID rfid;
        public Action<string> tagFound;

        public RfidManager()
        {
            this.rfid = new RFID();

            rfid.Attach += Attach;
            rfid.Tag += Tag;

            rfid.Open();
        }

        public void Tag(object sender, RFIDTagEventArgs e)
        {
            tagFound?.Invoke(e.Tag);
        }

        private void Attach(object sender, AttachEventArgs e)
        {
            try
            {
                rfid.AntennaEnabled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}