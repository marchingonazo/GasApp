using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GasApp.Models
{
    public class DbGasApp
    {
        readonly SQLiteAsyncConnection conn;

        public DbGasApp(string dbpath)
        {
            conn = new SQLiteAsyncConnection(dbpath);

        }
    }
}
