using System;
using System.Collections.Generic;
using System.Text;

namespace P4_Data.Entities
{
    public class RolesEntityUpdate
    {
        public IEnumerable<UsersEntity> Users { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public string UserEmail { get; set; }
        public string Role { get; set; }
        public bool Delete { get; set; }
    }
}
