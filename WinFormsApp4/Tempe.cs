﻿using CIHUYYY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form2 : Form
    {
        string username;

        Database Mahasigma = new Database();
        public Form2()
        {
            InitializeComponent();
            this.username = username;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = $"Hala Madrid {this.username}!!";

            label2.Text = Mahasigma.daftarMahasiswa[0].nama;
            label3.Text = Mahasigma.daftarMahasiswa[0].nim;
            label4.Text = Mahasigma.daftarMahasiswa[1].nama;
            label5.Text = Mahasigma.daftarMahasiswa[1].nim;
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
    }
}
