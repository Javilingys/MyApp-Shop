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
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
    }
}
