﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using System.Linq;
using LoginAndroid.Models;
using LoginAndroid.Repositories;

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
            var usuario = FindViewById<EditText>(Resource.Id.etUsuario).Text;
            var senha = FindViewById<EditText>(Resource.Id.etSenha).Text;

            if (UsuarioValido(usuario, senha))
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
                var dialog = alert.Create();
                dialog.Show();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs ea)
        {
            StartActivity(typeof(RegisterActivity));
        }

        private bool UsuarioValido(string usuario, string senha)
        {
            return UserRepository.Users.Any(x => x.Email.Equals(usuario) && x.Senha.Equals(senha));
        }
    }
}