using Android.App;
using MvvmCross.Droid.Views;
using PushApp.Core.ViewModels;

namespace PushApp.Droid.Views
{
    [Activity(Label = "Detalles")]
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

            SetContentView(Resource.Layout.Detalle);
        }
    }
}