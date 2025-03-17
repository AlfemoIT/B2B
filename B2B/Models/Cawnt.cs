using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    /// <summary>
    /// ausp value
    /// </summary>
    public class Cawnt
    {
        public int ID { get; set; }
        public string ATINN { get; set; }  //karekteristik (Z_KULLANIMDURUM)
        public int ATZHL { get; set; }    //sayac
        public string SPRAS { get; set; }
        public string ADZHL { get; set; }
        public string ATWTB { get; set; } //tanim
        public string DATUV { get; set; }
        public string TECHV { get; set; }
        public string AENNR { get; set; }
        public string LKENZ { get; set; }
        public string DATUB { get; set; }
    }
}