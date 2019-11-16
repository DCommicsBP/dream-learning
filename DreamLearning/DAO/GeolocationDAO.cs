using DreamLearning.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace DreamLearning.DAO
{
    public class GeolocationDAO
    {
        private static SQLiteConnection sqliteConnection;
        public GeolocationDAO() { }
        private static SQLiteConnection DbConnection(string path)
        {
            string atualPath = "Data Source={relativePath}; Version=3;";

            sqliteConnection = new SQLiteConnection(atualPath.Replace("{relativePath}", path));
           
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public void InsertGeolocation(GeolocationPoint geolocation, string path)
        {
            try
            {
                using (var cmd = DbConnection(path).CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO GeolocationPoint (Inep, Latitude, Longitude) values(@Inep, @Latitude, @Longitude)";
                    cmd.Parameters.AddWithValue("@Inep", geolocation.Inep);
                    cmd.Parameters.AddWithValue("@Longitude", geolocation.Longitude);
                    cmd.Parameters.AddWithValue("@Latitude", geolocation.Latitude);

                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close(); 
                    
                }
            }
            catch (Exception ex)
            {
               // throw new Exception("Não foi possível gravar o registro no banco: " + ex.Message);
            }   

        }
        public List<GeolocationPoint> AllGeolocations(string path)
        {
            List<GeolocationPoint> geolocationPoints= new List<GeolocationPoint>();
            try
            {
                var command = DbConnection(path).CreateCommand();
                command.CommandText = "SELECT * FROM GeolocationPoint";

                var reader = command.ExecuteReader();
                command.Connection.Close(); 

                while (reader.Read())
                {
                    geolocationPoints.Add(new GeolocationPoint
                    {
                        Inep = reader["Inep"].ToString(),
                        Latitude = reader["Latitude"].ToString(),
                        Longitude = reader["Longitude"].ToString()
                      
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (geolocationPoints == null)
                return null;
            else
                return geolocationPoints;
        }

        public GeolocationPoint Geolocation(string path, string Innep)
        {
            GeolocationPoint point = new GeolocationPoint();
            try
            {
                var command = DbConnection(path).CreateCommand();
                command.CommandText = "SELECT * FROM GeolocationPoint WHERE Inep like @Inep";

                var reader = command.ExecuteReader();
                command.Connection.Close(); 

                while (reader.Read())
                {
                    point = (new GeolocationPoint
                    {
                        Inep = reader["Inep"].ToString(),
                        Latitude = reader["Latitude"].ToString(),
                        Longitude = reader["Longitude"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (point == null)
                return null;
            else
                return point;
        }


    }
}