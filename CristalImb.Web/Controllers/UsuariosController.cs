using CristalImb.Business.Dtos.Usuarios;
using CristalImb.Business.Abstract;
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
    
    public class UsuariosController : Controller
    {
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly IUsuariosService _usuariosService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        const string SesionNombre = "_Nombre";



        public UsuariosController(UserManager<UsuarioIdentity> userManager, SignInManager<UsuarioIdentity> signInManager, IUsuariosService usuariosService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usuariosService = usuariosService;
            _httpContextAccessor = httpContextAccessor;
        }



            public async Task<IActionResult> IndexUsuarios()
            {
                var listaUsers = await _userManager.Users.ToListAsync();
                return View(listaUsers);
            }

        [HttpGet]
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
                        return RedirectToAction("IndexUsuarios");
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return View();
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> EditarUsuario(string usuarioIdentity)
        {
            if (usuarioIdentity == null || usuarioIdentity == "")
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexUsuarios");
            }
            try
            {
                return View(await _userManager.FindByNameAsync(usuarioIdentity));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ingresaste un valor inválido";
                return RedirectToAction("IndexUsuarios");
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditarUsuario(UsuarioIdentity usuarioIdentity)
        {
            try
            {
                var usuario = await _userManager.FindByIdAsync(usuarioIdentity.Id);
                usuario.Identificacion = usuarioIdentity.Identificacion;
                usuario.UserName = usuarioIdentity.UserName;
                usuario.Email = usuarioIdentity.Email;
                var result = await _userManager.UpdateAsync(usuario);
                if (!result.Succeeded)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Error";
                    return RedirectToAction("IndexUsuarios");
                }
                TempData["Accion"] = "Editar";
                TempData["Mensaje"] = "usuario editado correctamente";
                return RedirectToAction("IndexUsuarios");
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ingresaste un valor inválido";
                return RedirectToAction("IndexUsuarios");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            UsuarioIdentity usuarioIdentity = await _usuariosService.ObtenerUsuarioId(Guid.Parse(id));
            if (usuarioIdentity == null)
            {
                return NotFound();
            }
            try
            {
                if (usuarioIdentity.Estado == true)
                    usuarioIdentity.Estado = false;
                else if (usuarioIdentity.Estado == false)
                    usuarioIdentity.Estado = true;

                await _usuariosService.EditarUsuario(usuarioIdentity);
                TempData["Accion"] = "EditarEstado";
                TempData["Mensaje"] = "Estado editado correctamente";
                return RedirectToAction("IndexUsuarios");
            }
            catch (Exception)
            {
                return RedirectToAction("IndexUsuarios");
            }

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

        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RecordarMe, false);
                if (resultado.Succeeded)
                {
                    var usuario = await _userManager.FindByEmailAsync(loginViewModel.Email);
                    var rol = await _userManager.GetRolesAsync(usuario);

                    if (rol.Contains("Administrador") || rol.Contains("Empleado"))
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else if (rol.Contains("Cliente"))
                    {
                        return RedirectToAction("RegistrarCita", "Cita");
                    }


                }
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Correo o contraseña incorrecto";
                return View();
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return View(loginViewModel);

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult OlvidePassword()
        {
            return View();
        }
        [AllowAnonymous]
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
                    mensaje.Subject = "Cristalimb - recuperar contraseña";
                    mensaje.Body = "Hola. <br><br> Hemos recibido una solicitud para restablecer tu contraseña en CristalImb. <br><br> Ingresa al siguiente link para realizar el cambio: <br><br>" + passwordResetLink + "<br><br> Si no solicitó un restablecimiento de contraseña, puede ignorar este correo electrónico.";
                    mensaje.IsBodyHtml = true;
                    mensaje.From = new MailAddress("alejd066@gmail.com", "Cristal Inmobiliaria");
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResetearPassword(string token, string email)
        {
            if(token == null || email == null)
            {
                ModelState.AddModelError("", "Error token");
            }
            return View();
        }
        [AllowAnonymous]
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
