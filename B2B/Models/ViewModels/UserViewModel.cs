using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public string SelectedRole { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string SelectedCustomer { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public string SelectedUserGroup { get; set; }
        public List<SelectListItem> UserGroups { get; set; }
        public string SelectedPage { get; set; }
        public List<SelectListItem> Pages { get; set; }
    }
}