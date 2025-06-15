using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WinFormsApp4
{
    internal class LogOut
    {
        //public static void ShowLogoutMessage(string username)
        //{
        //    DialogResult result = MessageBox.Show(
        //        $"Terima kasih, {username}.\nSemoga lekas pulih! 😊",
        //        "Konfirmasi Logout",
        //        MessageBoxButtons.OKCancel,
        //        MessageBoxIcon.Information
        //    );

        //    if (result == DialogResult.OK)
        //    {
        //        Application.Exit(); 
        //    }
        //}

        public static void ShowLogoutMessageAndReturnToLogin(Form currentForm, string username)
        {
            DialogResult result = MessageBox.Show(
                $"Terima kasih, {username}.\nIngin kembali ke halaman login?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                currentForm.Close(); 
            }
            else if (result == DialogResult.No)
            {
                Application.Exit();
            }
        }
    }
    
}
