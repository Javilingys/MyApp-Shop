using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace FirstApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld
        public string Index()
        {
            return "This is hello world...";
        }

        // GET: /HelloWorld/Welcome
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["NumTimes"] = numTimes;
            ViewData["Message"] = name;

            return View();
        }
    }
}
