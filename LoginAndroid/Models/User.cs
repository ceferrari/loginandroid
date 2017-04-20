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

namespace LoginAndroid.Models
{
    public class User
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public User()
        {
            
        }

        public User(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}