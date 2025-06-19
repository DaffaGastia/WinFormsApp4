using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4.Model
{
    public class M_Konsultasi
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Umur { get; set; }
        public string Alergi { get; set; }
        public string Kategori { get; set; }
        public string Gejala { get; set; }

        public virtual bool IsValid(out string pesan)
        {
            if (string.IsNullOrWhiteSpace(Nama) ||
                string.IsNullOrWhiteSpace(Kategori) ||
                string.IsNullOrWhiteSpace(Gejala) ||
                string.IsNullOrWhiteSpace(Alergi) ||
                Umur <= 0)
            {
                pesan = "Data tidak lengkap atau umur tidak valid.";
                return false;
            }

            pesan = "Valid";
            return true;
        }
    }
}
