using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using MagicApp.Helper;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Android.Util;
using Android.App;
using Android.Widget;
using MagicApp.Activity;
using System;
using MagicApp.Fragments;
using Newtonsoft.Json;
using Android.Support.V4.View;
using Android.Support.Design.Widget;

namespace MagicApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        TabLayout tabLayout;
        ViewPager viewPager;
        public SampleReceiver receiver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            receiver = new SampleReceiver();
            RegisterReceiver(receiver, new IntentFilter(Intent.ActionScreenOff));

            AddControl();

            EventManager.Instance.EventImageClicked += HandleImageClicked;

           
        }

        private void HandleImageClicked(object[] datas)
        {
            Item item = (Item)datas[0];
            View view = (View)datas[1];

            Intent intent = new Intent(this, typeof(ShowImageActivity));
            intent.PutExtra(ShowImageActivity.imageListCode, JsonConvert.SerializeObject(FragmentCollection.itemList.ToArray()));
            intent.PutExtra(ShowImageActivity.imageCode, JsonConvert.SerializeObject(item));
            intent.AddFlags(ActivityFlags.ClearTop);

            Pair[] pairs = new Pair[1];
            pairs[0] = new Pair(view, Contrainst.TRANSITION_NAME);

            ActivityOptions options = ActivityOptions.MakeSceneTransitionAnimation(this, pairs);
            StartActivity(intent, options.ToBundle());
        }

        private void AddControl()
        {
            tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
            viewPager = FindViewById<ViewPager>(Resource.Id.viewPagerLayout);
            MainPagerAdapter adapter = new MainPagerAdapter(SupportFragmentManager);
            viewPager.Adapter = adapter;
            tabLayout.SetupWithViewPager(viewPager);
            viewPager.AddOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(tabLayout));
            tabLayout.SetTabsFromPagerAdapter(adapter);
            tabLayout.AddOnTabSelectedListener(new TabLayout.ViewPagerOnTabSelectedListener(viewPager));
            
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
