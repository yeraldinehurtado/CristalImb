using CristalImb.Business.Abstract;
using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.Citas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class CitaController : Controller
    {
        private readonly ICitaService _citaService;
        private readonly IServiciosInmuebleService _serviciosInmuebleService;
        private readonly IEstadoCitaService _estadoCitaService;
        private readonly IInmuebleService _inmuebleService;

        public CitaController(ICitaService citaService, IServiciosInmuebleService serviciosInmuebleService, IEstadoCitaService estadoCitaService, IInmuebleService inmuebleService)
        {
            _citaService = citaService;
            _serviciosInmuebleService = serviciosInmuebleService;
            _estadoCitaService = estadoCitaService;
            _inmuebleService = inmuebleService;
        }
        [Authorize(Roles = "Administrador, Empleado")]
        [HttpGet]
        public async Task<IActionResult> IndexCita()
        {
            var listCita = await _citaService.ObtenerCita();
            return View(await _citaService.ObtenerCita());
        }

        [Authorize(Roles = "Administrador, Empleado")]
        [HttpGet]
        public async Task<IActionResult> RegistrarCitaAsync()
        {
            ViewData["ListaServicios"] = new SelectList(await _serviciosInmuebleService.ObtenerListaServiciosEstado(), "ServicioInmuebleId", "Nombre");
            ViewData["ListaInmuebles"] = new SelectList(await _inmuebleService.ObtenerListaInmueblesEstado(), "InmuebleId", "Codigo");
            ViewData["ListaEstados"] = new SelectList(await _estadoCitaService.ObtenerEstadosCitaEstado(), "EstadoCitaId", "Nombre");

            return View();
        }

        [Authorize(Roles = "Administrador, Empleado")]
        [HttpPost]
        public async Task<IActionResult> RegistrarCita(CitasViewModel citaViewModel)
        {
            if (ModelState.IsValid)
            {
                Cita cita = new()
                {
                    InmuebleId = citaViewModel.InmuebleId,
                    Identificacion = citaViewModel.Identificacion,
                    Nombre = citaViewModel.Nombre,
                    Apellido = citaViewModel.Apellido,
                    Telefono = citaViewModel.Telefono,
                    Correo = citaViewModel.Correo,
                    Direccion = citaViewModel.Direccion,
                    FechaHora = citaViewModel.FechaHora,
                    EstadoCitaId = 2
                };
                try
                {
                    var citas = await _citaService.ObtenerFechaExistente(cita.FechaHora);
                    if (citas == null)
                    {
                        await _citaService.GuardarCita(cita);
                        TempData["Accion"] = "GuardarCita";
                        TempData["Mensaje"] = "Cita guardada con éxito.";
                        return RedirectToAction("IndexCita");
                    }
                    else
                    {
                        TempData["Accion"] = "fechaHoraExiste";
                        TempData["Mensaje"] = "La fecha y hora ingresada ya se encuentra registrada dentro del sistema";
                        return RedirectToAction("IndexCita");
                    }
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ingresaste un valor inválido";
                    return RedirectToAction("IndexCita");
                }

            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return RedirectToAction("IndexCita");


        }

            

        [Authorize(Roles = "Cliente")]
        [HttpGet]
        public async Task<IActionResult> RegistrarCitaCliente()
        {
            ViewData["ListaServicios"] = new SelectList(await _serviciosInmuebleService.ObtenerListaServiciosEstado(), "ServicioInmuebleId", "Nombre");
            ViewData["ListaInmuebles"] = new SelectList(await _inmuebleService.ObtenerListaInmueblesEstado(), "InmuebleId", "Codigo");

            return View();
        }

        [Authorize(Roles = "Cliente")]
        [HttpPost]
        public async Task<IActionResult> RegistrarCitaCliente(CitasViewModel citaViewModel)
        {
            if (ModelState.IsValid)
            {
                Cita cita = new()
                {
                    InmuebleId = citaViewModel.InmuebleId,
                    Identificacion = citaViewModel.Identificacion,
                    Nombre = citaViewModel.Nombre,
                    Apellido = citaViewModel.Apellido,
                    Telefono = citaViewModel.Telefono,
                    Correo = citaViewModel.Correo,
                    Direccion = citaViewModel.Direccion,
                    FechaHora = citaViewModel.FechaHora,
                    EstadoCitaId = 2
                };
                try
                {
                    var citas = await _citaService.ObtenerFechaExistente(cita.FechaHora);
                    if (citas == null)
                    {
                        await _citaService.GuardarCita(cita);
                        TempData["Accion"] = "GuardarCitaCli";
                        TempData["Mensaje"] = "Cita guardada con éxito.";
                        return RedirectToAction("RegistrarCitaCliente");
                    }
                    else
                    {
                        TempData["Accion"] = "fechaHoraExiste";
                        TempData["Mensaje"] = "La fecha y hora ingresada ya se encuentra registrada dentro del sistema";
                        return RedirectToAction("RegistrarCitaCliente");
                    }
                }
                catch (Exception)
                {
                    TempData["Accion"] = "ErrorCli";
                    TempData["Mensaje"] = "Ingresaste un valor inválido";
                    return RedirectToAction("RegistrarCitaCliente");
                }

            }
            TempData["Accion"] = "ErrorCli";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return RedirectToAction("RegistrarCitaCliente");

        }
        [Authorize(Roles = "Administrador, Empleado")]
        [HttpGet]
        public async Task<IActionResult> EditarCita(int id = 0)
        {
            ViewData["ListaServicios"] = new SelectList(await _serviciosInmuebleService.ObtenerListaServiciosEstado(), "ServicioInmuebleId", "Nombre");
            ViewData["ListaInmuebles"] = new SelectList(await _inmuebleService.ObtenerListaInmueblesEstado(), "InmuebleId", "Codigo");
            ViewData["ListaEstados"] = new SelectList(await _estadoCitaService.ObtenerEstadosCitaEstado(), "EstadoCitaId", "Nombre");
            return View(await _citaService.ObtenerCitaId(id));
        }
        [Authorize(Roles = "Administrador, Empleado")]
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
                        var citas = await _citaService.ObtenerFechaExisteEditar(cita.FechaHora,cita.CitaId);
                        if (citas == null)
                        {
                            await _citaService.EditarCita(cita);
                            TempData["Accion"] = "EditarCita";
                            TempData["Mensaje"] = "Cita editada con éxito.";
                            return RedirectToAction("IndexCita");
                        }
                        else
                        {
                            TempData["Accion"] = "fechaHoraExiste";
                            TempData["Mensaje"] = "La fecha y hora ingresada ya se encuentra registrada dentro del sistema";
                            return RedirectToAction("IndexCita");
                        }


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
        [Authorize(Roles = "Administrador, Empleado")]
        public async Task<IActionResult> DetallesCita(int? id)
        {
            var listCita = await _citaService.ObtenerCita();

            var listaservice = await _serviciosInmuebleService.ObtenerServicios();

            if (id != null)
            {
                return View(await _citaService.ObtenerCitaId(id.Value));
            }

            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Hubo un error realizando la operación";
            return RedirectToAction("IndexCita");
        }
        [Authorize(Roles = "Administrador, Empleado")]
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

    
   