using LoaningApplicationProP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaningApplicationProP
{
    class Stand
    {
        public List<Item> Items { get; set; }

        public List<Item> UserItems { get; set; }

        public List<Item> WantedItems { get; set; }

        public List<Tent> UserTents { get; set; }

        public Stand()
        {
            Items = new List<Item>();
            UserItems = new List<Item>();
            WantedItems = new List<Item>();
            UserTents = new List<Tent>();
        }

        public Item GetItem(int id)
        {
            return Items.FirstOrDefault(x => x.ItemID == id);
        }

        public List<Item> GetAvaliableItems()
        {
            return Items.Where(x => x.Available == "A").ToList();
        }
    }
}
