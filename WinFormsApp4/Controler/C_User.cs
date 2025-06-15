using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WinFormsApp4.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp4.Controler
{
    public class C_User
    {
        public M_User GetUserByUsername(string username)
        {
            M_User user = null;
            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=1234;Database=well"))
            {
                conn.Open();
                string query = "SELECT user_id, username FROM users WHERE username = @username";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new M_User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return user;
        }

        public bool AuthLogin(string username, string password)
        {
            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=1234;Database=well"))
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE username = @username AND password = @password";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }

        public bool UpdateUsername(int userId, string newUsername)
        {
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Password = 1234; Database = wel"))
            {
                conn.Open();
                string query = "UPDATE users SET username = @username WHERE user_id = @user_id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", newUsername);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdatePassword(int userId, string newPassword)
        {
            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=1234;Database=wel"))
            {
                conn.Open();
                string query = "UPDATE users SET password = @password WHERE user_id = @user_id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool CheckPasswordValid(int userId, string oldPassword)
        {
            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=1234;Database=wel"))
            {
                conn.Open();
                string query = "SELECT password FROM users WHERE user_id = @user_id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    var result = cmd.ExecuteScalar();
                    return result != null && result.ToString() == oldPassword;
                }
            }
        }
    }
}
