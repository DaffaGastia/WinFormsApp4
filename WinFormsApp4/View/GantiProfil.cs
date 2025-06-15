//using Microsoft.VisualBasic.ApplicationServices;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using WinFormsApp4.Controler;
//using WinFormsApp4.Model;

//namespace WinFormsApp4
//{
//    public partial class GantiProfil : Form
//    {
//        public GantiProfil()
//        {
//            InitializeComponent();
//        }

        

//        private void textBox1_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            string newUsername = textBoxUsername.Text.Trim();
//            string oldPassword = textBoxOldPass.Text.Trim();
//            string newPassword = textBoxNewPass.Text.Trim();
//            string confirmPassword = textBoxConfirmPass.Text.Trim();

//            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(oldPassword) ||
//                string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
//            {
//                MessageBox.Show("Semua field harus diisi.", "Peringatan");
//                return;
//            }

//            if (newPassword != confirmPassword)
//            {
//                MessageBox.Show("Password baru dan konfirmasi tidak cocok.", "Peringatan");
//                return;
//            }

//            var controller = new C_User();
//            if (!controller.CheckPasswordValid(M_User1.Id, oldPassword))
//            {
//                MessageBox.Show("Password lama salah.", "Error");
//                return;
//            }

//            bool usernameUpdated = controller.UpdateUsername(M_User1.Id, newUsername);
//            bool passwordUpdated = controller.UpdatePassword(M_User1.Id, newPassword);

//            if (usernameUpdated && passwordUpdated)
//            {
//                MessageBox.Show("Username dan Password berhasil diubah.", "Sukses");
//                this.Close();
//            }
//            else if (usernameUpdated)
//            {
//                MessageBox.Show("Username berhasil diubah. Tapi gagal mengubah password.", "Info");
//            }
//            else if (passwordUpdated)
//            {
//                MessageBox.Show("Password berhasil diubah. Tapi gagal mengubah username.", "Info");
//            }
//            else
//            {
//                MessageBox.Show("Gagal mengubah data.", "Error");
//            }
//        }
//    }
//}
