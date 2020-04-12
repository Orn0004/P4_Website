using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace P4ProjectWebsite.Controllers.Supplier
{
    //[Authorize(Roles = "Supplier")]
    public class SindexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}