using DreamLearning.DAO;
using DreamLearning.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace DreamLearning.Service
{
    public class MainSqlService
    {

        private AddressDAO addressDAO = new AddressDAO();
        private SchoolDAO schoolDAO = new SchoolDAO();
        private GeolocationDAO geolocationDAO = new GeolocationDAO(); 

        // Inserts
        public void InsertAddress(Address address, string path)
        {
            if (string.IsNullOrEmpty(path))
                Console.WriteLine("Não foi possível gravar"); 
            else
                addressDAO.InsertAddress(address, path);
        }


        public void InsertGeolocation(GeolocationPoint geolocation, string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new Exception("Não é possível gravar sem o caminho esperado do banco.");
            else
                geolocationDAO.InsertGeolocation(geolocation, path);

        }

        public void InsertSchool(School school, string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new Exception("Não é possível gravar sem o caminho esperado do banco.");
            else
                schoolDAO.InsertSchool(school, path);

        }

        // Lists



         // Create database. 

        public void CreateDatabase(string fullPath)
        {
          //  SQLiteConnection.CreateFile(fullPath);

        }


    }
}