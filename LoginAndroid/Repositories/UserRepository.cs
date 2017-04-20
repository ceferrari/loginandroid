using System;
using System.Collections.Generic;
using LoginAndroid.Models;
using SQLite;
using System.IO;

namespace LoginAndroid.Repositories
{
    public static class UserRepository
    {
        public static SQLiteConnection Db;

        static UserRepository()
        {
            var dbFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbName = "LoginAndroid.db";
            var dbPath = Path.Combine(dbFolder, dbName);
            Db = new SQLiteConnection(dbPath);
            if (Db.Table<User>() == null)
            {
                Db.CreateTable<User>();
            }
        }
    }
}