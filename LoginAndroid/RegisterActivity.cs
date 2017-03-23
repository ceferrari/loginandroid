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
using LoginAndroid.Models;
using LoginAndroid.Repositories;

namespace LoginAndroid
{
    [Activity(Label = "Register", MainLauncher = false, Icon = "@drawable/icon")]
    public class RegisterActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Register);

            var btnSalvar = FindViewById<Button>(Resource.Id.btnSalvar);
            btnSalvar.Click += btnSalvar_Click;
        }

        private void btnSalvar_Click(object sender, EventArgs ea)
        {
            var nome = FindViewById<EditText>(Resource.Id.etNome).Text;
            var email = FindViewById<EditText>(Resource.Id.etEmail).Text;
            var senha = FindViewById<EditText>(Resource.Id.etSenha).Text;
            var confirmarSenha = FindViewById<EditText>(Resource.Id.etConfirmarSenha).Text;

            var user = new User(nome, email, senha);

            if (PodeCadastrar(user, confirmarSenha))
            {
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Sucesso");
                alert.SetMessage("Usuário cadastrado com sucesso!");
                alert.SetPositiveButton("OK", (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();

                UserRepository.Users.Add(user);
            }
        }

        private bool PodeCadastrar(User user, string confirmarSenha)
        {
            if (user.Nome.Length <= 3)
            {
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Alerta");
                alert.SetMessage("O nome deve ter pelo menos 3 caracteres.");
                alert.SetPositiveButton("OK", (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();
                return false;
            }
            if (!user.Email.Contains("@"))
            {
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Alerta");
                alert.SetMessage("Informe um email válido.");
                alert.SetPositiveButton("OK", (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();
                return false;

            }
            if (user.Senha.Length <= 3)
            {
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Alerta");
                alert.SetMessage("Informe uma senha válida.");
                alert.SetPositiveButton("OK", (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();
                return false;
            }
            if (!user.Senha.Equals(confirmarSenha))
            {
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Alerta");
                alert.SetMessage("Senha não coincidem.");
                alert.SetPositiveButton("OK", (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();
                return false;
            }

            return true;
        }
    }
}