using DreamLearning.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace DreamLearning.DAO
{
    public class Request
    {
        private static SQLiteConnection sqliteConnection;
        public Request() { }
        private static SQLiteConnection DbConnection(string path)
        {
            sqliteConnection = new SQLiteConnection(path);
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public void InsertAddress(Address address, string path)
        {
            try
            {
                using (var cmd = DbConnection(path).CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Address(Inep, Bairro, Cep, Logradouro) values (@Inep, @Bairro, @Cep, @Logradouro, @Numero)";
                    cmd.Parameters.AddWithValue("@Inep", address.Inep);
                    cmd.Parameters.AddWithValue("@Bairro", address.Bairro);
                    cmd.Parameters.AddWithValue("@Cep", address.Cep);
                    cmd.Parameters.AddWithValue("@Logradouro", address.Logradouro);
                    cmd.Parameters.AddWithValue("@Numero", address.Numero);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Address> AllAddresses(string path)
        {
            List<Address> addressess = new List<Address>();
            try
            {
                var command = DbConnection(path).CreateCommand();
                command.CommandText = "SELECT * FROM Address";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    addressess.Add(new Address
                    {
                        Inep = reader["Inep"].ToString(),
                        Logradouro = reader["Logradouro"].ToString(),
                        Numero = reader["Numero"].ToString(),
                        Cep = reader["Cep"].ToString(),
                        Bairro = reader["Bairro"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (addressess == null)
            {
                return null;
            }
            else
            {
                return addressess;
            }
        }

        public Address Address(string path, string Innep)
        {
            Address address = new Address();
            try
            {
                var command = DbConnection(path).CreateCommand();
                command.CommandText = "SELECT * FROM Address WHERE Inep like @Inep";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    address = (new Address
                    {
                        Inep = reader["Inep"].ToString(),
                        Logradouro = reader["Logradouro"].ToString(),
                        Numero = reader["Numero"].ToString(),
                        Cep = reader["Cep"].ToString(),
                        Bairro = reader["Bairro"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (address == null)
            {
                return null;
            }
            else
            {
                return address;
            }
        }


    }
}