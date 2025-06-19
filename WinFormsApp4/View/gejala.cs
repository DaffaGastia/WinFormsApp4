using fitur_gejalaumum;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp4.Controler;
using WinFormsApp4.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using fitur_gejalaumum.View;
using WinFormsApp4;

namespace fitur_gejalaumum.view
{
    public partial class gejala : Form
    {
        private string username;
        public gejala(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        { 

        }

        private void button1_Click(object sender, EventArgs e)
        {
try
            {
                string nama = textBox2.Text.Trim();
                string umurText = textBox1.Text.Trim();
                string kategori = comboBox3.Text.Trim();
                string gejala = comboBox1.Text.Trim();
                string alergi = comboBox2.Text.Trim();

                if (string.IsNullOrWhiteSpace(nama) ||
                    string.IsNullOrWhiteSpace(umurText) ||
                    string.IsNullOrWhiteSpace(kategori) ||
                    string.IsNullOrWhiteSpace(gejala) ||
                    string.IsNullOrWhiteSpace(alergi))
                {
                    MessageBox.Show("Semua data harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(umurText, out int umur) || umur <= 0)
                {
                    MessageBox.Show("Umur harus berupa angka dan lebih dari 0!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string pesan;
                var controller = new C_Konsultasi();
                M_Konsultasi modelKonsultasi = new M_Konsultasi
                {
                    Nama = nama,
                    Umur = int.Parse(umurText),
                    Kategori = kategori,
                    Gejala = gejala,
                    Alergi = alergi
                };

                M_Obat modelObat;
                int idPasien;

                bool hasilSimpan = controller.SimpanData(modelKonsultasi, out idPasien);

                if (hasilSimpan)
                {
                    MessageBox.Show("Data berhasil di simpan", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modelKonsultasi.Id = idPasien;
                    modelObat = controller.CariObat(modelKonsultasi);

                    var formHasil = new farm11(this.username, modelKonsultasi, modelObat);
                    this.Hide();
                    formHasil.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gagal memproses data: ", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 home = new Form2(this.username);
            this.Hide();
            home.ShowDialog();
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
