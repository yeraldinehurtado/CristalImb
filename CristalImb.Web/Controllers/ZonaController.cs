using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class ZonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
