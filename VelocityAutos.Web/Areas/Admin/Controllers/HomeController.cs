﻿using Microsoft.AspNetCore.Mvc;

namespace VelocityAutos.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
