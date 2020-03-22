using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4_Data.Entities;
using P4_Data.Queries;

namespace P4ProjectWebsite.Controllers
{
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

        public IActionResult Overview()
        {
            var q = new GetBruger(_configuration);
            return View(q.GetList());
        }

        public IActionResult Save()
        {
            var b = new Bruger
            {
                Brugernavn = HttpContext.Request.Form["Brugernavn"],
                Fornavn = HttpContext.Request.Form["Fornavn"],
                Efternavn = HttpContext.Request.Form["Efternavn"]
            };
            var q = new SaveBruger(_configuration);
            q.Insert(b);
            return RedirectToAction("Overview");
        }
    }
}