using ibu_hamilll.controller;
using ibu_hamilll.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ibu_hamilll.view
{
    public partial class Ibu_Hamil_utama : Form
    {
        public Ibu_Hamil_utama()
        {
            InitializeComponent();
        }

        private void Ibu_Hamil_utama_Load(object sender, EventArgs e)
        {
            string[] daftarKeluhan = {
                "mual",
                "pusing",
                "nyeri pinggang",
                "cepat lelah",
                "sakit kepala",
                "tidak nafsu makan"
            };

            comboBox1.Items.AddRange(daftarKeluhan);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text.Trim();
            string keluhan = comboBox1.Text.Trim();

            int umur;
            if (!int.TryParse(textBox2.Text.Trim(), out umur))
            {
                MessageBox.Show("Umur harus berupa angka.");
                return;
            }

            DateTime tanggalAwal = dateTimePicker1.Value;

            var controller = new CO_Konsultasi();
            string pesan;
            MO_Konsultasi hasilModel;

            bool berhasil = controller.ProsesKonsultasiKeluhan(nama, umur, tanggalAwal, keluhan, out pesan, out hasilModel);

            if (berhasil)
            {
                MessageBox.Show("✅ " + pesan, "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CO_Saran controllerSaran = new CO_Saran();
                MO_Saran saran = controllerSaran.CariSaran(hasilModel);

                Keluhan kel = new Keluhan(hasilModel, saran);
                this.Close();
                kel.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("❌ " + pesan, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
