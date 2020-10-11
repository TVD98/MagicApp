using System;
using Android.Views;

namespace MagicApp.Helper
{
    public class EventManager
    {
        private static EventManager instance = null;
        public static EventManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventManager();
                }
                return instance;
            }
        }

        public delegate void On_ClickSelectedImage(object[] datas);
        public On_ClickSelectedImage EventImageClicked;
        public void Send(object[] datas)
        {
            EventImageClicked?.Invoke(datas);
        }

        public delegate void On_TouchPhotoView();
        public On_TouchPhotoView EventPhotoViewTouched;

        public void SendEventTouched()
        {
            EventPhotoViewTouched?.Invoke();
        }
    }
}
