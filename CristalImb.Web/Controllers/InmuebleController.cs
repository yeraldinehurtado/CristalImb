using CristalImb.Business.Abstract;
using CristalImb.Business.Business;
using CristalImb.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class InmuebleController : Controller
    {
        private readonly IInmuebleService _inmuebleService;
        public InmuebleController(IInmuebleService inmuebleService)
        {
            _inmuebleService = inmuebleService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexInmueble()
        {
            var listInmueble = await _inmuebleService.ObtenerInmueble();
            return View(await _inmuebleService.ObtenerInmueble());
        }

        [HttpGet]
        public IActionResult RegistrarInmueble()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarInmueble(Inmueble inmueble)
        {
            await _inmuebleService.GuardarInmueble(inmueble);
            TempData["Accion"] = "GuardarInmueble";
            TempData["Mensaje"] = "Inmueble guardado con éxito.";

            return RedirectToAction("IndexInmueble");
        }

        [HttpGet]
        public async Task<IActionResult> EditarInmueble(int id = 0)
        {
            return View(await _inmuebleService.ObtenerInmuebleId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarInmueble(int? id, Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _inmuebleService.GuardarInmueble(inmueble);
                    return RedirectToAction("IndexInmueble");
                }
                else
                {
                    if (id != inmueble.InmuebleId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexInmueble");
                    }
                    try
                    {
                        await _inmuebleService.EditarInmueble(inmueble);
                        TempData["Accion"] = "EditarInmueble";
                        TempData["Mensaje"] = "Inmueble editado con éxito.";
                        return RedirectToAction("IndexInmueble");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexInmueble");
                    }
                }
            }
            else
            {
                return View(inmueble);
            }

        }

        public async Task<IActionResult> DetallesInmueble(int? id)
        {
            if (id != null)
            {
                return View(await _inmuebleService.ObtenerInmuebleId(id.Value));
            }

            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Hubo un error realizando la operación";
            return RedirectToAction("IndexInmueble");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarInmueble(int id)
        {
            try
            {
                TempData["Accion"] = "Confirmación";
                await _inmuebleService.EliminarInmueble(id);
                return RedirectToAction(nameof(IndexInmueble));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Hubo un error realizando la operación";
                return RedirectToAction("IndexInmueble");
            }

        }
    }
}
