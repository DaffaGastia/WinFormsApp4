using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp4.Model;
using fitur_gejalaumum.view;
using Npgsql;

namespace WinFormsApp4.Controler
{
    public class C_Farm011 : IKonsultasiService<M_Lanjutan>
    {
        private readonly string connStr = "Host=localhost;Username=postgres;Database=data;port=5432;Password=1234";

        public bool UpdateGejalaLanjutan(M_Lanjutan data)
        {
            if (data.Id <= 0)
            {
                MessageBox.Show("ID tidak valid.", "Validasi Gagal");
                return false;
            }
            if (string.IsNullOrWhiteSpace(data.GejalaLanjutan))
            {
                MessageBox.Show("Gejala lanjutan tidak boleh kosong.", "Validasi Gagal");
                return false;
            }
           
            try
            {
                using var conn = new NpgsqlConnection(connStr);
                conn.Open();
                using var cmd = new NpgsqlCommand("UPDATE gejala SET gejala_lanjutan = @gejala WHERE no_antrian = @id", conn);
                cmd.Parameters.AddWithValue("@gejala", data.GejalaLanjutan);
                cmd.Parameters.AddWithValue("@id", data.Id);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update gejala lanjutan: " + ex.Message);
                return false;
            }
        }
        public DataTable AmbilDataAkunTerakhirUntukTabel()
        {
            DataTable dt = new DataTable();

            try
            {
                using var conn = new NpgsqlConnection(connStr);
                conn.Open();
                string query = "SELECT * FROM gejala ORDER BY no_antrian DESC LIMIT 1";
                using var da = new NpgsqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal ambil data pasien terakhir: " + ex.Message);
            }

            return dt;
        }
        public M_Konsultasi AmbilKonsultasiById(int id)
        {
            try
            {
                using var conn = new NpgsqlConnection(connStr);
                conn.Open();

                using var cmd = new NpgsqlCommand("SELECT * FROM gejala WHERE no_antrian = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new M_Konsultasi
                    {
                        Id = id,
                        Nama = reader["nama"].ToString(),
                        Umur = Convert.ToInt32(reader["umur"]),
                        Gejala = reader["gejala"].ToString(),
                        Alergi = reader["alergi"].ToString(),
                        Kategori = reader["kategori"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal ambil data: " + ex.Message);
            }

            return null;
        }

        public M_Obat ObatL(M_Lanjutan data)
        {
            try
            {
                using var conn = new NpgsqlConnection(connStr);
                conn.Open();

                string query = @"SELECT * FROM obat 
                         WHERE @umur BETWEEN umur_min AND umur_max 
                         AND kategori ILIKE @kategori 
                         AND gejala ILIKE @gejala 
                         AND alergi ILIKE @alergi 
                         AND gejala_lanjutan ILIKE @gejala_lanjutan
                         LIMIT 1";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@umur", data.Umur);
                cmd.Parameters.AddWithValue("@kategori", $"%{data.Kategori}%");
                cmd.Parameters.AddWithValue("@gejala", $"%{data.Gejala}%");
                cmd.Parameters.AddWithValue("@alergi", $"%{data.Alergi}%");
                cmd.Parameters.AddWithValue("@gejala_lanjutan", $"%{data.GejalaLanjutan}%");

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new M_Obat
                    {
                        ObatKimia = reader["obat_kimia"].ToString(),
                        ObatHerbal = reader["obat_herbal"].ToString(),
                        Lifestyle = reader["lifestyle"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal cari obat lanjutan: " + ex.Message);
            }
            return null;
        }
    }

}




