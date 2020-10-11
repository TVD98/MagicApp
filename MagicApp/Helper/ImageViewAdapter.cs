using System;
using Android.Content;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using Bumptech.Glide;
using ImageViews.Photo;

namespace MagicApp.Helper
{
 
    public class ImageViewAdapter : PagerAdapter, View.IOnClickListener
    {
        public Context context;
        public Item[] items;

        public ImageViewAdapter(Item[] itemList, Context context)
        {
            this.context = context;
            this.items = itemList;
        }

        public override int Count
        {
            get
            {
                return items.Length;
            }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == @object;
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            //ImageView imageView = new ImageView(context);
            PhotoView imageView = new PhotoView(context);
            imageView.SetScaleType(ImageView.ScaleType.FitCenter);
            Glide.With(context).Load(items[position].url)
                .Into(imageView);
            container.AddView(imageView);
            imageView.SetOnClickListener(this);
            return imageView;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            //ImageView imageView = (ImageView)@object;
            PhotoView imageView = (PhotoView)@object;
            container.RemoveView(imageView);
        }
        public void OnClick(View v)
        {
            EventManager.Instance.SendEventTouched();
        }
    }
}
