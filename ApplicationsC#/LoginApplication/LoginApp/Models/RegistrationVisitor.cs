using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class RegistrationVisitor
    {
        private string firstname;
        private string lastname;
        private string email;


        public string FirstName
        {
            get { return this.firstname; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.firstname = value;
                }
                else
                {
                    throw new ArgumentException("First name can not be empty!!!");
                }
            }
        }

        public string LastName
        {
            get { return this.lastname; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.lastname = value;
                }
                else
                {
                    throw new ArgumentException("Last name can not be empty!!!");
                }
            }
        }

        public string Email
        {
            get { return this.firstname; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("Email can not be empty!!!");
                }
            }
        }

        public DateTime BirthDate { get; set; }

        public string RFID { get; set; }


        public void ResetData()
        {
            this.firstname = null;
            this.lastname = null;
            this.email = null;
            this.BirthDate = new DateTime();
            this.RFID = null;
        }
    }
}
