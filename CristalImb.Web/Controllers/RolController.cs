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
    public class RolController : Controller
    {
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly IRolService _rolService;

        public RolController(UserManager<UsuarioIdentity> userManager, SignInManager<UsuarioIdentity> signInManager, RoleManager<Rol> roleManager, IRolService rolService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _rolService = rolService;
        }
        public async Task<IActionResult> IndexRol()
        {
            var listRoles = await _roleManager.Roles.ToListAsync();
            return View(listRoles);
        }

        public IActionResult CrearRol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol(string rol)
        {
            await _roleManager.CreateAsync(new Rol(rol));
            return RedirectToAction(nameof(IndexRol));
        }

        [HttpGet]
        public async Task<IActionResult> EditarRol(string rol)
        {
            if (rol == null || rol == "")
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexRol");
            }
            try
            {
                return View(await _roleManager.FindByNameAsync(rol));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ingresaste un valor inválido";
                return RedirectToAction("IndexRol");
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditarRol(IdentityRole identityRole)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(identityRole.Id);
                role.Name = identityRole.Name;
                var result = await _roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Error";
                    return RedirectToAction("IndexRol");
                }
                TempData["Accion"] = "Editar";
                TempData["Mensaje"] = "Rol editado correctamente";
                return RedirectToAction("IndexRol");
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ingresaste un valor inválido";
                return RedirectToAction("IndexRol");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            Rol rol = await _rolService.ObtenerRolId(Guid.Parse(id));
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
            ViewBag.Roles = new SelectList(listaRoles, "Name", "Name");

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
