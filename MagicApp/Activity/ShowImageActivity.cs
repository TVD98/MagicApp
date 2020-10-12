using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using MagicApp.Fragments;
using MagicApp.Helper;
using Newtonsoft.Json;
using static Android.Widget.ViewSwitcher;

namespace MagicApp.Activity
{
    [Activity(Label = "ShowImageActivity")]
    public class ShowImageActivity : AppCompatActivity
    {
        public const string imageCode = "SELECTED_IMAGE_ID";
        public const string imageListCode = "IMAGE_ID_LIST";

        public ViewPager viewPager;
        public View frmLayout1;
        public View mainContainer;
        public Android.Support.V4.App.FragmentManager fm;

        private Item[] itemList;
        private Item selectedImage;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_show_image);

            viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            frmLayout1 = FindViewById<FrameLayout>(Resource.Id.frameLayout1);

            string json = Intent.GetStringExtra(imageListCode);
            itemList = JsonConvert.DeserializeObject<Item[]>(json);
            selectedImage = JsonConvert.DeserializeObject<Item>(Intent.GetStringExtra(imageCode));

            ImageViewAdapter adapter = new ImageViewAdapter(itemList, this);
            viewPager.Adapter = adapter;
            viewPager.CurrentItem = GetCurrentImagePosition();

            fm = SupportFragmentManager;
            Android.Support.V4.App.FragmentTransaction ft = fm.BeginTransaction();
            ft.Add(Resource.Id.frameLayout1, new FragmentProperties());
            ft.Commit();

            EventManager.Instance.EventPhotoViewTouched += HandlePhotoViewTouched;
        }

        private void HandlePhotoViewTouched()
        {
            if (frmLayout1.Visibility == ViewStates.Visible)
            {
                frmLayout1.Visibility = ViewStates.Invisible;
                viewPager.SetBackgroundResource(Resource.Color.black);
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.Fullscreen;
            }
            else
            {
                frmLayout1.Visibility = ViewStates.Visible;
                viewPager.SetBackgroundResource(Resource.Color.white);
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.Visible;
            }
        }

        private int GetCurrentImagePosition()
        {
            for (int i = 0; i < itemList.Length; i++)
            {
                if (itemList[i].url == selectedImage.url
                    || (itemList[i].imageId == selectedImage.imageId
                    && itemList[i].imageId != 0))
                    return i;
            }
            return 0;
        }
    }

}
