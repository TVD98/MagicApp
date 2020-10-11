using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Java.Util;
using MagicApp.Helper;
using Newtonsoft.Json;

namespace MagicApp.Activity
{
    [Activity(Label = "UpLoadImagesActivity")]
    public class UpLoadImagesActivity : AppCompatActivity
    {
        public Button buttonSave;
        public Button buttonAdd;
        public RecyclerView recyclerView;
        public List<Data> collections = new List<Data>();
        private RecyclerViewDataAdapter adapter;

        readonly string[] permissionGroup =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_upload_images);

            RequestPermissions(permissionGroup, 0);

            buttonAdd = FindViewById<Button>(Resource.Id.buttonAdd);
            buttonSave = FindViewById<Button>(Resource.Id.buttonSave);
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewData);

            InitData();

            Display();

            buttonSave.Click += delegate
            {
                SaveData();
            };

            buttonAdd.Click += delegate
            {
                AddCollection();
            };
        }

        private void AddCollection()
        {
            Data data = new Data();
            data.AddItem(new Item());
            collections.Add(data);
            adapter.NotifyDataSetChanged();
            Toast.MakeText(this, "Thêm thành công", ToastLength.Short).Show();
        }

        private void SaveData()
        {
            Contrainst.SaveData(this, JsonConvert.SerializeObject(collections), Contrainst.KEY_NAME_COLLECTION);
            Toast.MakeText(this, "Lưu thành công", ToastLength.Short).Show();
        }

        private void Display()
        {
            adapter = new RecyclerViewDataAdapter(collections, this);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));         
            recyclerView.SetAdapter(adapter);
        }

        private void InitData()
        {
            string json = Contrainst.GetData(this, Contrainst.KEY_NAME_COLLECTION);
            if (string.IsNullOrEmpty(json))
            {
                Data data = new Data();
                data.AddItem(new Item());
                collections.Add(data);
            }
            else collections = JsonConvert.DeserializeObject<List<Data>>(json);
            collections.Sort();
            collections.Reverse();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}