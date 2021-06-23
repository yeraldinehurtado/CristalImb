using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuariosController(UserManager<UsuarioIdentity> userManager, SignInManager<UsuarioIdentity> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> IndexUsuarios()
        {
            var listaUsers = await _userManager.Users.ToListAsync();
            return View(listaUsers);
        }

        public IActionResult CrearUsuarios()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuarios(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                UsuarioIdentity usuarioIdentity = new()
                {
                    UserName = usuarioViewModel.Email,
                    Identificacion = usuarioViewModel.Identificacion,
                    Rol = usuarioViewModel.Rol
                };

                try
                {
                    var resultado = await _userManager.CreateAsync(usuarioIdentity, usuarioViewModel.Password);
                    if (resultado.Succeeded)
                        return RedirectToAction("IndexUsuarios"); //guardar usuario
                    else
                        return View(usuarioViewModel);
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(string id)
        {
            //buscamos el usuario
            var usuario = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(usuario);
            return RedirectToAction("IndexUsuarios");

        }


    }
}
