using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4_Data.Queries;

namespace P4ProjectWebsite.Controllers
{
    [Authorize(Policy = "UserAccess")]
    public class FormController : Controller
    {
        private readonly IConfiguration _configuration;
        public FormController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OpenJobs()
        {
            var q = new GetJobs(_configuration);
            return View(q.GetList());
        }


    }
}