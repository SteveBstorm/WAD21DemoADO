using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woww.DAL.DTO;

namespace Woww.DAL.DAO
{
    public class TeamDAO
    {
        private const string _connectionString = @"Data Source=DESKTOP-RGPQP6I\TFTIC2019;Initial Catalog=WoWW;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
        private Team Convert (IDataRecord reader)
        {
            return new Team
            {
                Id = (int)reader["Id"],
                Name = reader["name"] is DBNull ? null : reader["name"].ToString(),
                Score = (int)reader["score"]
            };
        }

        public IEnumerable<Team> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Team";
                    connection.Open();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Convert(reader);
                        }
                    }

                    connection.Close();
                }
            }
        }

        public Team GetTeamById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Team WHERE Id = @id";

                    cmd.Parameters.AddWithValue("id", Id);

                    #region Exemple full parameter
                    //string request = "INSERT INTO Team OUTPUT inserted.Id AS 'newId' VALUES ('machin', 0)";

                    //SqlParameter p = new SqlParameter();
                    //p.ParameterName = "newId";
                    //p.Value = 0;
                    //p.Direction = ParameterDirection.Output; 
                    #endregion

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) return Convert(reader); 
                        return null;
                    }
                }
            }
        }

        public bool Create(Team team)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Team (name) VALUES (@name)";

                    cmd.Parameters.AddWithValue("@name", team.Name);

                    connection.Open();
                    return cmd.ExecuteNonQuery() == 1;
                    connection.Close();
                }
            }
        }
    }
}
