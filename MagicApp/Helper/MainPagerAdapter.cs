using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MagicApp.Fragments;

namespace MagicApp.Helper
{
    class MainPagerAdapter : FragmentStatePagerAdapter
    {
        public MainPagerAdapter(FragmentManager fragmentManager) : base(fragmentManager) { 
            
        }
        public override int Count
        {
            get
            {
                return 2;
            }
        }

        public override Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return new FragmentCollection();
                case 1:
                    return new FragmentAlbum();
                default:
                    return null;
            }
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            switch (position)
            {
                case 0:
                    return new Java.Lang.String("Ảnh");
                case 1:
                    return new Java.Lang.String("Album");
                default: 
                    return new Java.Lang.String("");
            }
        }
    }
}