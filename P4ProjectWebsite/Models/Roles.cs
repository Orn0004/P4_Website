using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Roles
{
    public class Roles
    {
        public const string AdminEndUser = "Admin";
        public const string SupplierEndUser = "Supplier";
        public const string ContributorEndUser = "Contributor";
    }

    public class UsersRole
    {
        public string Name { get; set; }
    }

}
