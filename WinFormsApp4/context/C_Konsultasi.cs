using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WinFormsApp4.Model;
using System.Windows.Forms;
using fitur_gejalaumum.view;

namespace WinFormsApp4.Controler
{
    public class C_Konsultasi
    {
        private readonly string connStr = "Host=localhost;Username=postgres;Database=data;port=5432;Password=1234";

        public bool ProsesKonsultasi(string nama, string umurText, string alergi, string kategori, string gejala,
            out string pesan, out M_Konsultasi konsultasi, out M_Obat obat)
        {
            pesan = "";
            konsultasi = null;
            obat = null;

            if (!int.TryParse(umurText, out int umur))
            {
                pesan = "Umur tidak valid.";
                return false;
            }
            var data = new M_Konsultasi
            {
                Nama = nama,
                Umur = umur,
                Gejala = gejala,
                Alergi = alergi,
                Kategori = kategori
            };

            if (!data.IsValid(out pesan))
                return false;

            try
            {
                using var conn = new NpgsqlConnection(connStr);
                conn.Open();

                string insert = @"INSERT INTO gejala (nama, umur, gejala, alergi, kategori)
                                  VALUES (@nama, @umur, @gejala, @alergi, @kategori)
                                  RETURNING no_antrian;";

                using var cmd = new NpgsqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@nama", data.Nama);
                cmd.Parameters.AddWithValue("@umur", data.Umur);
                cmd.Parameters.AddWithValue("@gejala", data.Gejala);
                cmd.Parameters.AddWithValue("@alergi", data.Alergi);
                cmd.Parameters.AddWithValue("@kategori", data.Kategori);

                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                data.GetType().GetProperty("Id")?.SetValue(data, newId);

                konsultasi = data;
                obat = CariObat(data);
                pesan = "Data berhasil disimpan dan obat ditemukan.";
                return true;
            }
            catch (Exception ex)
            {
                pesan = "Kesalahan database: " + ex.Message;
                return false;
            }
        }

        public bool SimpanData(M_Konsultasi data, out int id)
        {
            id = 0;
            if (!data.IsValid(out string pesan))
            {
                MessageBox.Show(pesan, "Validasi Gagal");
                return false;
            }

            try
            {
                using var conn = new NpgsqlConnection(connStr);
                conn.Open();
                string query = @"INSERT INTO gejala (nama, umur, gejala, alergi, kategori)
                         VALUES (@nama, @umur, @gejala, @alergi, @kategori)
                         RETURNING no_antrian;";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", data.Nama);
                cmd.Parameters.AddWithValue("@umur", data.Umur);
                cmd.Parameters.AddWithValue("@gejala", data.Gejala);
                cmd.Parameters.AddWithValue("@alergi", data.Alergi);
                cmd.Parameters.AddWithValue("@kategori", data.Kategori);

                id = Convert.ToInt32(cmd.ExecuteScalar());
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error");
                return false;
            }
        }

        public M_Obat CariObat(M_Konsultasi data)
        {
            try
            {
                using var conn = new NpgsqlConnection(connStr);
                conn.Open();

                string query = @"SELECT * FROM obat1 
                                 WHERE @umur BETWEEN umur_min AND umur_max 
                                 AND kategori ILIKE @kategori 
                                 AND gejala ILIKE @gejala 
                                 AND alergi ILIKE @alergi LIMIT 1";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@umur", data.Umur);
                cmd.Parameters.AddWithValue("@kategori", $"%{data.Kategori}%");
                cmd.Parameters.AddWithValue("@gejala", $"%{data.Gejala}%");
                cmd.Parameters.AddWithValue("@alergi", $"%{data.Alergi}%");

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
                MessageBox.Show("Gagal cari obat: " + ex.Message);
            }

            return null;
        }
    }
}

