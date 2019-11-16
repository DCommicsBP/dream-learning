using DreamLearning.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace DreamLearning.DAO
{
    public class AddressDAO
    {
        private static SQLiteConnection sqliteConnection;
        public AddressDAO() { }
        private static SQLiteConnection DbConnection(string path)
        {
            string atualPath = "Data Source={relativePath}; Version=3;";

            sqliteConnection = new SQLiteConnection(atualPath.Replace("{relativePath}", path));
           
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public void InsertAddress(Address address, string path)
        {
            try
            {
                using (var cmd = DbConnection(path).CreateCommand())
                {
                    cmd.CommandText = " INSERT INTO Address(Inep, Bairro, Cep, Logradouro, Numero, Email) values (@Inep, @Bairro, @Cep, @Logradouro, @Numero, @Email)";
                    cmd.Parameters.AddWithValue("@Inep", address.Inep);
                    cmd.Parameters.AddWithValue("@Bairro", address.Bairro);
                    cmd.Parameters.AddWithValue("@Cep", address.Cep);
                    cmd.Parameters.AddWithValue("@Logradouro", address.Logradouro);
                    cmd.Parameters.AddWithValue("@Numero", address.Numero);
                    cmd.Parameters.AddWithValue("@Email", address.Email);
                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (Exception ex)
            {
            
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
                return null;
            else
                return addressess;
        }

        public Address AdAddress(string path, string Innep)
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
                return null;
            else
                return address;
        }


    }
}