using CristalImb.Business.Abstract;
using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class RolController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRolService _rolService;
        private readonly IUsuariosService _usuariosService;

        public RolController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IRolService rolService, IUsuariosService usuariosService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _rolService = rolService;
            _usuariosService = usuariosService;
        }

        public async Task<IActionResult> IndexRol()
        {
            var listRoles = await _rolService.ObtenerListaRoles();
            return View(listRoles);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            Rol rol = await _rolService.ObtenerRolId(id);
            if (rol == null)
            {
                return NotFound();
            }
            try
            {
                
                if (rol.Estado == true)
                    rol.Estado = false;
                else if (rol.Estado == false)
                    rol.Estado = true;

                await _rolService.EditarRol(rol);
                var ListaUsuarios = await _usuariosService.ObtenerListaUsuarios();

                foreach (var X in ListaUsuarios)
                {
                    UsuarioIdentity usuarioIdentity = await _usuariosService.ObtenerUsuarioId(X.UsuarioId);

                    if (usuarioIdentity.Rol == rol.Nombre)
                    {
                        if(rol.Estado == false)
                        {
                            usuarioIdentity.Estado = rol.Estado;
                            await _usuariosService.EditarUsuario(usuarioIdentity);
                        }
                    }
                }
                TempData["Accion"] = "EditarEstado";
                TempData["Mensaje"] = "Estado editado correctamente";
                return RedirectToAction("IndexRol");
            }
            catch (Exception)
            {
                return RedirectToAction("IndexRol");
            }

        }
        [HttpGet]
        public async Task<IActionResult> AsignarRolesUsuario()
        {
            var listausuario = await _userManager.Users.ToListAsync();
            var listaRoles = await _roleManager.Roles.ToListAsync();

            ViewBag.Usuarios = new SelectList(listausuario, "Id", "Identificacion");
            ViewBag.Roles = new SelectList(listaRoles, "NormalizedName", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AsignarRolesUsuario(RolesUsuarioViewModel rolesUsuarioViewModel) //trae usuario
        {
            var usuario = await _userManager.FindByIdAsync(rolesUsuarioViewModel.UsuarioId);
            await _userManager.AddToRoleAsync(usuario, rolesUsuarioViewModel.NombreRol); //agregamos rol

            return RedirectToAction("IndexUsuarios", "Usuarios");
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(string usuarioId)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId);
            ViewBag.NombreUsuario = usuario.UserName;
            ViewBag.UsuarioId = usuario.Id;
            var listaRolesUsuario = await _userManager.GetRolesAsync(usuario);

            return View(listaRolesUsuario);
        }

        [HttpGet]
        public async Task<IActionResult> EliminarRolUsuario(string rol, string usuarioId)
        {
            var user = await _userManager.FindByIdAsync(usuarioId);
            var result = await _userManager.RemoveFromRoleAsync(user, rol);
            return RedirectToAction(nameof(Detalle), new { UsuarioId = user.Id });                                                                         
        }


    }
}
