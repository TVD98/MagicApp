using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MagicApp.Models;
using MagicApp.Helper;
using AndroidX.RecyclerView.Widget;
using Android.Support.V4.App;
using MagicApp.Activity;

namespace MagicApp.Fragments
{
    public class FragmentAlbum : Fragment
    {
        private View view;
        private RecyclerView recyclerView;
        private Button buttonSetting;

        private List<Album> albums = new List<Album>();

        public FragmentAlbum()
        {
            
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewAlbum);
            buttonSetting = view.FindViewById<Button>(Resource.Id.buttonSetting);

            InitData();

            AlbumAdapter adapter = new AlbumAdapter(albums, Activity);
            recyclerView.SetAdapter(adapter);
            recyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            buttonSetting.Click += delegate
            {
                StartSetting();
            };
        }

        private void StartSetting()
        {
            Activity.StartActivity(typeof(UpLoadImagesActivity));
        }

        private void InitData()
        {
            string[] titleList = Resources.GetStringArray(Resource.Array.title_album);
            int[] itemsCount = Resources.GetIntArray(Resource.Array.item_album_count);

            for (int i = 0; i < titleList.Length; i++)
            {
                Album album = new Album(Contrainst.GetImage(i), titleList[i], itemsCount[i]);
                albums.Add(album);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.fragment_album, container, false);
            return view;
        }
    }
}