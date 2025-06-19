using fitur_gejalaumum.view;
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
using WinFormsApp4.Controler;
using WinFormsApp4.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fitur_gejalaumum.View
{
    public partial class farm11 : Form
    {
        private readonly C_Farm011 controller = new C_Farm011();
        private readonly M_Konsultasi Konsultasi;
        private readonly M_Obat Obat;
        private string username;

        public farm11(string username, M_Konsultasi konsultasi, M_Obat obat)

        {
            InitializeComponent();
            TampilkanDataPasienTerakhir();
            TampilkanHasilObat();
            Konsultasi = konsultasi;
            Obat = obat;
            this.username = username;
        }

        private void TampilkanDataPasienTerakhir()
        {
            DataTable table = controller.AmbilDataAkunTerakhirUntukTabel();

            if (table.Rows.Count > 0)
            {
                var kolomYangInginDihapus = new List<string>();
                foreach (DataColumn col in table.Columns)
                {
                    bool semuaNull = true;
                    foreach (DataRow row in table.Rows)
                    {
                        if (row[col] != DBNull.Value && !string.IsNullOrWhiteSpace(row[col].ToString()))
                        {
                            semuaNull = false;
                            break;
                        }
                    }

                    if (semuaNull)
                    {
                        kolomYangInginDihapus.Add(col.ColumnName);
                    }
                }

                foreach (string colName in kolomYangInginDihapus)
                {
                    table.Columns.Remove(colName);
                }

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

                if (table.Columns.Contains("no_antrian"))
                {
                    textBox1.Text = table.Rows[0]["no_antrian"].ToString();
                }
            }
        }
        private void TampilkanHasilObat()
        {

            if (Obat != null)
            {
                label1.Text = Obat.ObatKimia;
                label2.Text = Obat.ObatHerbal;
                label3.Text = Obat.Lifestyle;
            }
            else
            {
                label1.Text = "Tidak ditemukan";
                label2.Text = "-";
                label3.Text = "-";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox1.Text.Trim(), out int idParsed))
                {
                    MessageBox.Show("ID tidak valid.");
                    return;
                }

                var dataLanjutan = new M_Lanjutan
                {
                    Id = idParsed,
                    GejalaLanjutan = comboBox1.Text.Trim()
                };

                bool simpan = controller.UpdateGejalaLanjutan(dataLanjutan);

                if (simpan)
                {
                     MessageBox.Show("Data berhasil di simpan", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TampilkanDataPasienTerakhir();
                    var dataBaru = controller.AmbilKonsultasiById(idParsed);
                    var dataLanjutanLengkap = new M_Lanjutan
                    {
                        Id = dataBaru.Id,
                        Nama = dataBaru.Nama,
                        Umur = dataBaru.Umur,
                        Gejala = dataBaru.Gejala,
                        Alergi = dataBaru.Alergi,
                        Kategori = dataBaru.Kategori,
                        GejalaLanjutan = comboBox1.Text.Trim()
                    };
                    var obatBaru = controller.ObatL(dataLanjutanLengkap);

                    if (obatBaru != null)
                    {
                        label1.Text = obatBaru.ObatKimia;
                        label2.Text = obatBaru.ObatHerbal;
                        label3.Text = obatBaru.Lifestyle;
                    }
                    else
                    {
                        label1.Text = "Tidak ditemukan";
                        label2.Text = "-";
                        label3.Text = "-";
                    }
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan gejala lanjutan.");
                }
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan sistem: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void farm11_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gejala gj = new gejala(this.username);
            this.Hide();
            gj.ShowDialog();
            this.Close();
        }
    }
}


