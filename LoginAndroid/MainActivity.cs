using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;

namespace LoginAndroid
{
    [Activity(Label = "LoginAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += button2_Click;
        }

        private void button2_Click(object sender, EventArgs ea)
        {
            //AlertDialog.Builder alert = new AlertDialog.Builder(this);
            //alert.SetTitle("Confirm delete");
            //alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
            //alert.SetPositiveButton("Delete", (senderAlert, args) => {
            //    Toast.MakeText(this, "Deleted!", ToastLength.Short).Show();
            //});

            //alert.SetNegativeButton("Cancel", (senderAlert, args) => {
            //    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
            //});

            //Dialog dialog = alert.Create();
            //dialog.Show();
            SetContentView(Resource.Layout.Register);
        }
    }
}