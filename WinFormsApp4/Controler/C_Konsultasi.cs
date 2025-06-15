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
       
            private readonly string connectionString = "Host=localhost;Username=postgres;Database=coba coba;port=5432;Password=1234";

            public bool ProsesKonsultasi(string nama, string umurText, string alergi, string kategori, string gejala,
                                         out string pesan, out M_Konsultasi model, out M_Obat hasilObat)
            {
                model = null;
                hasilObat = null;

                // Validasi input
                if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(umurText) ||
                    string.IsNullOrWhiteSpace(alergi) || string.IsNullOrWhiteSpace(kategori) ||
                    string.IsNullOrWhiteSpace(gejala))
                {
                    pesan = "Semua kolom harus diisi.";
                    return false;
                }

                if (!int.TryParse(umurText, out int umur))
                {
                    pesan = "Umur harus berupa angka.";
                    return false;
                }

                model = new M_Konsultasi
                {
                    Nama = nama,
                    Umur = umur,
                    Kategori = kategori,
                    Gejala = gejala,
                    Alergi = alergi
                };

                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string insertQuery = "INSERT INTO akun(nama, umur, gejala, alergi, kategori) VALUES(@nama, @umur, @gejala, @alergi, @kategori)";
                        using (var cmd = new NpgsqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", nama);
                            cmd.Parameters.AddWithValue("@umur", umur);
                            cmd.Parameters.AddWithValue("@gejala", gejala);
                            cmd.Parameters.AddWithValue("@alergi", alergi);
                            cmd.Parameters.AddWithValue("@kategori", kategori);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Cari obat langsung di sini
                    hasilObat = CariObatLangsung(model);

                    if (hasilObat != null)
                    {
                        pesan = "Konsultasi berhasil dan obat ditemukan!";
                        return true;
                    }
                    else
                    {
                        pesan = "Konsultasi berhasil tapi obat tidak ditemukan.";
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    pesan = "Terjadi kesalahan saat proses konsultasi: " + ex.Message;
                    return false;
                }
            }

            private M_Obat CariObatLangsung(M_Konsultasi konsultasi)
            {
                M_Obat hasil = null;

                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"
                        SELECT *
                        FROM obat1
                        WHERE @umur BETWEEN umur_min AND umur_max
                        AND kategori ILIKE @kategori
                        AND gejala ILIKE @gejala
                        AND alergi ILIKE @alergi
                        LIMIT 1;";

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@umur", konsultasi.Umur);
                            cmd.Parameters.AddWithValue("@kategori", konsultasi.Kategori);
                            cmd.Parameters.AddWithValue("@gejala", $"%{konsultasi.Gejala}%");
                            cmd.Parameters.AddWithValue("@alergi", $"%{konsultasi.Alergi}%");

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
        
    }
}

