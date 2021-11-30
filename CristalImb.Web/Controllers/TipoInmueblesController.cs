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
   
    public class TipoInmueblesController : Controller
    {
        private readonly ITipoInmuebleService _tipoInmuebleService;

        public TipoInmueblesController(ITipoInmuebleService tipoInmuebleService)
        {
            _tipoInmuebleService = tipoInmuebleService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexTipoInmuebles()
        {
            var listTipoInmueble = await _tipoInmuebleService.ObtenerTipos();
            return View(await _tipoInmuebleService.ObtenerTipos());

        }

        [HttpGet]
        public IActionResult RegistrarTipoInmueble()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTipoInmueble(TipoInmuebles tipoInmuebles)
        {
            await _tipoInmuebleService.GuardarTipoInmueble(tipoInmuebles);
            TempData["Accion"] = "GuardarTipoInmueble";
            TempData["Mensaje"] = "Tipo de inmueble guardado con éxito.";

            return RedirectToAction("IndexTipoInmuebles");
        }

        [HttpGet]
        public async Task<IActionResult> EditarTipoInmueble(int id = 0)
        {
            return View(await _tipoInmuebleService.ObtenerTipoInmuebleId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarTipoInmueble(int? id, TipoInmuebles tipoInmuebles)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _tipoInmuebleService.GuardarTipoInmueble(tipoInmuebles);
                    return RedirectToAction("IndexTipoInmuebles");
                }
                else
                {
                    if (id != tipoInmuebles.TipoInmuebleId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexTipoInmuebles");
                    }
                    try
                    {
                        await _tipoInmuebleService.EditarTipoInmueble(tipoInmuebles);
                        TempData["Accion"] = "EditarTipoInmueble";
                        TempData["Mensaje"] = "Tipo de inmueble editado con éxito.";
                        return RedirectToAction("IndexTipoInmuebles");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexTipoInmuebles");
                    }
                }
            }
            else
            {
                return View(tipoInmuebles);
            }

        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexTipoInmuebles");
            }
            TipoInmuebles tipoInmuebles = await _tipoInmuebleService.ObtenerTipoInmuebleId(id.Value);
            try
            {
                if (tipoInmuebles.Estado == true)
                    tipoInmuebles.Estado = false;
                else if (tipoInmuebles.Estado == false)
                    tipoInmuebles.Estado = true;

                await _tipoInmuebleService.EditarTipoInmueble(tipoInmuebles);
                TempData["Accion"] = "EditarEstado";
                TempData["Mensaje"] = "Estado editado correctamente";
                return RedirectToAction("IndexTipoInmuebles");
            }
            catch (Exception)
            {
                return RedirectToAction("IndexTipoInmuebles");
            }
        }

    }
}
