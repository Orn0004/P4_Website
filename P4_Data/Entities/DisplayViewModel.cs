using System;
using System.Collections.Generic;
using System.Text;

namespace P4_Data.Entities
{
    public class DisplayViewModel
    {
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<UsersEntity> Users { get; set; }
    }
}