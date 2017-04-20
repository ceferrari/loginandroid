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
    [Activity(Label = "Home", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class HomeActivity : Activity
    {
        Button signOut;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);
            signOut = (Button)FindViewById(Resource.Id.btnLogout);
            signOut.Click += SignOut_Click;
        }

        void SignOut_Click(object sender, EventArgs e)
        {
            ISharedPreferences session = GetSharedPreferences(MainActivity.userSessionPref, FileCreationMode.Private);
            ISharedPreferencesEditor editor = session.Edit();
            editor.Clear();
            editor.Commit();
            Intent m = new Intent(this, typeof(MainActivity));
            StartActivity(m);
            Finish();
        }
    }
}