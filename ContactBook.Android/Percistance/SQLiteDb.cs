using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using ContactBook.Persistance;
using ContactBook.Droid.Percistance;

[assembly: Dependency(typeof(SQLiteDb))]

namespace ContactBook.Droid.Percistance
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "ContactBookDB.db");

            return new SQLiteAsyncConnection(path);
        }
    }
}

