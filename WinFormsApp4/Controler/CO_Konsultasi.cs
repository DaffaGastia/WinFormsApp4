using ibu_hamilll.model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibu_hamilll.controller
{
    class CO_Konsultasi
    {
        private readonly string _connStr = "Host=localhost;Username=postgres;Database=coba coba;port=5432;Password=Gun180106";

        public bool ProsesKonsultasiKeluhan(string nama, int umur, DateTime tanggalKehamilanAwal, string keluhan,
                                            out string pesan, out MO_Konsultasi model)
        {
            model = null;

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(keluhan))
            {
                pesan = "Semua kolom wajib diisi.";
                return false;
            }

            model = new MO_Konsultasi
            {
                Nama = nama,
                Umur = umur,
                Keluhan = keluhan,
                TanggalKehamilanAwal = tanggalKehamilanAwal
            };

            try
            {
                using (var conn = new NpgsqlConnection(_connStr))
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(
                        "INSERT INTO akun (nama, umur, tanggal_kehamilan_awal, keluhan) " +
                        "VALUES (@nama, @umur, @tanggal_kehamilan_awal, @keluhan)", conn);

                    cmd.Parameters.AddWithValue("nama", nama);
                    cmd.Parameters.AddWithValue("umur", umur);
                    cmd.Parameters.AddWithValue("tanggal_kehamilan_awal", tanggalKehamilanAwal.Date);
                    cmd.Parameters.AddWithValue("keluhan", keluhan);
                    cmd.ExecuteNonQuery();
                }

                pesan = "Data berhasil disimpan.";
                return true;
            }
            catch (Exception ex)
            {
                pesan = "Terjadi kesalahan saat menyimpan data: " + ex.Message;
                return false;
            }
        }
    }

}



