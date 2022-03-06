using CristalImb.Business.Abstract;
using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.ServiciosInmueble;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ServiciosInmuebleController : Controller
    {
        private readonly IServiciosInmuebleService _serviciosInmuebleService;

        public ServiciosInmuebleController(IServiciosInmuebleService serviciosInmuebleService)
        {
            _serviciosInmuebleService = serviciosInmuebleService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexServiciosInmueble()
        {
            var listServiciosInmueble = await _serviciosInmuebleService.ObtenerServicios();
            return View(await _serviciosInmuebleService.ObtenerServicios());

        }

        [HttpGet]
        public IActionResult RegistrarServiciosInmueble()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> RegistrarServiciosInmueble(ServiciosInmueblesViewModel serviciosInmueblesViewModel)
        {
            if (ModelState.IsValid)
            {
                ServiciosInmueble serviciosInmueble = new()
                {
                    Nombre = serviciosInmueblesViewModel.Nombre,
                    Estado = true
                };
                try
                {
                    var nombreExiste = await _serviciosInmuebleService.nombreTipoExiste(serviciosInmueble.Nombre);
                    if (nombreExiste != null)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Este nombre de servicio de inmueble ya se encuentra registrado";
                        return RedirectToAction("IndexServiciosInmueble");
                    }
                    await _serviciosInmuebleService.GuardarServiciosInmueble(serviciosInmueble);
                    TempData["Accion"] = "GuardarServiciosInmueble";
                    TempData["Mensaje"] = "Servicio de inmueble guardado con éxito.";
                    return RedirectToAction("IndexServiciosInmueble");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ingresaste un valor inválido";
                    return RedirectToAction("IndexServiciosInmueble");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return RedirectToAction("IndexServiciosInmueble");
        }

        [HttpGet]
        public async Task<IActionResult> EditarServiciosInmueble(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexServiciosInmueble");
            }
            ServiciosInmueble serviciosInmueble = await _serviciosInmuebleService.ObtenerServiciosInmuebleId(id.Value);
            ServiciosInmueblesViewModel serviciosInmueblesViewModel = new()
            {
                ServicioInmuebleId = serviciosInmueble.ServicioInmuebleId,
                Nombre = serviciosInmueble.Nombre,
                Estado = serviciosInmueble.Estado
            };
            return View(serviciosInmueblesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarServiciosInmueble(ServiciosInmueblesViewModel serviciosInmueblesViewModel)
        {
            if (ModelState.IsValid)
            {
                ServiciosInmueble serviciosInmueble = new()
                {
                    ServicioInmuebleId = serviciosInmueblesViewModel.ServicioInmuebleId,
                    Nombre = serviciosInmueblesViewModel.Nombre,
                    Estado = true
                };

                try
                {
                    await _serviciosInmuebleService.EditarServiciosInmueble(serviciosInmueble);
                    TempData["Accion"] = "EditarServiciosInmueble";
                    TempData["Mensaje"] = "Servicio de inmueble editado correctamente";
                    return RedirectToAction("IndexServiciosInmueble");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ingresaste un valor inválido";
                    return RedirectToAction("IndexServiciosInmueble");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return RedirectToAction("IndexServiciosInmueble");


        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexServiciosInmueble");
            }
            ServiciosInmueble serviciosInmueble = await _serviciosInmuebleService.ObtenerServiciosInmuebleId(id.Value);
            try
            {
                if (serviciosInmueble.Estado == true)
                    serviciosInmueble.Estado = false;
                else if (serviciosInmueble.Estado == false)
                    serviciosInmueble.Estado = true;

                await _serviciosInmuebleService.EditarServiciosInmueble(serviciosInmueble);
                TempData["Accion"] = "EditarEstado";
                TempData["Mensaje"] = "Estado editado correctamente";
                return RedirectToAction("IndexServiciosInmueble");
            }
            catch (Exception)
            {
                return RedirectToAction("IndexServiciosInmueble");
            }
        }

    }
}
