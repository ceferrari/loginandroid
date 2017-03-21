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

            var button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs ea)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Confirm delete");
            alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
            alert.SetPositiveButton("Delete", (senderAlert, args) => {
                Toast.MakeText(this, "Deleted!", ToastLength.Short).Show();
            });

            alert.SetNegativeButton("Cancel", (senderAlert, args) => {
                Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}