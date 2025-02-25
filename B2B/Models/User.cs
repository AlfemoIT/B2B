using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web;

namespace B2B.Models
{
    public class User
    {
        public User()
        {
            CustomerAssignment = new List<CustomerAssignment>();
            PageAssignment = new List<PageAssignment>();
        }
        public int ID { get; set; }
        public int UserGroupID { get; set; }
        public int RoleID { get; set; }
        public int? SalesOfficeID { get; set; }    //sorumlu oldugu bolge
        public string RegistrationNo { get; set; } //sicil no
        public string NameSurname { get; set; }
        public string Password { get; set; }
        public string Phone1 { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public virtual Role Role { get; set; }

        [JsonIgnore]
        public virtual UserGroup UserGroup { get; set; }

        [JsonIgnore]
        public ICollection<CustomerAssignment> CustomerAssignment { get; set; }

        [JsonIgnore]
        public ICollection<PageAssignment> PageAssignment { get; set; }

        [JsonIgnore]
        public virtual SalesOffice SalesOffice { get; set; }
    }
}