using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult IndexLanding()
        {
            return View();
        }
    }
}
