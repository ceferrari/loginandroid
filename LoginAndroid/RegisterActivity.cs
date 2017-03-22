using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LoginAndroid
{
    [Activity(Label = "Android", MainLauncher = false, Icon = "@drawable/icon")]
    public class RegisterActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Register);

            var btnBackToLogin = FindViewById<Button>(Resource.Id.btnBackToLogin);
            btnBackToLogin.Click += btnBackToLogin_Click;
        }

        private void btnBackToLogin_Click(object sender, EventArgs ea)
        {
            SetContentView(Resource.Layout.Main);
        }
    }
}