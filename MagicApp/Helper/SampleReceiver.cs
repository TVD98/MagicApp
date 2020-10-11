using System;
using Android.App;
using Android.Content;
using MagicApp.Activity;

namespace MagicApp.Helper
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionScreenOff})]
    public class SampleReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            context.StartActivity(typeof(LoginActivity));
        }
    }
}
