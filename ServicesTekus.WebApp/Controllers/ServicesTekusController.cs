using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesTekus.Core.Entities;
using ServicesTekus.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesTekus.WebApp.Controllers
{
    public class ServicesTekusController : Controller
    {
        public IActionResult ServicesTekus()
        {
            ViewBag.Countrys =(List<SelectListItem>) DeletegateServicesTekus.GetCountry().Result;

            ViewBag.Providers = (List<SelectListItem>)DeletegateServicesTekus.GetProvider().Result;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public  IActionResult ServicesTekus(ServicesTekusViewModel  _service )
        {
            if (ModelState.IsValid)
            {
                var result = DeletegateServicesTekus.SaveServiceAsync(_service);
                ViewData["menssage"] = "Registro Exitoso.";
            }
            
            return RedirectToAction("ServicesTekus");
        }

    }
}
