﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CIHUYYY;

namespace masuk
{
    internal class Database 
    {
        public List<Mahasiswa> daftarMahasiswa = [new Mahasiswa("Ibu Hamil", "3051"), new Mahasiswa("Gejala Umum", "5130")];
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
