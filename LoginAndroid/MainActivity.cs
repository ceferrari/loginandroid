using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using LoginAndroid.Repositories;

namespace LoginAndroid
{
    [Activity(Label = "Main", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            var button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += button2_Click;

            var button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += button1_Click;
        }

        private void button2_Click(object sender, EventArgs ea)
        {
            StartActivity(typeof(RegisterActivity));
        }

        private void button1_Click(object sender, EventArgs ea)
        {
            var usuario = FindViewById<EditText>(Resource.Id.etUsuario).Text;
            var senha = FindViewById<EditText>(Resource.Id.etSenha).Text;

            if (UsuarioValido())
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Sucesso");
                Dialog dialog = alert.Create();
                dialog.Show();
            }
            else
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Erro");
                Dialog dialog = alert.Create();
                dialog.Show();
            }


        }

        private bool UsuarioValido()
        {
            
            return true;
        }
    }
}