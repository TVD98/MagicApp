using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Icu.Util;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace MagicApp.Helper
{
    class RecyclerViewDataHolder : RecyclerView.ViewHolder
    {
        public TextView textViewDate;
        public RecyclerView recyclerView;
        
        public RecyclerViewDataHolder(View view) : base(view)
        {
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewItemData);
            textViewDate = view.FindViewById<TextView>(Resource.Id.textViewDate);
        }
    }
    class RecyclerViewDataAdapter : RecyclerView.Adapter, DatePickerDialog.IOnDateSetListener
    {
        public List<Data> collections = new List<Data>();
        public Context context;
        private int selectedCollection = 0;

        public RecyclerViewDataAdapter(List<Data> collections, Context context)
        {
            this.collections = collections;
            this.context = context;
        }

        public override int ItemCount
        {
            get
            {
                return collections.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewDataHolder view = (RecyclerViewDataHolder)holder;
            if(collections[position].date.CompareTo(DateTime.MinValue) != 0)
            {
                view.textViewDate.Text = collections[position].GetTitle();
            }
            view.recyclerView.SetLayoutManager(new GridLayoutManager(context, 4));
            RecyclerViewItemDataAdapter adapter = new RecyclerViewItemDataAdapter(collections[position].itemList, context);
            view.recyclerView.SetAdapter(adapter);
            view.textViewDate.ContentDescription = position.ToString();
            view.textViewDate.Click += delegate
            {
                selectedCollection = position;
                ChoseDateTime();
            };
        }

        private void ChoseDateTime()
        {
            Calendar cal = Calendar.Instance;
            int year = cal.Get(CalendarField.Year);
            int month = cal.Get(CalendarField.Month);
            int day = cal.Get(CalendarField.DayOfMonth);

            DatePickerDialog dialog = new DatePickerDialog(
                context,
                Resource.Style.Theme_AppCompat_DayNight_Dialog_MinWidth,
                this,
                year, month, day);
            dialog.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
            dialog.Show();
        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            month += 1;
            DateTime date = new DateTime(year, month, dayOfMonth);
            collections[selectedCollection].date = date;
            NotifyDataSetChanged();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_data, parent, false);
            return new RecyclerViewDataHolder(view);
        }

        
    }
}