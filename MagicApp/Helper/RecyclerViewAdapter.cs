using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace MagicApp.Helper
{
    public class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public TextView title;
        public RecyclerView recyclerView;

        public RecyclerViewHolder(View view) : base(view)
        {
            title = view.FindViewById<TextView>(Resource.Id.title);
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewItem);
        }
    }

    public class RecyclerViewAdapter : RecyclerView.Adapter
    {
        public List<Data> datas = new List<Data>();
        public Context context;

        public RecyclerViewAdapter(List<Data> datas, Context context)
        {
            this.datas = datas;
            this.context = context;
        }

        public override int ItemCount
        {
            get
            {
                return datas.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder view = holder as RecyclerViewHolder;
            view.title.Text = datas[position].GetTitle();
            int count = datas[position].itemList.Count;
            view.recyclerView.SetAdapter(new RecyclerViewItemAdapter(datas[position].itemList.GetRange(0, count - 1), context));
            view.recyclerView.SetLayoutManager(new GridLayoutManager(context, Contrainst.GRID_VIEW_COUNT));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_collection, parent, false);
            return new RecyclerViewHolder(view);
        }
    }
}
