using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using System.Linq;
using LoginAndroid.Builders;
using LoginAndroid.Models;
using LoginAndroid.Repositories;
using System.Linq;
using Android.Content;
using LoginAndroid.Models;

namespace LoginAndroid
{
    [Activity(Label = "Main", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, View.IOnClickListener
    {
        EditText email, password;
        Button signIn;
        private static String userSessionPref = "userPref";
        private static String User_Email = "userEmail";
        private static String User_Password = "user_Password";
        private ISharedPreferences session;
        private string _sessionEmail;
        private string _sessionPass;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            checkCredentials();
            Initialize();
            session = GetSharedPreferences(userSessionPref, FileCreationMode.Private);

            var btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);
            btnRegistrar.Click += btnRegistrar_Click;

            //var btnEntrar = FindViewById<Button>(Resource.Id.btnEntrar);
            //btnEntrar.Click += btnEntrar_Click;
        }

        public void Initialize()
        {
            this.email = (EditText)FindViewById(Resource.Id.etEmail);
            password = (EditText)FindViewById(Resource.Id.etSenha);
            signIn = (Button)FindViewById(Resource.Id.btnEntrar);
            signIn.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.btnEntrar:
                    _sessionEmail = email.Text.ToString();
                    _sessionPass = password.Text.ToString();
                    ISharedPreferencesEditor session_editor = session.Edit();
                    session_editor.PutString("email", _sessionEmail);
                    session_editor.PutString("pass", _sessionPass);
                    session_editor.Commit();
                    Intent n = new Intent(this, typeof(HomeActivity));
                    StartActivity(n);
                    Finish();
                    break;
            }
        }


        //private void btnEntrar_Click(object sender, EventArgs ea)
        //{


        //    if (!UsuarioValido(email, senha))
        //    {
        //        AlertBuilder.Build(this, "Login e/ou Senha inválidos.");
        //    }
        //    else
        //    {
        //        StartActivity(typeof(HomeActivity));
        //    }
        //}

        private void btnRegistrar_Click(object sender, EventArgs ea)
        {
            StartActivity(typeof(RegisterActivity));
        }

        //private bool UsuarioValido(string email, string senha)
        //{
        //    return UserRepository.Users.Any(x => x.Email.Equals(email) && x.Senha.Equals(senha));
        //}

        public void checkCredentials()
        {
            ISharedPreferences preferences = GetSharedPreferences(userSessionPref, FileCreationMode.Private);
            String email = preferences.GetString("email", "");
            Toast.MakeText(this, email, ToastLength.Short).Show();
            String pass = preferences.GetString("pass", "");
            if (!email.Equals("") && !pass.Equals(""))
            {
                Intent n = new Intent(this, typeof(HomeActivity));
                StartActivity(n);
                Finish();
            }

        }
    }
}