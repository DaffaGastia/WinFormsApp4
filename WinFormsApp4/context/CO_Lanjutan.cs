using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ibu_hamilll.model;
using Npgsql;
using System.Data;
namespace ibu_hamilll.controller
{ 
    public class C_Lanjutan
    {
        private readonly string _connStr = "Host=localhost;Username=postgres;Database=data;port=5432;Password=Gun180106";

        public bool UpdateKeluhanLanjutan(MO_Lanjutan data)
        {
            using (var conn = new NpgsqlConnection(_connStr))
            {
                conn.Open();

                using (var cekCmd = new NpgsqlCommand("SELECT COUNT(*) FROM akun WHERE id = @id", conn))
                {
                    cekCmd.Parameters.AddWithValue("id", data.id);
                    int count = Convert.ToInt32(cekCmd.ExecuteScalar());
                    if (count == 0) return false;
                }

                using (var updateCmd = new NpgsqlCommand("UPDATE akun SET keluhan_lanjutan = @keluhan WHERE id = @id", conn))
                {
                    updateCmd.Parameters.AddWithValue("keluhan", data.KeluhanLanjutan);
                    updateCmd.Parameters.AddWithValue("id", data.id);
                    int result = updateCmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        public DataRow AmbilDataPasienById(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connStr))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM akun WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                    }
                }
            }
        }

        public int AmbilIdPasienTerakhir()
        {
            using (var conn = new NpgsqlConnection(_connStr))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id FROM akun ORDER BY id DESC LIMIT 1", conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
    }
}
