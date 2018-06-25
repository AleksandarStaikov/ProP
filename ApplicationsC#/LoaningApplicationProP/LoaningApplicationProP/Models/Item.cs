using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LoaningApplicationProP.Models
{
    enum Sizes { Small, Medium, Big };

    [Serializable]
    public class Item
    {
        public Item(long id, string name, double price, string available, Image img)
        {
            this.SellingPrice = price;
            this.Name = name;
            this.Quantity = 1;
            this.ItemID = id;
            this.ItemImage = img;
            this.Available = available;
        }

        public double SellingPrice { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public long ItemID { get; set; }

        public Image ItemImage { get; set; }

        public string Available { get; set; }


        public override string ToString()
        {
            return $"{Name}, {ItemID}";
        }
    }
}
