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
            if (bid < currentBid)
            {
                string ContributorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var q = new AddBid(_configuration);
                string SupId = q.FindSupId(taskId);
                var b = new BidEntity
                {

                    Bid = bid,
                    ContributorId = ContributorId,
                    SupplierId = SupId,
                    TaskId = taskId,
                    Confirmation = 0

                };

                q.InsertBid(b);
                q.InsertBidIntoTask(bid, taskId);
            }

            return RedirectToAction("OpenTasks", "Task");
        }
    }
}