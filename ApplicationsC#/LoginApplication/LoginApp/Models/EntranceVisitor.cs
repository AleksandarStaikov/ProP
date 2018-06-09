using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp
{
    class EntranceVisitor
    {
        public EntranceVisitor()
        {
            this.CurrentId = string.Empty;
            this.CurrentRFID = string.Empty;
        }

        public void ResetFields()
        {
            this.CurrentId = string.Empty;
            this.CurrentRFID = string.Empty;
        }

        public string CurrentId { get; set; }
        public string CurrentRFID { get; set; }
    }
}
