using CristalImb.Business.Abstract;
using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.Zonas;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> RegistrarZona(ZonasViewModel zonasViewModel)
        {
            if (ModelState.IsValid)
            {
                Zona zona = new()
                {
                    NombreZona = zonasViewModel.NombreZona,
                    Estado = true
                };
                try
                {
                    var nombreExiste = await _zonaService.nombreZonaExiste(zona.NombreZona);
                    if (nombreExiste != null)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Este nombre de zona ya se encuentra registrado";
                        return RedirectToAction("IndexZona");
                    }
                    await _zonaService.GuardarZona(zona);
                    TempData["Accion"] = "GuardarZona";
                    TempData["Mensaje"] = "Zona guardada con éxito.";
                    return RedirectToAction("IndexZona");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ingresaste un valor inválido";
                    return RedirectToAction("IndexZona");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return RedirectToAction("IndexZona");
        }

        [HttpGet]
        public async Task<IActionResult> EditarZona(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexZona");
            }
            Zona zona = await _zonaService.ObtenerZonaId(id.Value);
            ZonasViewModel zonasViewModel = new()
            {
                ZonaId = zona.ZonaId,
                NombreZona = zona.NombreZona,
                Estado = zona.Estado
            };
            return View(zonasViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarZona(ZonasViewModel zonasViewModel)
        {
            if (ModelState.IsValid)
            {
                Zona zona = new()
                {
                    ZonaId = zonasViewModel.ZonaId,
                    NombreZona = zonasViewModel.NombreZona,
                    Estado = true
                };

                try
                {
                    await _zonaService.EditarZona(zona);
                    TempData["Accion"] = "EditarZona";
                    TempData["Mensaje"] = "Zona editada correctamente";
                    return RedirectToAction("IndexZona");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ingresaste un valor inválido";
                    return RedirectToAction("IndexZona");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return RedirectToAction("IndexZona");

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
                return RedirectToAction("IndexZona");
            }
        }
    }
}
