using CristalImb.Business.Abstract;
using CristalImb.Business.Business;
using CristalImb.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class EstadosInmuebleController : Controller
    {
        private readonly IEstadosInmuebleService _estadosInmuebleService;

        public EstadosInmuebleController(IEstadosInmuebleService estadosInmuebleService)
        {
            _estadosInmuebleService = estadosInmuebleService;

        }

        [HttpGet]
        public async Task<IActionResult> IndexEstadosInm()
        {
            var listEmpleado = await _estadosInmuebleService.ObtenerEstadosInm();
            return View(await _estadosInmuebleService.ObtenerEstadosInm());
        }

        [HttpGet]
        public async Task<IActionResult> RegistrarEstadoInmAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEstadoInm(EstadosInmueble estadosInmueble)
        {
            await _estadosInmuebleService.GuardarEstadoInm(estadosInmueble);
            TempData["Accion"] = "GuardarEstadoInm";
            TempData["Mensaje"] = "Estado de inmueble guardado con éxito.";

            return RedirectToAction("IndexEstadosInm");
        }

        [HttpGet]
        public async Task<IActionResult> EditarEstadoInm(int id = 0)
        {
            return View(await _estadosInmuebleService.ObtenerEstadosInmId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarEstadoInm(int? id, EstadosInmueble estadosInmueble)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _estadosInmuebleService.GuardarEstadoInm(estadosInmueble);
                    return RedirectToAction("IndexEstadosInm");
                }
                else
                {
                    if (id != estadosInmueble.IdEstadoInm)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexEstadosInm");
                    }
                    try
                    {
                        await _estadosInmuebleService.EditarEstadoInm(estadosInmueble);
                        TempData["Accion"] = "EditarEstadoInm";
                        TempData["Mensaje"] = "Estado inmueble editado con éxito.";
                        return RedirectToAction("IndexEstadosInm");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexEstadosInm");
                    }
                }
            }
            else
            {
                return View(estadosInmueble);
            }

        }

        public async Task<IActionResult> DetallesEstadosInm(int? id)
        {
            if (id != null)
            {
                return View(await _estadosInmuebleService.ObtenerEstadosInmId(id.Value));
            }

            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Hubo un error realizando la operación";
            return RedirectToAction("IndexEstadosInm");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarEstadoInm(int id)
        {
            try
            {
                TempData["Accion"] = "Confirmación";
                await _estadosInmuebleService.EliminarEstadoInm(id);
                return RedirectToAction(nameof(IndexEstadosInm));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Hubo un error realizando la operación";
                return RedirectToAction("IndexEstadosInm");
            }

        }
    }
}
