using ibu_hamilll.controller;
using ibu_hamilll.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ibu_hamilll.controller.CO_Saran;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ibu_hamilll.view
{
    public partial class Keluhan : Form
    {
        private readonly CO_Konsultasi controllerKonsultasi = new CO_Konsultasi();
        private readonly CO_Saran controllerSaran = new CO_Saran();
        private readonly MO_Konsultasi _konsultasi;
        private readonly MO_Saran _saran;
        private int _idTerakhir;

        public Keluhan(MO_Konsultasi konsultasi, MO_Saran saran)
        {
            InitializeComponent();
            _konsultasi = konsultasi;
            _saran = saran;
        }

         private void Keluhan_Load(object sender, EventArgs e)
        {
            TampilkanDataPasienTerakhir();
            TampilkanHasilSaran();
        }

        private void TampilkanDataPasienTerakhir()
        {
            DataTable table = controllerSaran.AmbilDataAkunTerakhir();

            if (table.Rows.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = table;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.AllowUserToResizeRows = false;
                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.BackgroundColor = this.BackColor;
                dataGridView1.Width = 900;
                dataGridView1.Height = 100;
                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);

                // Ambil ID terakhir
                _idTerakhir = Convert.ToInt32(table.Rows[0]["id"]);

                // Optional: tampilkan id di textbox
                textBox1.Text = _idTerakhir.ToString();
            }
        }
        private void TampilkanHasilSaran()
        {
            if (_saran != null)
            {
                label1.Text = _saran.Saran;
                label2.Text = _saran.Lifestyle;
            }
            else
            {
                label1.Text = "Tidak ada saran";
                label2.Text = "-";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }    

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var lanjutan = new MO_Lanjutan
                {
                    id = _idTerakhir,
                    KeluhanLanjutan = comboBox1.Text.Trim()
                };

                var controller = new C_Lanjutan();
                bool berhasil = controller.UpdateKeluhanLanjutan(lanjutan);

                if (berhasil)
                {
                    MessageBox.Show("Keluhan lanjutan berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var dataPasien = controller.AmbilDataPasienById(_idTerakhir);
                    if (dataPasien != null)
                    {
                        var konsultasiBaru = new MO_Konsultasi
                        {
                            Umur = Convert.ToInt32(dataPasien["umur"]),
                            Keluhan = dataPasien["keluhan_lanjutan"].ToString()
                        };

                        var saranBaru = new CO_Saran().CariSaran(konsultasiBaru);
                        if (saranBaru != null)
                        {
                            label1.Text = saranBaru.Saran;
                            label2.Text = saranBaru.Lifestyle;
                        }
                        else
                        {
                            label1.Text = "Tidak ada saran";
                            label2.Text = "-";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan keluhan lanjutan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}




