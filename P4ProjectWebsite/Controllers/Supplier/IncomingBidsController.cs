using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult ShowIncomingBids(int taskId)
        {
            var q = new GetIncomingBids(_configuration);
            var getlist = q.GetList(taskId);
            return View("../Task/Bidding/Supplier/ShowIncomingBids", getlist);
        }
        [HttpGet]
        public IActionResult Delete(string name)
        {
            var q = new DeleteCategory(_configuration);

            q.RemoveCategory(name);
            return RedirectToAction("ShowCategories");
        }
    }
}