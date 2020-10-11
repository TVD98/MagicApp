using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Bumptech.Glide;
using MagicApp.Models;

namespace MagicApp.Helper
{
    public class AlbumHolder : RecyclerView.ViewHolder
    {
        public TextView title;
        public ImageView imageView;
        public TextView imageCount;
        public AlbumHolder(View view) : base(view)
        {
            title = view.FindViewById<TextView>(Resource.Id.textTitleItemAlbum);
            imageView = view.FindViewById<ImageView>(Resource.Id.imageItemAlbum);
            imageCount = view.FindViewById<TextView>(Resource.Id.textItemAlbumCount);
        }
    }

    class AlbumAdapter : RecyclerView.Adapter
    {
        private List<Album> albums = new List<Album>();
        private Context context;

        public AlbumAdapter(List<Album> albums, Context context)
        {
            this.albums = albums;
            this.context = context;
        }

        public override int ItemCount
        {
            get
            {
                return albums.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            AlbumHolder view = (AlbumHolder)holder;
            view.title.Text = albums[position].Title;
            Glide.With(context).Load(albums[position].ImageId)
                .CenterCrop()
                .Into(view.imageView);
            view.imageCount.Text = albums[position].ImageListCount.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View view = inflater.Inflate(Resource.Layout.item_album, parent, false);
            return new AlbumHolder(view);
        }
    }
}