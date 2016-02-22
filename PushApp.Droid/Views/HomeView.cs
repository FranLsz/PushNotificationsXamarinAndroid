using Android.App;
using Android.Widget;
using MvvmCross.Droid.Views;
using PushApp.Core.ViewModels;

namespace PushApp.Droid.Views
{
    [Activity(Label = "Home", MainLauncher = true)]
    public class HomeView : MvxActivity
    {
        public new HomeViewModel ViewModel
        {
            get { return (HomeViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();


            Button button = FindViewById<Button>(Resource.Id.button1);
            TextView textview = FindViewById<TextView>(Resource.Id.textView1);

            SetContentView(Resource.Layout.Home);



        }
    }
}