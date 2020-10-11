using System;
using System.Collections.Generic;

namespace MagicApp.Helper
{
    public class Data : IComparable<Data>
    {
        public DateTime date;
        public List<Item> itemList = new List<Item>();

        public Data(DateTime date)
        {
            this.date = date;
        }

        public Data()
        {
            this.date = DateTime.MinValue;
        }

        public void AddItem(Item item)
        {
            itemList.Add(item);
        }

        public int CompareTo(Data other)
        {
            if (date.Day == other.date.Day && date.Month == other.date.Year
                && date.Year == other.date.Year)
                return 0;
            return date.CompareTo(other.date);
        }

        public string GetTitle()
        {
            TimeSpan span = DateTime.Today - date;
            int since = (int)span.TotalDays;
            if (since == 0)
                return "Hôm nay";
            if (since == 1)
                return "Hôm qua";
            return string.Format("{0} Th {1}", date.Day, date.Month);
        }
    }
}
