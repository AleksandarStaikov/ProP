namespace StatusApp.Models
{
    using System;

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
