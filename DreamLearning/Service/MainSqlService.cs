using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace DreamLearning.Service
{
    public class MainSqlService
    {

        public void InsertAddress()
        {
            _ = SQLiteConnection.ConnectionPool;


        }


        public void InsertGeolocation()
        {

        }

        public void CreateDatabase(string fullPath)
        {
            SQLiteConnection.CreateFile(fullPath);

        }


    }
}