using CristalImb.Business.Abstract;
using CristalImb.Business.Business;
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
    public class PropietarioController : Controller
    {
        private readonly IPropietarioService _propietarioService;
        private readonly IInmuebleService _inmuebleService;
        private readonly IInmPropietariosService _inmPropietariosService;

        public PropietarioController(IPropietarioService propietarioService, IInmuebleService inmuebleService, IInmPropietariosService inmPropietariosService)
        {
            _propietarioService = propietarioService;
            _inmuebleService = inmuebleService;
            _inmPropietariosService = inmPropietariosService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexPropietario()
        {
            var listPropietario = await _propietarioService.ObtenerPropietario();
            return View(await _propietarioService.ObtenerPropietario());
            
        }

        [HttpGet]
        public IActionResult RegistrarPropietario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPropietario(Propietario propietario)
        {
            await _propietarioService.GuardarPropietario(propietario);
            TempData["Accion"] = "GuardarPropietario";
            TempData["Mensaje"] = "Propietario guardado con éxito.";

            return RedirectToAction("IndexPropietario");
        }

        [HttpGet]
        public async Task<IActionResult> EditarPropietario(int id = 0)
        {
            return View(await _propietarioService.ObtenerPropietarioId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarPropietario(int? id, Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _propietarioService.GuardarPropietario(propietario);
                    return RedirectToAction("IndexPropietario");
                }
                else
                {
                    if (id != propietario.PropietarioId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexPropietario");
                    }
                    try
                    {
                        await _propietarioService.EditarPropietario(propietario);
                        TempData["Accion"] = "EditarPropietario";
                        TempData["Mensaje"] = "Propietario editado con éxito.";
                        return RedirectToAction("IndexPropietario");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexPropietario");
                    }
                }
            }
            else
            {
                return View(propietario);
            }

        }

        public async Task<IActionResult> SeleccionarInmuebles()
        {
            var selectInmuebles = await _inmuebleService.ObtenerInmueble();
            return View(await _inmuebleService.ObtenerInmueble());
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(int? id)
        {
            if(id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexPropietario");
            }
            Propietario propietario = await _propietarioService.ObtenerPropietarioId(id.Value);
            try
            {
                if (propietario.Estado == true)
                    propietario.Estado = false;
                else if (propietario.Estado == false)
                    propietario.Estado = true;

                await _propietarioService.EditarPropietario(propietario);
                TempData["Accion"] = "EditarEstado";
                TempData["Mensaje"] = "Estado editardo correctamente";
                return RedirectToAction("IndexPropietario");
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexPropietario");
            }
        }


        public async Task<IActionResult> DetallesPropietario(int? id)
        {
            if (id != null)
            {
                return View(await _propietarioService.ObtenerPropietarioId(id.Value));
            }

            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Hubo un error realizando la operación";
            return RedirectToAction("IndexPropietario");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPropietario(int id)
        {
            try
            {
                TempData["Accion"] = "Confirmación";
                await _propietarioService.EliminarPropietario(id);
                return RedirectToAction(nameof(IndexPropietario));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Hubo un error realizando la operación";
                return RedirectToAction("IndexPropietario");
            }

        }


        public async Task<IActionResult> CrearInmPropietarios(int id)
        {
            ViewBag.ListarInmueble = new SelectList(await _inmuebleService.ObtenerInmueble(), "InmuebleId", "Codigo");
            //ViewBag.ListarInsumo = new SelectList(await _insumoService.ObtenerListaInsumos(), "InsumoId", "Nombre");
            InmPropietariosViewModel inmPropietariosViewModel = new()
            {
                PropietarioId = id
            };
            return View(inmPropietariosViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CrearInmPropietarios(InmPropietariosViewModel inmPropietariosViewModel)
        {
            if (ModelState.IsValid)
            {
                InmPropietarios inmPropietarios = new()
                {
                    PropietarioId = inmPropietariosViewModel.PropietarioId,
                    InmuebleId = inmPropietariosViewModel.InmuebleId,
                    FechaInicio = inmPropietariosViewModel.FechaInicio,
                    FechaFin = inmPropietariosViewModel.FechaFin,
                    
                };

                try
                {
                    var InmuebleExiste = await _inmPropietariosService.InmuebleExiste(inmPropietarios.PropietarioId, inmPropietarios.InmuebleId);

                    if (InmuebleExiste != null)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "El inmueble ya se encuentra registrado";
                        return RedirectToAction("Index");
                    }
                    await _inmPropietariosService.RegistrarInmPropietarios(inmPropietarios);
                    TempData["Accion"] = "Crear";
                    TempData["Mensaje"] = "inmueble añadido con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Hubo un error al añadir el procuto";
                    return RedirectToAction("Index");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Alguno de los valores no comple con los requisitos";
            return RedirectToAction("Index");
        }

    }
}
