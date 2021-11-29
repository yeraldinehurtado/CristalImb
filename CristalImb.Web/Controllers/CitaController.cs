using CristalImb.Business.Abstract;
using CristalImb.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    [Authorize]
    public class CitaController : Controller
    {
        private readonly ICitaService _citaService;
        private readonly IServiciosInmuebleService _serviciosInmuebleService;
        private readonly IEstadoCitaService _estadoCitaService;

        public CitaController(ICitaService citaService, IServiciosInmuebleService serviciosInmuebleService, IEstadoCitaService estadoCitaService)
        {
            _citaService = citaService;
            _serviciosInmuebleService = serviciosInmuebleService;
            _estadoCitaService = estadoCitaService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexCita()
        {
            var listCita = await _citaService.ObtenerCita();
            return View(await _citaService.ObtenerCita());
        }
        
        
        [HttpGet]
        public async Task<IActionResult> RegistrarCitaAsync()
        {
           
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> RegistrarCita(Cita cita)
        {
            await _citaService.GuardarCita(cita);
            TempData["Accion"] = "GuardarCita";
            TempData["Mensaje"] = "Cita guardada con éxito.";

            return RedirectToAction("IndexCita");
        }

        [HttpGet]
        public async Task<IActionResult> EditarCita(int id = 0)
        {
            ViewData["ListaServicios"] = new SelectList(await _serviciosInmuebleService.ObtenerServicios(), "ServicioInmuebleId", "Nombre");
            return View(await _citaService.ObtenerCitaId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarCita(int? id, Cita cita)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _citaService.GuardarCita(cita);
                    return RedirectToAction("IndexCita");
                }
                else
                {
                    if (id != cita.CitaId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexCita");
                    }
                    try
                    {
                        await _citaService.EditarCita(cita);
                        TempData["Accion"] = "EditarCita";
                        TempData["Mensaje"] = "Cita editada con éxito.";
                        return RedirectToAction("IndexCita");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexCita");
                    }
                }
            }
            else
            {
                return View(cita);
            }

        }

        public async Task<IActionResult> DetallesCita(int? id)
        {
            if (id != null)
            {
                return View(await _citaService.ObtenerCitaId(id.Value));
            }

            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Hubo un error realizando la operación";
            return RedirectToAction("IndexCita");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarCita(int id)
        {
            try
            {
                TempData["Accion"] = "Confirmación";
                await _citaService.EliminarCita(id);
                return RedirectToAction(nameof(IndexCita));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Hubo un error realizando la operación";
                return RedirectToAction("IndexCita");
            }

        }
    }
}

    
   