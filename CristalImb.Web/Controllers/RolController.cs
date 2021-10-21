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
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolController(UserManager<UsuarioIdentity> userManager, SignInManager<UsuarioIdentity> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult IndexRol()
        {
            var listRoles = _roleManager.Roles.ToList();
            return View(listRoles);
        }

        public IActionResult CrearRol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol(string rol)
        {
            await _roleManager.CreateAsync(new IdentityRole(rol));
            return RedirectToAction(nameof(IndexRol));
        }

        [HttpGet]
        public async Task<IActionResult> EditarRol(string rol)
        {
            return View(await _roleManager.FindByNameAsync(rol));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarRol(string? rol, IdentityRole identityRole)
        {
            if (ModelState.IsValid)
            {
                if (rol == null)
                {
                    await _roleManager.UpdateAsync(identityRole);
                    return RedirectToAction("IndexRol");
                }
                else
                {
                    if (rol != identityRole.Name)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexRol");
                    }
                    try
                    {
                        await _roleManager.UpdateAsync(identityRole);
                        TempData["Accion"] = "EditarRol";
                        TempData["Mensaje"] = "Rol editado con éxito.";
                        return RedirectToAction("IndexRol");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexRol");
                    }
                }
            }
            else
            {
                return View(rol);
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

        [HttpGet]
        public async Task<IActionResult> EliminarRol(string rol)
        {
            //get role to delete using role Name
            //delete role using roleManager
            //redirect to displayroles

            var roleToDelete = await _roleManager.FindByNameAsync(rol);
            var result = await _roleManager.DeleteAsync(roleToDelete);

            return RedirectToAction(nameof(IndexRol));
        }

    }
}
