using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4.Model
{
    public class M_Lanjutan : M_Konsultasi
    {
        public int Id { get; set; }
        public string GejalaLanjutan { get; set; }

        public bool IsValid(out string pesan)
        {
            if (Id <= 0)
            {
                pesan = "ID tidak valid.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(GejalaLanjutan))
            {
                pesan = "Gejala lanjutan tidak boleh kosong.";
                return false;
            }

            pesan = "";
            return true;
        }
    }
}
