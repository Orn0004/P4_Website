using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4ProjectWebsite.Models;
using P4ProjectWebsite.Models.Queries;

namespace P4ProjectWebsite.Controllers
{
    public class BiddingController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        public BiddingController(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;

        }
        public IActionResult Index()
        {

            return View("../Task/Bidding");
        }

        public IActionResult SendBid()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var q = new AddBid(_configuration);
            string Supid = q.FindSupId();
            var b = new BidEntity
            {

                          
                Bid = int.Parse(HttpContext.Request.Form["Bid"]),                
                ContributorId = userId,
                SupplierId = Supid
                
            };
            //int CategoryId = q.FindCategoryId(Request.Form["Category"]);


            q.InsertTask(b);
            q.InsertRelation(a);
            return RedirectToAction("Index");
        }




    }
}