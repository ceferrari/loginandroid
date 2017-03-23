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

namespace LoginAndroid.Builders
{
    public static class AlertBuilder
    {
        public static void Build(Context context, string title, string message = null)
        {
            var alert = new AlertDialog.Builder(context);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetPositiveButton("OK", (senderAlert, args) => { });
            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}