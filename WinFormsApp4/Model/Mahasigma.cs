using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsApp4.Model
{
    internal class Database 
    {
        public List<Mahasiswa> daftarMahasiswa = [new Mahasiswa("Ibu Hamil", ""), new Mahasiswa("Gejala Umum", "")];
    }
}
public class Mahasiswa
{
    public string nama, nim;
    public Mahasiswa(
        string nama, string nim)
    {
        this.nama = nama;
        this.nim = nim;
    }
}
