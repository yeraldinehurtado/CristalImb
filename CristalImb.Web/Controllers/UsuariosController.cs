using CristalImb.Business.Dtos.Usuarios;
using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.Roles;
using CristalImb.Web.ViewModels.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    [Authorize(Roles = "Admin, Administrador, Empleado")]
    public class UsuariosController : Controller
    {
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        const string SesionNombre = "_Nombre";



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
                    Identificacion = usuarioViewModel.Identificacion,
                    UserName = usuarioViewModel.Email,
                    Email = usuarioViewModel.Email
                };

                try
                {
                    var resultado = await _userManager.CreateAsync(usuarioIdentity, usuarioViewModel.Password); //objeto usermanager para crear el usuario
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

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                UsuarioIdentity usuarioIdentity = new()
                {
                    Identificacion = usuarioViewModel.Identificacion,
                    UserName = usuarioViewModel.Email,
                    Email = usuarioViewModel.Email
                };

                try
                {
                    var resultado = await _userManager.CreateAsync(usuarioIdentity, usuarioViewModel.Password); //objeto usermanager para crear el usuario
                    if (resultado.Succeeded)
                        return RedirectToAction("Login"); //guardar usuario
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

        [HttpGet]
        public IActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RecordarMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "Admin");
                }

                return View();
            }
            else
            {
                return View(loginViewModel);
            }
        }

        [HttpGet]
        public IActionResult OlvidePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OlvidePassword(OlvidePasswordDto olvidePasswordDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByEmailAsync(olvidePasswordDto.Email);// user maneger es para buscar los usuarios

                if (usuario != null)
                {
                    //generamos token
                    var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

                    //creamos link para resetear password

                    var passwordResetLink = Url.Action("ResetearPassword", "Usuarios",
                        new {email = olvidePasswordDto.Email, token = token}, Request.Scheme);

                    //Opcion 1 en la que usamos smpt

                    MailMessage mensaje = new();
                    mensaje.To.Add(olvidePasswordDto.Email);//destinatario
                    mensaje.Subject = "CrudCristalimb recuperar password";
                    mensaje.Body = passwordResetLink;
                    mensaje.IsBodyHtml = false;
                    mensaje.From = new MailAddress("alejd066@gmail.com", "Alejandro");
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("alejd066@gmail.com", "tomalejowar4056");
                    smtpClient.Send(mensaje);
                    return RedirectToAction("Login");
                }
                else
                {
                    return View(olvidePasswordDto);
                }
            }
            return View(olvidePasswordDto);


        }

        [HttpGet]
        public IActionResult ResetearPassword(string token, string email)
        {
            if(token == null || email == null)
            {
                ModelState.AddModelError("", "Error token");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetearPassword(ResetearPasswordDto resetearPasswordDto)
        {
            if (ModelState.IsValid)
            {
                //Buscamos el usuario
                var usuario = await _userManager.FindByEmailAsync(resetearPasswordDto.Email);// user maneger es para buscar los usuarios

                if (usuario != null)
                {
                    //se resetea el password
                    var result = await _userManager.ResetPasswordAsync(usuario, resetearPasswordDto.Token, resetearPasswordDto.Password);
                    if (result.Succeeded)
                        return RedirectToAction("Login");
                    else
                    {
                        foreach(var errores in result.Errors)
                        {
                            ModelState.AddModelError("", errores.Description);
                        }
                        return View(resetearPasswordDto);
                    }
                    
                }
                return View(resetearPasswordDto);
            }
            return View(resetearPasswordDto);
        }

        [HttpGet]
        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            _httpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Landing");
        }
    }
}
