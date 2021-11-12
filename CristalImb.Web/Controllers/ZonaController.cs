using CristalImb.Business.Abstract;
using CristalImb.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class ZonaController : Controller
    {
        private readonly IZonaService _zonaService;

        public ZonaController(IZonaService zonaService)
        {
            _zonaService = zonaService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexZona()
        {
            var listZona = await _zonaService.ObtenerZonas();
            return View(await _zonaService.ObtenerZonas());

        }

        [HttpGet]
        public IActionResult RegistrarZona()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarZona(Zona zona)
        {
            await _zonaService.GuardarZona(zona);
            TempData["Accion"] = "GuardarZona";
            TempData["Mensaje"] = "Zona guardada con éxito.";

            return RedirectToAction("IndexZona");
        }

        [HttpGet]
        public async Task<IActionResult> EditarZona(int id = 0)
        {
            return View(await _zonaService.ObtenerZonaId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarZona(int? id, Zona zona)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _zonaService.GuardarZona(zona);
                    return RedirectToAction("IndexZona");
                }
                else
                {
                    if (id != zona.ZonaId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexZona");
                    }
                    try
                    {
                        await _zonaService.EditarZona(zona);
                        TempData["Accion"] = "EditarZona";
                        TempData["Mensaje"] = "Zona editada con éxito.";
                        return RedirectToAction("IndexZona");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexZona");
                    }
                }
            }
            else
            {
                return View(zona);
            }

        }


        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexZona");
            }
            Zona zona = await _zonaService.ObtenerZonaId(id.Value);
            try
            {
                if (zona.Estado == true)
                    zona.Estado = false;
                else if (zona.Estado == false)
                    zona.Estado = true;

                await _zonaService.EditarZona(zona);
                TempData["Accion"] = "EditarEstado";
                TempData["Mensaje"] = "Estado editardo correctamente";
                return RedirectToAction("IndexZona");
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexZona");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EliminarZona(int id)
        {
            try
            {
                TempData["Accion"] = "Confirmación";
                await _zonaService.EliminarZona(id);
                return RedirectToAction(nameof(IndexZona));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Hubo un error realizando la operación";
                return RedirectToAction("IndexZona");
            }

        }
    }
}
