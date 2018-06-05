using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SampleApp.Persistence;
using SampleApp.UWP.Persistence;
using SQLite;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb))]
namespace SampleApp.UWP.Persistence
{
    class SQLiteDb:ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentPath, "MySqlite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
