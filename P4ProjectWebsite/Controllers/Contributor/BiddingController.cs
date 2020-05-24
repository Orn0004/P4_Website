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

            return View("../Task/Bidding");
        }

        public IActionResult SendBid(int taskId, int currentBid)
        {
            int bid = int.Parse(HttpContext.Request.Form["Bid"]);
          
                string ContributorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var q = new AddBid(_configuration);
                string ContributorName = q.FindContributorName(ContributorId);
                string SupName = q.FindSupplierName(taskId);
                var b = new BidEntity
                {
                    Bid = bid,
                    ContributorUsername = ContributorName,
                    SupplierUsername = SupName,
                    TaskId = taskId,
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy")
                };

                q.InsertBid(b);
                int LowestBid = q.LowestBidQuery(taskId);
                q.InsertLowestBidIntoTask(LowestBid, taskId);

            return RedirectToAction("OpenTasks", "Task");
        }
    }
}