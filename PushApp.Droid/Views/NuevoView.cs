using Android.App;
using MvvmCross.Droid.Views;
using PushApp.Core.ViewModels;

namespace PushApp.Droid.Views
{
    [Activity(Label = "Nuevo smartphone")]
    public class NuevoView : MvxActivity
    {
        public new NuevoViewModel ViewModel
        {
            get { return (NuevoViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            SetContentView(Resource.Layout.Nuevo);
        }
    }
}