using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class UserGroup
    {
        public UserGroup()
        {
            Users = new List<User>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}