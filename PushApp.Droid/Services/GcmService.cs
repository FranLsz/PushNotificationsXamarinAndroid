using System;
using System.Collections.Generic;
using System.Text;
using WindowsAzure.Messaging;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Gcm.Client;
using PushApp.Core.Utils;

[assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]
//GET_ACCOUNTS is only needed for android versions 4.0.3 and below
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]

namespace PushApp.Droid.Services
{
    [BroadcastReceiver(Permission = Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new[] { Constants.INTENT_FROM_GCM_MESSAGE }, Categories = new[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new[] { Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK }, Categories = new[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new[] { Constants.INTENT_FROM_GCM_LIBRARY_RETRY }, Categories = new[] { "@PACKAGE_NAME@" })]
    public class BroadcastReceiver : GcmBroadcastReceiverBase<PushHandlerService>
    {
        public static string[] SENDER_IDS = { GlobalVars.SenderID };
        public const string TAG = "BroadcastReceiver-GCM";
    }

    [Service] // Must use the service tag
    public class PushHandlerService : GcmServiceBase
    {
        public static string RegistrationID { get; private set; }
        private NotificationHub Hub { get; set; }

        public PushHandlerService() : base(BroadcastReceiver.SENDER_IDS) { }

        protected override void OnError(Context context, string errorId)
        {

        }

        protected override void OnMessage(Context context, Intent intent)
        {

            var msg = new StringBuilder();

            if (intent != null && intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                {
                    msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
                }
            }
            string messageText = intent.Extras.GetString("msg");
            string parameterText = intent.Extras.GetString("param");
            if (!string.IsNullOrEmpty(messageText))
            {
                CreateNotification("Awesome Notification...", messageText, parameterText);
                return;
            }

            // If the incoming message's parameters couldn't be recognized, then this Notification will be published...
            CreateNotification("Awesome Notification...", msg.ToString());

        }

        protected override void OnRegistered(Context context, string registrationId)
        {
            RegistrationID = registrationId;

            Hub = new NotificationHub(GlobalVars.NotificationHubPath, GlobalVars.ConnectionString, context);
            try
            {
                Hub.UnregisterAll(registrationId);
            }
            catch (Exception)
            {
                // ignored
            }

            var tags = new List<string>() { "falcons" }; // create tags if you want

            try
            {
                var hubRegistration = Hub.Register(registrationId, tags.ToArray());
            }
            catch (Exception)
            {
                // ignored
            }
        }

        protected override void OnUnRegistered(Context context, string registrationId)
        {

        }

        static void CreateNotification(string title, string desc, string parameters = null)
        {
            var context = Android.App.Application.Context;

            NotificationCompat.Builder builder = new NotificationCompat.Builder(context)
                .SetAutoCancel(true)
                .SetSmallIcon(Resource.Drawable.Icon)
                .SetContentTitle(title)
                .SetContentText(desc);

            var notificationManager = (NotificationManager)context.GetSystemService(NotificationService);

            notificationManager.Notify(17774, builder.Build());

            #region Otra forma (No funciona)

            //Intent startupIntent = new Intent(this, typeof(MainActivity));

            //startupIntent.PutExtra("param", parameters.ToString());

            //TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);

            //stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));

            //stackBuilder.AddNextIntent(startupIntent);

            //const int pendingIntentId = 0;
            //PendingIntent pendingIntent =
            //    stackBuilder.GetPendingIntent(pendingIntentId, PendingIntentFlags.OneShot);

            //Notification.Builder builder = new Notification.Builder(this)
            //    .SetContentIntent(pendingIntent)
            //    .SetContentTitle(title)
            //    .SetContentText(desc)
            //    .SetSmallIcon(Resource.Drawable.icon);

            //// Build the notification:
            //Notification notification = builder.Build();
            //notification.Flags = NotificationFlags.AutoCancel;

            //// Get the notification manager:
            //NotificationManager notificationManager =
            //    GetSystemService(Context.NotificationService) as NotificationManager;

            //// Publish the notification:
            //const int notificationId = 0;
            //notificationManager.Notify(notificationId, notification);

            #endregion
        }

        
    }
}