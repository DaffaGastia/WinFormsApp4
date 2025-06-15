using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WinFormsApp4.Model;

namespace WinFormsApp4
{
    public partial class Dashboard : Form
    {
        string username;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
    int nLeftRect,
    int nTopRect,
    int nRightRect,
    int nBottomRect,
    int nWidthEllipse,
    int nHeightEllipse
);




        public Dashboard(string username)
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 25, 25));
            this.username = username;
            this.Load += Dashboard_Load;
            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;
            btnHome.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label1.Text = $"{this.username}";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlNav.Height = button1.Height;
            pnlNav.Top = button1.Top;
            pnlNav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);

            MessageBox.Show(Tentang.GetInformasiAplikasi(), "Tentang Aplikasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;
            btnHome.BackColor = Color.FromArgb(46, 51, 73);

            this.Hide();
            Form2 home = new Form2(this.username);
            home.ShowDialog();
            this.Close();
        }

        private void btnHome_Leave(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlNav.Height = button4.Height;
            pnlNav.Top = button4.Top;
            pnlNav.Left = button4.Left;
            button4.BackColor = Color.FromArgb(46, 51, 73);

            LogOut.ShowLogoutMessageAndReturnToLogin(this, username);
        }

        private void button4_Leave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {

        }
    }
}
