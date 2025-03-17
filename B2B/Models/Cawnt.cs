using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

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
        public string ATWTB { get; set; } //tanim
    }
}