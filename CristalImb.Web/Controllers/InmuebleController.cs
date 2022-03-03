﻿using CristalImb.Business.Abstract;
using CristalImb.Business.Business;
using CristalImb.Web.ViewModels.Inmuebles;
using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.InmPropietarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CristalImb.Web.Controllers
{
    [Authorize(Roles = "Administrador, Empleado")]
    public class InmuebleController : Controller
    {
        private readonly IPropietarioService _propietarioService;
        private readonly IInmuebleService _inmuebleService;
        private readonly ITipoInmuebleService _tipoInmuebleService;
        private readonly IZonaService _zonaService;
        private readonly IEstadosInmuebleService _estadosInmuebleService;
        private readonly IServiciosInmuebleService _serviciosInmuebleService;
        private readonly IInmPropietariosService _inmPropietariosService;

        public InmuebleController(IInmuebleService inmuebleService, ITipoInmuebleService tipoInmuebleService, IZonaService zonaService, IEstadosInmuebleService estadosInmuebleService, IPropietarioService propietarioService, IServiciosInmuebleService serviciosInmuebleService, IInmPropietariosService inmPropietariosService)
        {
            _inmuebleService = inmuebleService;
            _tipoInmuebleService = tipoInmuebleService;
            _zonaService = zonaService;
            _estadosInmuebleService = estadosInmuebleService;
            _serviciosInmuebleService = serviciosInmuebleService;
            _inmPropietariosService = inmPropietariosService;
            _propietarioService = propietarioService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexInmueble()
        {
            var listInmueble = await _inmuebleService.ObtenerInmueble();
            return View(await _inmuebleService.ObtenerInmueble());
        }

        [HttpGet]
        public async Task<IActionResult> RegistrarInmuebleAsync()
        {

            ViewData["ListaTipos"] = new SelectList(await _tipoInmuebleService.ObtenerListaTiposEstado(), "TipoInmuebleId", "NombreTipoInm");
            ViewData["ListaEstadosInm"] = new SelectList(await _estadosInmuebleService.ObteneEstadosInmueblesEstado(), "IdEstadoInm", "NombreEstado");
            ViewData["listaZona"] = new SelectList(await _zonaService.ObtenerListaZonaEstado(), "ZonaId", "NombreZona");
            ViewData["ListaServicios"] = new SelectList(await _serviciosInmuebleService.ObtenerListaServiciosEstado(), "ServicioInmuebleId", "Nombre");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegistrarInmueble(Inmueble inmueble)
        {
            try
            {
                var CodigoExiste = await _inmuebleService.CodigoExiste(inmueble.Codigo);
                if (CodigoExiste != null)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "El código del inmueble ya se encuentra registrado";
                    return RedirectToAction("IndexInmueble");
                }
                inmueble.Estado = true;
                await _inmuebleService.GuardarInmueble(inmueble);
                TempData["Accion"] = "GuardarInmueble";
                TempData["Mensaje"] = "Inmueble guardado con éxito.";
                return RedirectToAction("IndexInmueble");
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ingresaste un valor inválido";
                return RedirectToAction("IndexInmueble");
            }
        
    }

        [HttpGet]
        public async Task<IActionResult> EditarInmueble(int id = 0)
        {
            ViewData["ListaTipos"] = new SelectList(await _tipoInmuebleService.ObtenerListaTiposEstado(), "TipoInmuebleId", "NombreTipoInm");
            ViewData["ListaEstadosInm"] = new SelectList(await _estadosInmuebleService.ObteneEstadosInmueblesEstado(), "IdEstadoInm", "NombreEstado");
            ViewData["listaZona"] = new SelectList(await _zonaService.ObtenerListaZonaEstado(), "ZonaId", "NombreZona");
            ViewData["ListaServicios"] = new SelectList(await _serviciosInmuebleService.ObtenerListaServiciosEstado(), "ServicioInmuebleId", "Nombre");
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

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexInmueble");
            }
            Inmueble inmueble = await _inmuebleService.ObtenerInmuebleId(id.Value);
            try
            {
                if (inmueble.Estado == true)
                    inmueble.Estado = false;
                else if (inmueble.Estado == false)
                    inmueble.Estado = true;

                await _inmuebleService.EditarInmueble(inmueble);
                TempData["Accion"] = "EditarEstado";
                TempData["Mensaje"] = "Estado editardo correctamente";
                return RedirectToAction("IndexInmueble");
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexInmueble");
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

        public async Task<IActionResult> VerPropietarios(int id)
        {
            ViewBag.PropietarioId = id;
            return View(await _inmPropietariosService.ObtenerListaInmPropietariosPorId2(id));
        }



    }
}
