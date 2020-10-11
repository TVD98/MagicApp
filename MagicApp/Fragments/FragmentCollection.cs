using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MagicApp.Helper;
using MagicApp.Activity;
using Newtonsoft.Json;
using Android.Content;
using AndroidX.RecyclerView.Widget;
using Android.Support.V4.App;

namespace MagicApp.Fragments
{
    public class FragmentCollection : Fragment
    {
        private View view;
        private RecyclerView recyclerView;
        private List<Data> datas = new List<Data>();
        public static List<Item> itemList = new List<Item>();
        public FragmentCollection()
        {

        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewCollection);

            InitData();

            RecyclerViewAdapter adapter = new RecyclerViewAdapter(datas, Activity);
            recyclerView.SetAdapter(adapter);
            recyclerView.SetLayoutManager(new LinearLayoutManager(Activity));


        }

        private void InitData()
        {
            string json = Contrainst.GetData(Activity, Contrainst.KEY_NAME_COLLECTION);

            //string json = Contrainst.GetData(Activity, Contrainst.KEY_NAME_DATA);
            //if (!string.IsNullOrEmpty(json))
            //{
            //    Data obj = JsonConvert.DeserializeObject<Data>(json);
            //    int index = datas.FindIndex(x => x.CompareTo(obj) == 0);
            //    if (index >= 0)
            //        datas[index] = obj;
            //    else
            //        datas.Add(obj);
            //}
            if (!string.IsNullOrEmpty(json))
            {
                datas = JsonConvert.DeserializeObject<List<Data>>(json);
            }

            datas.Sort();
            datas.Reverse();
            foreach (Data dt in datas)
            {
                for (int i = 0; i < dt.itemList.Count - 1; i++)
                {
                    itemList.Add(dt.itemList[i]);
                }
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.fragment_collection, container, false);
            return view;
        }
    }
}