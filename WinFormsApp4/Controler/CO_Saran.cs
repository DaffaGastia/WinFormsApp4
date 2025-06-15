using ibu_hamilll.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace ibu_hamilll.controller
{
    class CO_Saran
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Database=coba coba;port=5432;Password=Gun180106";
        public MO_Saran CariSaran(MO_Konsultasi konsultasi)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT sarann, Lifestylee FROM saran WHERE umur = @umur AND keluhan ILIKE @keluhan", conn))
                {
                    cmd.Parameters.AddWithValue("umur", konsultasi.Umur);
                    cmd.Parameters.AddWithValue("keluhan", konsultasi.Keluhan);

                    using (NpgsqlDataReader data = cmd.ExecuteReader())
                    {
                        if (data.Read())
                        {
                            return new MO_Saran(
                                data["Sarann"].ToString(),
                                data["Lifestylee"].ToString()
                            );
                        }
                    }
                    conn.Close();
                    return null;
                }
            }
        }

        public DataTable AmbilDataAkunTerakhir()
        {
            DataTable dataTable = new DataTable();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, nama, umur, keluhan, tanggal_kehamilan_awal, keluhan_lanjutan FROM akun ORDER BY id DESC LIMIT 1";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
    }
}
