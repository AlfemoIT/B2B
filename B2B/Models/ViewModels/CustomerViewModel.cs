using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models.ViewModels
{
    public class CustomerViewModel
    {
        public String AreaTitle { get; set; }
        public string UserName { get; set; }
        public int RoleID { get; set; }
        public List<CustomerDto> Customers { get; set; }
        public List<UserSubMenu> UserSubMenus { get; set; }
    }
    public class CustomerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string SapCode { get; set; }
        public bool IsCentral { get; set; }
        public int RoleID { get; set; }
    }
    public class UserSubMenu
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}