using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EchoService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("Hello Dan");
        }

        
    }
}
