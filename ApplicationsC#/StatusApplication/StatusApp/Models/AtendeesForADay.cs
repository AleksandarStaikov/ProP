namespace StatusApp.Models
{
    using System;

    public class AtendeesForADay
    {
        public AtendeesForADay(DateTime date, int atendees)
        {
            this.Date = date;
            this.Atendees = atendees;
        }

        public DateTime Date { get; set; }

        public int Atendees { get; set; }
    }
}
