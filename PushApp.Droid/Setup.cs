using Android.Bluetooth;
using Android.Content;
using Android.Telephony;
using Gcm;
using Java.Util;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using PushApp.Core;
using PushApp.Core.Services;
using PushApp.Core.Utils;

namespace PushApp.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
            RegisterWithGcm(applicationContext);
        }


        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        private void RegisterWithGcm(Context applicationContext)
        {
            // Check to ensure everything's setup right
            GcmClient.CheckDevice(applicationContext);
            GcmClient.CheckManifest(applicationContext);

            // Register for push notifications
            GcmClient.Register(applicationContext, GlobalVars.SenderID);
        }
    }
}