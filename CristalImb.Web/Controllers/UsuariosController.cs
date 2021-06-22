using CristalImb.Web.ViewModels.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult IndexUsuarios()
        {
            return View();
        }

        public IActionResult CrearUsuarios()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearUsuarios(UsuarioViewModel usuarioViewModel)
        {
            return View();
        }
    }
}
