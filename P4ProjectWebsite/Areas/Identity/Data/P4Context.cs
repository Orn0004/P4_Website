using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P4ProjectWebsite.Models;

namespace P4ProjectWebsite.Data
{
    public class P4Context : IdentityDbContext<IdentityUser>
    {
        public P4Context(DbContextOptions<P4Context> options)
            : base(options)                
        
        {
        }
        public DbSet<P4User> P4User { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}
    }
}
