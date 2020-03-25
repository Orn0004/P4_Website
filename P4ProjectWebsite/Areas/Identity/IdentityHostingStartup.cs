using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P4ProjectWebsite.Data;

[assembly: HostingStartup(typeof(P4ProjectWebsite.Areas.Identity.IdentityHostingStartup))]
namespace P4ProjectWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<P4Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("P4ContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<P4Context>();
            });
        }
    }
}