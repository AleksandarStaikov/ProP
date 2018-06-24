using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaningApplicationProP
{
    class Shop
    {
        public string Name { get; set; }

        public List<Item> Items { get; set; }

        public Shop(string name)
        {
            Name = name;
            Items = new List<Item>();
        }
        /// <summary>
        /// Gets the item with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Item GetItem(int id)
        {
            foreach (Item p in Items)
            {
                if (p.ItemID == id)
                {
                    return p;
                }
            }

            return null;
        }
        /// <summary>
        /// adds an item to the list of available items
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool AddItem(Item p)
        {
            if (GetItem(p.ItemID) == null)
            {
                Items.Add(p);
                return true;
            }
            return false;

        }

        public List<Item> GetItems()
        {
            return Items;
        }

        public List<Item> GetItem(string p)
        {
            List<Item> myItems = new List<Item>();
            foreach (Item per in Items)
            {
                if (per.Name.Contains(p))
                {
                    myItems.Add(per);
                }
            }
            return myItems;
        }
        /// <summary>
        /// Sells an item of this type(should send some information to the database)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sold"></param>
        public void SellItem(int id,int sold)
        {
            if (GetItem(id) != null)
            {
                GetItem(id).Quantety -= sold; 
                // Send some information to the database as to update the information
            }
        }
      
        
    }
}
