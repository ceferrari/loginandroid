using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using System.Linq;
using LoginAndroid.Models;
using LoginAndroid.Repositories;
using System.Linq;
using LoginAndroid.Models;

namespace LoginAndroid
{
    [Activity(Label = "Main", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);
            btnRegistrar.Click += btnRegistrar_Click;

            var btnEntrar = FindViewById<Button>(Resource.Id.btnEntrar);
            btnEntrar.Click += btnEntrar_Click;
        }
        
        private void btnEntrar_Click(object sender, EventArgs ea)
        {
            var email = FindViewById<EditText>(Resource.Id.etEmail).Text;
            var senha = FindViewById<EditText>(Resource.Id.etSenha).Text;

            if (UsuarioValido(email, senha))
            {
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Sucesso");
                var dialog = alert.Create();
                dialog.Show();
            }
            else
            {
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Erro");
                alert.SetMessage("E-mail e/ou Senha inválidos");
                alert.SetPositiveButton("OK", (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs ea)
        {
            StartActivity(typeof(RegisterActivity));
        }

        private bool UsuarioValido(string email, string senha)
        {
            return UserRepository.Users.Any(x => x.Email.Equals(email) && x.Senha.Equals(senha));
        }
    }
}