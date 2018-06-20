using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingApp
{
    public class Events
    {
        List<FreeSpots> listOfSpots;
        List<Visitor> listOfVisitors;
        List<GetResDetails> listoftents;

        public Events()
        {
            listOfSpots = new List<FreeSpots>();
            listOfVisitors = new List<Visitor>();
            listoftents = new List<GetResDetails>();
        }
        public void AddVisitor(Visitor v)
        {
            if (listOfVisitors.Count != 0)
            {
                foreach (Visitor vs in listOfVisitors)
                {
                    if (vs.Rfid != v.Rfid)
                    {
                        listOfVisitors.Add(v);
                    }
                }
            }
            else
            {
                listOfVisitors.Add(v);
            }
        }

        public void AddFreeSpots(FreeSpots s)
        {
            listOfSpots.Add(s);
        }
        public void ClearSpots()
        {
            listOfSpots.Clear();
        }
        public void AddOnlyTent(GetResDetails t)
        {
            listoftents.Add(t);
        }
        public GetResDetails GetDetails()
        {
            foreach (GetResDetails ad in listoftents)
            {
                return ad;
            }
            return null;
        }
        public List<Visitor> GetListOfVisitors()
        {
            return listOfVisitors;
        }
        public List<FreeSpots> GetListOfFreeSpots()
        {
            return listOfSpots;
        }

    }
}
