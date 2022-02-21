using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesTekus.WebApp.Controllers
{
    public class ServicesTekusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
