
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using MagicApp.Helper;
using Newtonsoft.Json;

namespace MagicApp.Activity
{
    [Activity(Label = "activity_login", Theme = "@style/Theme.Login")]
    public class LoginActivity : AppCompatActivity
    {
        public Button button_0;
        public Button button_1;
        public Button button_2;
        public Button button_3;
        public Button button_4;
        public Button button_5;
        public Button button_6;
        public Button button_7;
        public Button button_8;
        public Button button_9;
        public Button button_delete;
        public LinearLayout linearLayout;
        public List<View> views = new List<View>();

        private const int maxLenPass = 6;
        private string password = "";
        private delegate void OnPasswordChanged(string password);
        private event OnPasswordChanged EventPasswordChanged;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            button_0 = FindViewById<Button>(Resource.Id.button_0);
            button_1 = FindViewById<Button>(Resource.Id.button_1);
            button_2 = FindViewById<Button>(Resource.Id.button_2);
            button_3 = FindViewById<Button>(Resource.Id.button_3);
            button_4 = FindViewById<Button>(Resource.Id.button_4);
            button_5 = FindViewById<Button>(Resource.Id.button_5);
            button_6 = FindViewById<Button>(Resource.Id.button_6);
            button_7 = FindViewById<Button>(Resource.Id.button_7);
            button_8 = FindViewById<Button>(Resource.Id.button_8);
            button_9 = FindViewById<Button>(Resource.Id.button_9);
            button_delete = FindViewById<Button>(Resource.Id.btn_delete);
            linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayout);

            button_delete.Enabled = false;

            EventPasswordChanged += SetTextPassword;

            InitViews();

            button_0.Click += delegate
            {
                HandleButtonClicked(0);
            };

            button_1.Click += delegate
            {
                HandleButtonClicked(1);
            };

            button_2.Click += delegate
            {
                HandleButtonClicked(2);
            };

            button_3.Click += delegate
            {
                HandleButtonClicked(3);
            };

            button_4.Click += delegate
            {
                HandleButtonClicked(4);
            };

            button_5.Click += delegate
            {
                HandleButtonClicked(5);
            };

            button_6.Click += delegate
            {
                HandleButtonClicked(6);
            };

            button_7.Click += delegate
            {
                HandleButtonClicked(7);
            };

            button_8.Click += delegate
            {
                HandleButtonClicked(8);
            };

            button_9.Click += delegate
            {
                HandleButtonClicked(9);
            };

            button_delete.Click += delegate
            {
                SetPassword(password.Substring(0, password.Length - 1));
            };
        }

        private void InitViews()
        {
            for (int i = 0; i < linearLayout.ChildCount; i++)
            {
                views.Add(linearLayout.GetChildAt(i));
            }
        }

        public void Login()
        {
            int day = int.Parse(password.Substring(0, 2));
            int month = int.Parse(password.Substring(2, 2));
            DateTime date = new DateTime(DateTime.Today.Year, month, day);
            int card = int.Parse(password.Substring(4, 2));
            Data data = new Data(date);
            data.AddItem(new Item(Contrainst.GetImageCardId(card), date));
            Contrainst.SaveData(this, JsonConvert.SerializeObject(data), Contrainst.KEY_NAME_DATA);
            FinishAffinity();
        }

        private void SetTextPassword(string password)
        {
            for (int i = 0; i < maxLenPass; i++)
            {
                if (i < password.Length)
                {
                    views[i].SetBackgroundResource(Resource.Drawable.circle_selected);
                }
                else views[i].SetBackgroundResource(Resource.Drawable.circle_drawable);
            }
            if (password.Length == maxLenPass)
            {
                Login();
            }
            else if (password.Length == 0)
            {
                button_delete.Enabled = false;
                button_delete.Text = "";
            }
            else
            {
                button_delete.Enabled = true;
                button_delete.Text = Resources.GetString(Resource.String.label_delete);
            }
        }

        public void HandleButtonClicked(int number)
        {
            if (password.Length < maxLenPass)
                SetPassword(password + number);
        }

        private void SetPassword(string pass)
        {
            password = pass;
            EventPasswordChanged.Invoke(password);
        }
    }

}
