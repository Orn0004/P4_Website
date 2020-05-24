using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4ProjectWebsite.Models;
using P4ProjectWebsite.Models.Queries;

namespace P4ProjectWebsite.Controllers.Supplier
{
    public class IncomingBidsController : Controller
    {
        private readonly IConfiguration _configuration;
        public IncomingBidsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View("../Task/Bidding/Supplier/ShowIncomingBids");
        }

        public IActionResult ShowIncomingBids(int taskId, string createdBy)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var b = new GetOpenTasks(_configuration);
            string username = b.FindUsername(userId);
            if (username == createdBy)
            {
            var q = new GetIncomingBids(_configuration);
            var getlist = q.GetList(taskId);
            return View("../Task/Bidding/Supplier/ShowIncomingBids", getlist);
            }
            else { 
            return RedirectToAction("YourTasks", "YourTask");
            }
        }

        public IActionResult Confirm(int bidId, int taskId)
        {
            var q = new ConfirmBid(_configuration);
            q.UpdateBids(bidId);

            if (q.ArchiveTask(taskId))
            {
                q.DeleteTask(taskId);
            }
            
            return RedirectToAction("ShowIncomingBids");
        }
    }
}