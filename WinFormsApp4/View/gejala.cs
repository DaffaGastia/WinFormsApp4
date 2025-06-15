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
                string nama = textBox2.Text;
                string umurText = textBox1.Text;
                string kategori = comboBox3.Text;
                string gejala = comboBox1.Text;
                string alergi = comboBox2.Text;

                if (string.IsNullOrWhiteSpace(nama) ||
                    string.IsNullOrWhiteSpace(umurText) ||
                    string.IsNullOrWhiteSpace(kategori) ||
                    string.IsNullOrWhiteSpace(gejala) ||
                    string.IsNullOrWhiteSpace(alergi))
                {
                    MessageBox.Show("Semua data harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(umurText, out int umur))
                {
                    MessageBox.Show("Umur harus berupa angka!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var controller = new C_Konsultasi();
                string pesan;
                M_Konsultasi model;
                M_Obat obat;

                bool berhasil = controller.ProsesKonsultasi(nama, umurText, alergi, kategori, gejala, out pesan, out model, out obat);

                if (berhasil)
                { 
                    MessageBox.Show(pesan, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    farm11 farm = new farm11(this.username,model, obat);
                    this.Hide();
                    farm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(pesan, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
