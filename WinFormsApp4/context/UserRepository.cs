using Npgsql;
using System;
using System.Windows.Forms;

namespace WinFormsApp4.Controler
{
    public class UserRepository
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=daffa21122005;Database=coba;Port=5432";

        public bool UpdateUsername(int userId, string usernameBaru)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE users SET username = @username WHERE user_id = @userId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", usernameBaru);
                        cmd.Parameters.AddWithValue("@userId", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Gagal: " + ex.Message);
                return false;
            }
        }

        public bool UsernameExists(string username)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cek Username Gagal: " + ex.Message);
                return false;
            }
        }
    }
}
