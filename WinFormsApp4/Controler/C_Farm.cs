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
    public class C_Farm011
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Database=data;port=5432;Password=Gun180106";
        public M_Obat CariObat(M_Konsultasi konsultasi)
        {
            M_Obat hasil = null;

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT * FROM obat1 where @umur between umur_min and umur_max and kategori ilike @kategori and alergi ilike @alergi and gejala ilike @gejala", conn))
                    { 
                        cmd.Parameters.AddWithValue("@umur", konsultasi.Umur);
                        cmd.Parameters.AddWithValue("@kategori", konsultasi.Kategori);
                        cmd.Parameters.AddWithValue("@gejala", konsultasi.Gejala);
                        cmd.Parameters.AddWithValue("@alergi", konsultasi.Alergi);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hasil = new M_Obat
                                {
                                    ObatKimia = reader["obat_kimia"].ToString(),
                                    ObatHerbal = reader["obat_herbal"].ToString(),
                                    Lifestyle = reader["lifestyle"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari obat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return hasil;

        }

        public M_Obat ObatL(M_Lanjutan konsultasi)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM obat where @umur between umur_min and umur_max and kategori ilike @kategori and alergi ilike @alergi and gejala ilike @gejala and gejala_lanjutan ilike @gejala_lanjutan", conn))
                {
                    cmd.Parameters.AddWithValue("@umur", konsultasi.Umur);
                    cmd.Parameters.AddWithValue("@kategori", konsultasi.Kategori);
                    cmd.Parameters.AddWithValue("@alergi", konsultasi.Alergi);
                    cmd.Parameters.AddWithValue("@gejala", konsultasi.Gejala);
                    cmd.Parameters.AddWithValue("@Gejala_lanjutan", konsultasi.GejalaLanjutan);

                    using (var reader = cmd.ExecuteReader())
                    {
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
                }
            }
            return null;
        }

        public DataRow AmbilDataAkunTerakhir()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT no_antrian, nama, umur, gejala, kategori, alergi, gejala_lanjutan FROM gejala ORDER BY no_antrian DESC LIMIT 1", conn))
                {
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    
        public bool UpdateGejalaLanjutan(M_Lanjutan data)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cekCmd = new NpgsqlCommand("SELECT COUNT(*) FROM gejala WHERE no_antrian = @id", conn))
                {
                    cekCmd.Parameters.AddWithValue("id", data.Id);
                    int count = Convert.ToInt32(cekCmd.ExecuteScalar());
                    if (count == 0) return false;
                }
                using (var updateCmd = new NpgsqlCommand("UPDATE gejala SET gejala_lanjutan = @gejala WHERE no_antrian = @id", conn))
                {
                    updateCmd.Parameters.AddWithValue("gejala", data.GejalaLanjutan);
                    updateCmd.Parameters.AddWithValue("id", data.Id);
                    int result = updateCmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        public DataTable AmbilDataAkunTerakhirUntukTabel()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT no_antrian, nama, umur, gejala, kategori, alergi, gejala_lanjutan FROM gejala ORDER BY no_antrian DESC LIMIT 1", conn))
                {
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            if (dt.Rows.Count > 0)
            {
                string gejalaLanjutan = dt.Rows[0]["gejala_lanjutan"]?.ToString();
                if (string.IsNullOrWhiteSpace(gejalaLanjutan))
                {
                    dt.Columns.Remove("gejala_lanjutan");
                }
            }

            return dt;
        }

       
        public DataRow AmbilDataPasienById(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM gejala WHERE no_antrian = @id", conn))
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
       
        public M_Lanjutan AmbilKonsultasiById(int id)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT umur, kategori, alergi, gejala, gejala_lanjutan
                         FROM gejala
                         WHERE no_antrian = @id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new M_Lanjutan
                            {
                                Umur = Convert.ToInt32(reader["umur"]),
                                Kategori = reader["kategori"].ToString(),
                                Alergi = reader["alergi"].ToString(),
                                Gejala = reader["gejala"].ToString(),
                                GejalaLanjutan = reader["gejala_lanjutan"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
    
}




