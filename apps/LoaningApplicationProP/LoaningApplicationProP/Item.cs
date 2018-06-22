using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LoaningApplicationProP
{
    enum Sizes{Small,Medium,Big};
    class Item
    {
       
        public Sizes ItemSize { get; set; }
        public double SellingPrice { get; set; }
        public string Name { get; set; }
        public int Quantety{ get; set; }
        public int ItemID { get; set; }
        public Image ItemImage { get; set; }
        public string Available { get; set; }


        public Item(Sizes itemSize, double Value, string name, int quantity, int id, Image img,string available)
        {
            this.ItemSize = itemSize;
            this.SellingPrice = Value;
            this.Name = name;
            this.Quantety = quantity;
            this.ItemID = id;
            this.ItemImage = img;
            this.Available = available;
        }

        public override string ToString()
        {
            return $"{Name}, {ItemID}";
        }
    }
}
