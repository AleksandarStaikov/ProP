using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusApp.Models
{
    public class ShopSalesByDay
    {
        public ShopSalesByDay(DateTime date, double money)
        {
            this.Date = date;
            this.Money = money;
        }

        public DateTime Date { get; set; }

        public double Money { get; set; }
    }
}
