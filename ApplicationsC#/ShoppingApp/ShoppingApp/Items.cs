using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShoppingApp
{
    public class Item
    {

       
        public double SellingPrice { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int HoldId { get; set; }
        public Image ItemImage { get; set; }
        public string Type { get; set; }


        public Item(double Value, string name, int quantity, int id, Image img, string type)
        {
          
            this.SellingPrice = Value;
            this.Name = name;
            this.Quantity = quantity;
            this.HoldId = id;
            this.ItemImage = img;
            this.Type = type;
        }

        public void TakeSomeItems(int quant)
        {
            this.Quantity -= quant;
        }

        public override string ToString()
        {
            return $"{Name}-{Quantity}";
        }
    }
}
