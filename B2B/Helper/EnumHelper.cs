using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Helper
{
    public static class EnumHelper
    {
        public enum Role
        {
            TurkiyeSatisMuduru = 1,
            Yatirimci = 2,
            MagazaMuduru = 3,
            SatisDanismani = 4,
            SatisIsGelistirmeDirektoru = 5,
            BolgeMuduru = 6,
            PerakendelerMuduru = 7,
            TurkiyeSatisRaporlamaUzmanı = 8,
            TicariMuhasebeYonetmeni = 9,
            SatisDestekDepartmani = 10,
            BilgiİslemDepartmani = 11,
            TeknikServis = 12,
            MusteriHizmetleri = 13,
            TaseronTeknikServis = 14,
            Pazarlama = 15
        }
        public enum UserGroup
        {
            Bayi = 1,
            Perakende = 2,
            PowerUser = 3,
            TeknikServisKullanici = 4,
            Pazarlama = 5,
            Admin = 6
        }
        public enum SalesOffice
        {
            IstAvrupa = 10,
            IstAnadolu = 20,
            Ege = 30,
            IcAnadolu = 40,
            Karadeniz = 50,
            Güneydogu = 60,
            PerakendeMagaza = 70,
            Marmara = 80
        }
    }
}