using System;
using System.Collections.Generic;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Bumptech.Glide;

namespace MagicApp.Helper
{
    public class RecyclerViewItemHolder : RecyclerView.ViewHolder
    {
        public ImageView imageView;
        

        public RecyclerViewItemHolder(View view) : base(view)
        {
            imageView = view.FindViewById<ImageView>(Resource.Id.imageViewItem);
        }
    }

    public class RecyclerViewItemAdapter : RecyclerView.Adapter
    {
        public List<Item> itemList = new List<Item>();
        public Context context;

        public RecyclerViewItemAdapter(List<Item> itemList, Context context)
        {
            this.itemList = itemList;
            this.context = context;
        }

        public override int ItemCount
        {
            get
            {
                return itemList.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewItemHolder view = holder as RecyclerViewItemHolder;
            Glide.With(context).Load(itemList[position].url)
                .CenterCrop()
                .Into(view.imageView);
            view.imageView.Click += delegate {
                object[] datas = {itemList[position].url, view.imageView };
                EventManager.Instance.Send(datas);
            };
        }
       

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_image, parent, false);
            return new RecyclerViewItemHolder(view);
        }


    }
}
