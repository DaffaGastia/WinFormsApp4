//using masuk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using fitur_gejalaumum;
using WinFormsApp4.Model;
using fitur_gejalaumum.View;
using fitur_gejalaumum.view;
using ibu_hamilll.view;
//using CIHUYYY;

namespace WinFormsApp4
{
    public partial class Form2 : Form
    {
        string username;

        Database Mahasigma = new Database();
        public Form2(string username)
        {
            InitializeComponent();
            this.username = username;
            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = $"Selamat Datang {this.username}";

            label2.Text = Mahasigma.daftarMahasiswa[0].nama;
            //label3.Text = Mahasigma.daftarMahasiswa[0].nim;
            label4.Text = Mahasigma.daftarMahasiswa[1].nama;
            //label5.Text = Mahasigma.daftarMahasiswa[1].nim;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gejala gj = new gejala(this.username);
            this.Hide();
            gj.ShowDialog();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard(this.username);
            dashboard.ShowDialog();
            this.Show();
            this.Close();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ibu_Hamil_utama ib = new Ibu_Hamil_utama();
            this.Hide();
            ib.ShowDialog();
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
