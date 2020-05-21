using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4ProjectWebsite.Models;
using P4ProjectWebsite.Models.Queries;
using System.Net.Http;

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
            var FullUrl = HttpContext.Request.Path();
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            var taskId = FullUrl.Split('/').Last();       

            return View("../Task/Bidding");
        }

        public IActionResult SendBid(int taskId)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var q = new AddBid(_configuration);
            string Supid = q.FindSupId();
            var b = new BidEntity
            {
                          
                Bid = int.Parse(HttpContext.Request.Form["Bid"]),                
                ContributorId = userId,
                SupplierId = SupId,
                TaskId = taskId
                
            };
            //int CategoryId = q.FindCategoryId(Request.Form["Category"]);


            
            return RedirectToAction("Index");
        }




    }
}