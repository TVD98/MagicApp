using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MagicApp.Models
{
    class Album
    {
        private int imageId;
        private string title;
        private int imageListCount;

        public int ImageId { get { return imageId; } }
        public string Title { get { return title; } }
        public int ImageListCount { get { return imageListCount; } }

        public Album(int imageId, string title, int imageListCount)
        {
            this.imageId = imageId;
            this.title = title;
            this.imageListCount = imageListCount;
        }
    }
}