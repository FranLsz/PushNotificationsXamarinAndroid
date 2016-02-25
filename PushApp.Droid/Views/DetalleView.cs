using Android.App;
using Android.Views;
using MvvmCross.Droid.Views;
using PushApp.Core.ViewModels;

namespace PushApp.Droid.Views
{
    [Activity(Label = "Detalle del smartphone")]
    public class DetalleView : MvxActivity
    {
        public new DetalleViewModel ViewModel
        {
            get { return (DetalleViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }


        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.Detalle);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Finish();
            return true;
        }
    }
}