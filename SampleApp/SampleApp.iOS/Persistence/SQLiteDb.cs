using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SampleApp.iOS.Persistence;
using SampleApp.Persistence;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb))]
namespace SampleApp.iOS.Persistence
{
    class SQLiteDb:ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "MySqlite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}