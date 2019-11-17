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
        public List<GeolocationPoint> GeolocationPoints(string path)
        {
            List<GeolocationPoint> geolocations = new List<GeolocationPoint>();
            geolocations = geolocationDAO.AllGeolocations(path);

            if (geolocations == null)
            {
                throw new Exception("Não é foram encontrado os registros. ");
            }
            return geolocations;

        }

      public List<School> GetSchools(string path)
        {
            List<School> schools = new List<School>();
            schools = schoolDAO.AllSchools(path); 
            if(schools.Count() == 0)
            {
                throw new Exception("Não foram encontrados registros. ");
            }
            return schools; 
        }


        public List<Address> GetAddresses(string path)
        {
            List<Address> addresses = new List<Address>();
            addresses = addressDAO.AllAddresses(path);
            if (addresses.Count() == 0)
            {
                throw new Exception("Não foram encontrados registros. ");
            }
            return addresses;

        }

        // Create database. 

        public void CreateDatabase(string fullPath)
        {
          //  SQLiteConnection.CreateFile(fullPath);

        }


    }
}