using Android.Bluetooth;
using Android.Content;
using Android.Telephony;
using Gcm;
using Java.Util;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using PushApp.Core;
using PushApp.Core.Utiles;

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
            // Revisa el dispositivo y el manifiesto
            GcmClient.CheckDevice(applicationContext);
            GcmClient.CheckManifest(applicationContext);

            // Registra el dispositivo
            GcmClient.Register(applicationContext, Constantes.SenderId);
        }
    }
}