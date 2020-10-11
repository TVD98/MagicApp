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
using AndroidX.RecyclerView.Widget;
using Bumptech.Glide;
using MagicApp.Activity;

namespace MagicApp.Helper
{
    class RecyclerViewItemDataHolder : RecyclerView.ViewHolder
    {
        public ImageView imageView;
        public RecyclerViewItemDataHolder(View view) : base(view)
        {
            imageView = view.FindViewById<ImageView>(Resource.Id.imageViewItem);
        }
    }
    class RecyclerViewItemDataAdapter : RecyclerView.Adapter, View.IOnClickListener, View.IOnLongClickListener
    {
        public List<Item> images = new List<Item>();
        public Context context;

        public RecyclerViewItemDataAdapter(List<Item> images, Context context)
        {
            this.images = images;
            this.context = context;
        }

        public override int ItemCount
        {
            get
            {
                return images.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewItemDataHolder view = (RecyclerViewItemDataHolder)holder;
            if (string.IsNullOrEmpty(images[position].url))
            {
                view.imageView.SetImageResource(Resource.Mipmap.ic_launcher);
            }
            else
            {
                Glide.With(context).Load(images[position].url)
                    .CenterCrop()
                    .Into(view.imageView);
            }
            view.imageView.ContentDescription = position.ToString();
            view.imageView.SetOnClickListener(this);
            view.imageView.SetOnLongClickListener(this);
        }

        public void OnClick(View v)
        {
            int pos = int.Parse(v.ContentDescription);
            LoadImage(pos);
        }

        public bool OnLongClick(View v)
        {
            int pos = int.Parse(v.ContentDescription);
            if (pos == images.Count - 1)
            {
                return false;
            }
            else
            {
                images.RemoveAt(pos);
                Toast.MakeText(context, "Xóa thành công ", ToastLength.Short).Show();
                NotifyDataSetChanged();
                return true;
            }
        }

        private async void LoadImage(int pos)
        {
            string urlPath = images[pos].url;
            string filePath = await Contrainst.LoadImageFromGallery(context);
            if (!string.IsNullOrEmpty(filePath))
            {
                images[pos].url = filePath;
                if (string.IsNullOrEmpty(urlPath))
                {
                    images.Add(new Item());
                }
                NotifyDataSetChanged();
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_image, parent, false);
            return new RecyclerViewItemDataHolder(view);
        }

        
    }
}