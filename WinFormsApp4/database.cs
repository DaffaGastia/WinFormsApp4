using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class database
    {
    }
}


//CREATE TABLE akun (
//    id SERIAL PRIMARY KEY,
//    nama CHARACTER VARYING(100),
//    umur INTEGER,
//    tanggal_kehamilan_awal DATE,
//    keluhan TEXT,
//    keluhan_lanjutan TEXT
//);

//CREATE TABLE users (
//    id SERIAL PRIMARY KEY,
//    email CHARACTER VARYING(100),
//    username CHARACTER VARYING(50),
//    password TEXT,
//    akun_id INTEGER REFERENCES akun(id)
//);

//CREATE TABLE obat (
//    id SERIAL PRIMARY KEY,
//    umur_min INTEGER,
//    umur_max INTEGER,
//    gejala CHARACTER VARYING(50),
//    kategori CHARACTER VARYING(50),
//    alergi CHARACTER VARYING(50),
//    gejala_lanjutan CHARACTER VARYING(50),
//    obat_kimia CHARACTER VARYING(100),
//    obat_herbal CHARACTER VARYING(100),
//    lifestyle CHARACTER VARYING(100),
//    kategori_lanjutan TEXT,
//    gejala_id INTEGER  -- foreign key diatur di tabel `gejala`
//);

//CREATE TABLE gejala (
//    no_antrian SERIAL PRIMARY KEY,
//    akun_id INTEGER REFERENCES akun(id),
//    nama CHARACTER VARYING(100),
//    umur INTEGER,
//    gejala TEXT,
//    alergi TEXT,
//    kategori CHARACTER VARYING(100),
//    gejala_lanjutan TEXT,
//    user_id INTEGER  -- mungkin relasi ke users, tergantung kebutuhan
//);

//CREATE TABLE saran (
//    id SERIAL PRIMARY KEY,
//    akun_id INTEGER REFERENCES akun(id),
//    umur INTEGER,
//    keluhan TEXT,
//    saran TEXT,
//    lifestyle TEXT
//);

//CREATE TABLE obat1 (
//    id SERIAL PRIMARY KEY,
//    umur_min INTEGER NOT NULL,
//    umur_max INTEGER NOT NULL,
//    gejala CHARACTER VARYING(50) NOT NULL,
//    kategori CHARACTER VARYING(50) NOT NULL,
//    alergi CHARACTER VARYING(50),
//    obat_kimia CHARACTER VARYING(100),
//    obat_herbal CHARACTER VARYING(100),
//    lifestyle CHARACTER VARYING(255)
//);

