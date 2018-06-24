using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaningApplicationProP
{
    class Visitor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double EventBalance { get; set; }
        public DateTime DoB{ get; set; }
        public string RFID{ get; set; }
        public List<Item> RentedItems{ get; set; }



        public Visitor(string name,string lastName, double balance, string rfid, int id)
        {
            this.EventBalance = balance;
            this.FirstName = name;
            this.RFID = rfid;
            this.RentedItems = new List<Item>();
            this.LastName = lastName;
            this.ID = id;
          //  this.RentedItems.Add(new Item(Sizes.Small,1,"test",))
        }

        /// <summary>
        /// Makes the user use money to buy an item from a shop
        ///</summary>
        
        public void BuyItem()
        {
           
        }

        /// <summary>
        /// Puts the user to loan an item
        /// </summary>
        /// <param name="loanShop"></param>
        public bool LoanItem(Shop shopName, Item itm)
        {
            if (this.EventBalance > itm.SellingPrice)
            {
                if (itm.Quantety > 0)
                {
                    this.EventBalance -= itm.SellingPrice;
                    itm.Quantety--;
                    this.RentedItems.Add(itm);
                    return true;
                }
              
            }
            return false;
        }

        public bool ReturnItem( Item itm)
        {
            foreach (Item i in this.RentedItems)
            {
                if (i.ItemID == itm.ItemID)
                {
                    RentedItems.Remove(itm);
                    itm.Quantety++;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Rents a space for this user
        /// </summary>
        public void RentSpace()
        {

        }

    }
}
