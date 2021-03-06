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
using LoginAndroid.Builders;
using LoginAndroid.Models;
using LoginAndroid.Repositories;

namespace LoginAndroid
{
    [Activity(Label = "Register", MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
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
                AlertBuilder.Build(this, "Sucesso", "Usu�rio cadastrado com sucesso!");

                UserRepository.Db.Insert(user);
            }

        }

        private bool PodeCadastrar(User user, string confirmarSenha)
        {
            if (user.Nome.Length <= 3)
            {
                AlertBuilder.Build(this, "Alerta", "O nome deve ter pelo menos 3 caracteres.");

                return false;
            }
            if (!user.Email.Contains("@"))
            {
                AlertBuilder.Build(this, "Alerta", "Informe um email v�lido.");

                return false;

            }
            if (user.Senha.Length <= 3)
            {
                AlertBuilder.Build(this, "Alerta", "Informe uma senha v�lida.");

                return false;
            }
            if (!user.Senha.Equals(confirmarSenha))
            {
                AlertBuilder.Build(this, "Alerta", "Senhas n�o coincidem.");

                return false;
            }

            return true;
        }
    }
}