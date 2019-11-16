using DreamLearning.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace DreamLearning.DAO
{
    public class SchoolDAO
    {
        private static SQLiteConnection sqliteConnection;
        public SchoolDAO() { }
        private static SQLiteConnection DbConnection(string path)
        {
            string atualPath = "Data Source={relativePath}; Version=3;";

            sqliteConnection = new SQLiteConnection(atualPath.Replace("{relativePath}", path));
           
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public void InsertSchool(School school, string path)
        {
            try
            {
                using (var cmd = DbConnection(path).CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO School(Inep, AbreviacaoNome, Nome, Telefone, Tipo) values (@Inep, @AbreviacaoNome, @Nome, @Telefone, @Tipo)";
                    cmd.Parameters.AddWithValue("@Inep", school.Inep);
                    cmd.Parameters.AddWithValue("@AbreviacaoNome", school.AbreviacaoNome);
                    cmd.Parameters.AddWithValue("@Nome", school.Nome);
                    cmd.Parameters.AddWithValue("@Telefone", school.Telefone);
                    cmd.Parameters.AddWithValue("@Tipo", school.Tipo);
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close(); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível gravar o registro no banco: " + ex.Message); 
            }

        }
        public List<School> AllSchools(string path)
        {
            List<School> schools= new List<School>();
            try
            {
                var command = DbConnection(path).CreateCommand();
                command.CommandText = "SELECT * FROM School";
                command.Connection.Close();
                
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    schools.Add(new School
                    {
                        Inep = reader["Inep"].ToString(),
                        AbreviacaoNome = reader["AbreviacaoNome"].ToString(),
                        Nome= reader["Nome"].ToString(),
                        Telefone = reader["Telefone"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível ler os registros no banco: " + ex.Message);
            }
            if (schools == null)
                return null;
            else
                return schools;
        }

        public School School(string path, string Innep)
        {
            School school = new School();
            try
            {
                var command = DbConnection(path).CreateCommand();
                command.CommandText = "SELECT * FROM School WHERE Inep like @Inep";

                var reader = command.ExecuteReader();
                command.Connection.Close();
                
                while (reader.Read())
                {
                    school = (new School
                    {
                        Inep = reader["Inep"].ToString(),
                        AbreviacaoNome = reader["AbreviacaoNome"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        Telefone = reader["Telefone"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex; throw new Exception("Não foi possível ler o registro no banco: " + ex.Message);
            }

            if (school == null)
                return null;
            else
                return school;
        }


    }
}