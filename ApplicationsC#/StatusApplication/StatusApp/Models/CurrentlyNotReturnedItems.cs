namespace StatusApp.Models
{
    public class CurrentlyNotReturnedItems
    {
        public CurrentlyNotReturnedItems(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
