using CristalImb.Business.Abstract;
using CristalImb.Model.DAL;
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
    [Authorize(Roles = "Administrador, Empleado")]
    public class ZonaController : Controller
    {
        private readonly IZonaService _zonaService;
        private readonly AppDbContext _DbContext;

        public ZonaController(IZonaService zonaService, AppDbContext context)
        {
            _zonaService = zonaService;
            _DbContext = context;
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
                    if (NombreExiste(zonasViewModel.NombreZona, zonasViewModel.ZonaId))
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Este nombre de zona ya se encuentra registrado";
                        return RedirectToAction("IndexZona");
                    }
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
        private bool NombreExiste(string nombre, int id)
        {
            return _DbContext.zonas.Where(c => c.ZonaId != id).Any(p => p.NombreZona == nombre);
        }
    }
}
