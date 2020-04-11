using System;
using System.Collections.Generic;
using System.Text;

namespace P4_Data.Entities
{
    public class UsersEntity
    {
        public string Email { get; set; }
        public IEnumerable<UsersRole> Roles { get; set; }
    }
}
