using CristalImb.Business.Abstract;
using CristalImb.Model.Entities;
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
        public async Task<IActionResult> RegistrarServiciosInmueble(ServiciosInmueble serviciosInmueble)
        {
            await _serviciosInmuebleService.GuardarServiciosInmueble(serviciosInmueble);
            TempData["Accion"] = "GuardarServiciosInmueble";
            TempData["Mensaje"] = "Servicio de inmueble guardado con éxito.";

            return RedirectToAction("IndexServiciosInmueble");
        }

        [HttpGet]
        public async Task<IActionResult> EditarServiciosInmueble(int id = 0)
        {
            return View(await _serviciosInmuebleService.ObtenerServiciosInmuebleId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarServiciosInmueble(int? id, ServiciosInmueble serviciosInmueble)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _serviciosInmuebleService.GuardarServiciosInmueble(serviciosInmueble);
                    return RedirectToAction("IndexServiciosInmueble");
                }
                else
                {
                    if (id != serviciosInmueble.ServicioInmuebleId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexServiciosInmueble");
                    }
                    try
                    {
                        await _serviciosInmuebleService.EditarServiciosInmueble(serviciosInmueble);
                        TempData["Accion"] = "EditarServiciosInmueble";
                        TempData["Mensaje"] = "Servicio de inmueble editado con éxito.";
                        return RedirectToAction("IndexServiciosInmueble");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexServiciosInmueble");
                    }
                }
            }
            else
            {
                return View(serviciosInmueble);
            }

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
