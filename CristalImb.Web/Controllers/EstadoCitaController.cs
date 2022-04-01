using CristalImb.Business.Abstract;
using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.EstadoCita;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class EstadoCitaController : Controller
    {
        private readonly IEstadoCitaService _estadoCitaService;

        public EstadoCitaController(IEstadoCitaService estadoCitaService)
        {
            _estadoCitaService = estadoCitaService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexEstadoCita()
        {
            var listEstadoCita = await _estadoCitaService.ObtenerCitas();
            return View(await _estadoCitaService.ObtenerCitas());

        }

        [HttpGet]
        public IActionResult RegistrarEstadoCita()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEstadoCita(EstadoCitaViewModel estadoCitaViewModel)
        {
            if (ModelState.IsValid)
            {
                EstadoCita estadoCita = new()
                {
                    Nombre = estadoCitaViewModel.Nombre,
                    Estado = true
                };
                try
                {
                    var nombreExiste = await _estadoCitaService.nombreEstadoCitaExiste(estadoCita.Nombre);
                    if (nombreExiste != null)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Este nombre de estado de cita ya se encuentra registrado";
                        return RedirectToAction("IndexEstadoCita");
                    }

                    estadoCita.Estado = true;

                    await _estadoCitaService.GuardarEstadoCita(estadoCita);
                    TempData["Accion"] = "GuardarEstadoCita";
                    TempData["Mensaje"] = "Estado de cita guardada con éxito.";
                    return RedirectToAction("IndexEstadoCita");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ingresaste un valor inválido";
                    return RedirectToAction("IndexEstadoCita");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return RedirectToAction("IndexEstadoCita");
        }

        [HttpGet]
        public async Task<IActionResult> EditarEstadoCita(int id = 0)
        {
            return View(await _estadoCitaService.ObtenerEstadoCitaId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarEstadoCita(int? id, EstadoCita estadoCita)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _estadoCitaService.GuardarEstadoCita(estadoCita);
                    return RedirectToAction("IndexEstadoCita");
                }
                else
                {
                    if (id != estadoCita.EstadoCitaId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexEstadoCita");
                    }
                    try
                    {
                        var nombreExiste = await _estadoCitaService.nombreEstadoCitaEditarExiste(estadoCita.Nombre, estadoCita.EstadoCitaId);
                        if (nombreExiste != null)
                        {
                            TempData["Accion"] = "Error";
                            TempData["Mensaje"] = "Este nombre de estado de cita ya se encuentra registrado";
                            return RedirectToAction("IndexEstadoCita");
                        }
                        await _estadoCitaService.EditarEstadoCita(estadoCita);
                        TempData["Accion"] = "EditarEstadoCita";
                        TempData["Mensaje"] = "Estado de cita editado con éxito.";
                        return RedirectToAction("IndexEstadoCita");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexEstadoCita");
                    }
                }
            }
            else
            {
                return View(estadoCita);
            }

        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexEstadoCita");
            }
            EstadoCita estadoCita = await _estadoCitaService.ObtenerEstadoCitaId(id.Value);
            try
            {
                if (estadoCita.Estado == true)
                    estadoCita.Estado = false;
                else if (estadoCita.Estado == false)
                    estadoCita.Estado = true;

                await _estadoCitaService.EditarEstadoCita(estadoCita);
                TempData["Accion"] = "EditarEstado";
                TempData["Mensaje"] = "Estado editado correctamente";
                return RedirectToAction("IndexEstadoCita");
            }
            catch (Exception)
            {
                return RedirectToAction("IndexEstadoCita");
            }
        }

    }
}
