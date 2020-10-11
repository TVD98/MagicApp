using System;
namespace MagicApp.Helper
{
    public class Item
    {
        public int imageId;
        public string url;
        public DateTime date;

        public Item(int imageId, DateTime date)
        {
            this.imageId = imageId;
            this.date = date;
        }

        public Item()
        {
            imageId = 0;
            url = "";
        }
    }
}
