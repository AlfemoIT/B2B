using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models.ViewModels
{
    public class UserViewModel
    {
        public string RegistrationNo { get; set; }
        public string NameSurname { get; set; }
        public string Password { get; set; }
        public string Eposta { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string CustomerName { get; set; }
        public string Captcha { get; set; }
    }
}