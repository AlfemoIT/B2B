using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class User
    {
        public User()
        {
            CompanyAssignments = new List<CompanyAssignment>();
        }
        public int ID { get; set; }
        public int UserGroupID { get; set; }
        public int RoleID { get; set; }

        public string NameSurname { get; set; }
        public string Password { get; set; }
        public string Phone1 { get; set; }

        public virtual Role Role { get; set; }
        public virtual UserGroup UserGroup { get; set; }
        public ICollection<CompanyAssignment> CompanyAssignments { get; set; }
    }
}