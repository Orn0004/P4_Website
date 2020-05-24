
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
    public class OutgoingBidsController : Controller
    {

        private readonly IConfiguration _configuration;
        public OutgoingBidsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var b = new GetOpenTasks(_configuration);
            string username = b.FindUsername(userId);
            var g = new GetOutgoingBids(_configuration);
            var getlist = g.GetList(username);

            return View("../Task/Bidding/Contributor/ShowOutgoingBids", getlist);
        }

      
    }
}