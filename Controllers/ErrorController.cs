using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleWebFrontend_ASP_NETCORE31.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NotFounds()
        {
            return View();
        }
        public IActionResult NullData()
        {
            return View();
        }
        public IActionResult Code(string code)
        {
            if(code == "404")
            {
                return Redirect("/Error/NotFounds");
            }
            return Content(code);
        }
    }
}