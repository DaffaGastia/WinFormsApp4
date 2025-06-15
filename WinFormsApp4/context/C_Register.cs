using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WinFormsApp4.Model;

namespace WinFormsApp4.Controler
{
    public class C_Register
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Gun180106;Database=data";

        public bool UsernameExists(string username)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool RegisterUser(M_Register user)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO users (email, username, password) VALUES (@e, @u, @p)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("e", user.Email);
                    cmd.Parameters.AddWithValue("u", user.Username);
                    cmd.Parameters.AddWithValue("p", user.Password);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }
    }
}
