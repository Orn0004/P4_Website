using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace P4ProjectWebsite.Controllers.Contributor
{
    //[Authorize(Roles = "Admin")]
    public class CIndexController : Controller
    {
        public IActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Contributor");
            //}

            return View();
        }
    }
}