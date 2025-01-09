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
            MagazaMuduru = 1,
            SatisDanismani = 2,
            Yatirimci = 3,
            SatisIsGelistirmeDirektoru = 4,
            TurkiyeSatisMuduru = 5,
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
    }
}