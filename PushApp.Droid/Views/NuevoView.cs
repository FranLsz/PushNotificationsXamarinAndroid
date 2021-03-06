﻿using Android.App;
using Android.Views;
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

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.Nuevo);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Finish();
            return true;
        }
    }
}