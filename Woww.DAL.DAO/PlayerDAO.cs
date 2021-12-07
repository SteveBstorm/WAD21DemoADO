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
    public class PlayerDAO
    {
        private const string _connectionString = @"Data Source=DESKTOP-RGPQP6I\TFTIC2019;Initial Catalog=WoWW;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private Player Convert(IDataRecord reader)
        {
            return new Player
            {
                Id = (int)reader["Id"],
                Name = (string)reader["name"],
                Email = (string)reader["email"],
                FK_Team = (int)reader["FK_Team"]
            };
        }

        public bool Register(Player p)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Player (name, email, password, FK_Team) " +
                        "VALUES (@name, @email, @pwd, @fk)";

                    cmd.Parameters.AddWithValue("name", p.Name);
                    cmd.Parameters.AddWithValue("email", p.Email);
                    cmd.Parameters.AddWithValue("pwd", p.Password);
                    cmd.Parameters.AddWithValue("fk", p.FK_Team);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public Player Login(string email, string pwd)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Player WHERE email = @email AND password = @pwd";
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("pwd", pwd);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) return Convert(reader);
                        return null;
                    }
                }
            }
        }
    }
}
