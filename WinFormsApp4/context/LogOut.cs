using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WinFormsApp4
{
    internal class LogOut
    {
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
