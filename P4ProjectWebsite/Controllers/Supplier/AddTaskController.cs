﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4ProjectWebsite.Models;
using P4ProjectWebsite.Models.Queries;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using System.Security.Claims;

namespace P4ProjectWebsite.Controllers.Supplier
{
    [Authorize(Policy = "SupplierAccess")]
    public class AddTaskController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        public AddTaskController(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;

        }
        
        public IActionResult Index()
        {
            var g = new GetCategories(_configuration);
            var CategoryList = g.GetList();
            return View("../Task/Supplier/AddTask" , CategoryList);
        }
        public IActionResult Save()
        {
 
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var q = new SaveTask(_configuration);
            string Username = q.FindUsername(userId); 
            var b = new TaskEntity
            {
                Title = HttpContext.Request.Form["Title"],
                Description = HttpContext.Request.Form["Description"],
                Location = HttpContext.Request.Form["Location"],
                Duration = int.Parse(HttpContext.Request.Form["Duration"]),
                Category = Request.Form["Category"],
                CreatedBy = Username,
                DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy")
            };
            
            
            q.InsertTask(b);            
            return RedirectToAction("Index");
        }

    }
}