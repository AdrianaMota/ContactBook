using System;
using SQLite;
using ContactBook.Persistance;
using Xamarin.Forms;
using ContactBook.iOS.Persistance;
using System.IO;

[assembly: Dependency(typeof(SQLiteDb))]

namespace ContactBook.iOS.Persistance
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

