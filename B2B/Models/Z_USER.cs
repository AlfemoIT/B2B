using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class Z_USER
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
        public string NameSurname { get; set; }
        public string Password { get; set; }
        public string Phone1 { get; set; }
        public string RegistrationNo { get; set; }
    }
}