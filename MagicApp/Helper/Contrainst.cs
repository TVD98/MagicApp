using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Widget;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MagicApp.Helper
{
    public static class Contrainst
    {
        public readonly static int GRID_VIEW_COUNT = 4;
        public readonly static string TRANSITION_NAME = "transition_name";
        public readonly static string KEY_NAME_COLLECTION = "COLLECTION";
        public readonly static string KEY_NAME_DATA = "DATA";       
        public readonly static string SHARE_PREFERENCES_NAME = "TVD";
        public readonly static int MAIN_IMAGE_ID = Resource.Drawable.hinhnen_6;

        public static int[] cards = {Resource.Drawable.card_heart_a, Resource.Drawable.card_heart_2, Resource.Drawable.card_heart_3,
        Resource.Drawable.card_heart_4, Resource.Drawable.card_heart_5, Resource.Drawable.card_heart_6, Resource.Drawable.card_heart_7,
        Resource.Drawable.card_heart_8, Resource.Drawable.card_heart_9, Resource.Drawable.card_heart_10, Resource.Drawable.card_diamond_a,
        Resource.Drawable.card_diamond_2, Resource.Drawable.card_diamond_3, Resource.Drawable.card_diamond_4, Resource.Drawable.card_diamond_5,
        Resource.Drawable.card_diamond_6, Resource.Drawable.card_diamond_7, Resource.Drawable.card_diamond_8, Resource.Drawable.card_diamond_9,
        Resource.Drawable.card_diamond_10, Resource.Drawable.card_club_a, Resource.Drawable.card_club_2, Resource.Drawable.card_club_3,
        Resource.Drawable.card_club_4, Resource.Drawable.card_club_5, Resource.Drawable.card_club_6, Resource.Drawable.card_club_7,
        Resource.Drawable.card_club_8, Resource.Drawable.card_club_9, Resource.Drawable.card_club_10, Resource.Drawable.card_sword_a,
        Resource.Drawable.card_sword_2, Resource.Drawable.card_sword_3, Resource.Drawable.card_sword_4, Resource.Drawable.card_sword_5,
        Resource.Drawable.card_sword_6, Resource.Drawable.card_sword_7, Resource.Drawable.card_sword_8, Resource.Drawable.card_sword_9,
        Resource.Drawable.card_sword_10, Resource.Drawable.card_heart_j, Resource.Drawable.card_diamond_j, Resource.Drawable.card_club_j,
        Resource.Drawable.card_sword_j, Resource.Drawable.card_heart_q, Resource.Drawable.card_diamond_q, Resource.Drawable.card_club_q,
        Resource.Drawable.card_sword_q, Resource.Drawable.card_heart_k, Resource.Drawable.card_diamond_k, Resource.Drawable.card_club_k,
        Resource.Drawable.card_sword_k};

        public static int[] images = {Resource.Drawable.hinh_nen_1, Resource.Drawable.hinh_nen_2, Resource.Drawable.hinh_nen_3, Resource.Drawable.hinh_nen_4,
        Resource.Drawable.hinh_nen_5, Resource.Drawable.hinh_nen_6, Resource.Drawable.hinh_nen_7, Resource.Drawable.hinh_nen_8, Resource.Drawable.hinh_nen_9,
        Resource.Drawable.hinh_nen_10, Resource.Drawable.hinh_nen_11, Resource.Drawable.hinh_nen_12, Resource.Drawable.hinh_nen_13, Resource.Drawable.hinh_nen_14,
        Resource.Drawable.hinh_nen_15, Resource.Drawable.hinh_nen_16, Resource.Drawable.hinh_nen_17, Resource.Drawable.hinh_nen_18, Resource.Drawable.hinh_nen_19,
        Resource.Drawable.hinh_nen_20, Resource.Drawable.hinh_nen_21, Resource.Drawable.hinh_nen_22, Resource.Drawable.hinh_nen_23, Resource.Drawable.hinh_nen_24,
        Resource.Drawable.hinh_nen_25};
        public static DateTime IntToDateTime(int since)
        {
            return DateTime.Today.AddDays(0 - since);
        }

        public static int GetImage(int pos)
        {
            return images[pos % images.Length];
        }

        public static string GetData(Context context, string keyName)
        {
            ISharedPreferences shared = context.GetSharedPreferences(SHARE_PREFERENCES_NAME, FileCreationMode.Private);
            string json = shared.GetString(keyName, "");
            return json;
        }

        public static void SaveData(Context context, string data, string keyName)
        {
            ISharedPreferences shared = context.GetSharedPreferences(SHARE_PREFERENCES_NAME, FileCreationMode.Private);
            ISharedPreferencesEditor editor = shared.Edit();
            editor.PutString(keyName, data);
            editor.Apply();
        }

        public static int GetImageCardId(int card)
        {
            if (card >= 1 && card <= cards.Length)
                return cards[card - 1];
            return cards[0];
        }

        public static async Task<string> LoadImageFromGallery(Context context)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Toast.MakeText(context, "Upload not supported on this device", ToastLength.Short).Show();
                return null;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Full,
                CompressionQuality = 100,
            });

            if (file == null)
            {
                return null;
            }

            return file.Path;
        }

    }


}
