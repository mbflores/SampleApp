using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SampleApp.Persistence
{
    public interface ISQLiteDb
    {
         SQLiteAsyncConnection GetConnection();
    }
}
