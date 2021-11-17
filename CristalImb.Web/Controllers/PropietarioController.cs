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

        public async Task<IActionResult> VerInmuebles(int id)
        {
            ViewBag.PropietarioId = id;
            return View(await _inmPropietariosService.ObtenerListaInmPropietariosPorId(id));
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
            if (id == null || id == 0)
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
                return RedirectToAction("IndexPropietario");
            }
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
                return RedirectToAction("IndexPropietario");
            }

        }


        [HttpGet]
        public async Task<IActionResult> CrearInmPropietarios(int id)
        {
            ViewBag.ListarInmueble = new SelectList(await _inmuebleService.ObtenerInmueble(), "InmuebleId", "Codigo");
            InmPropietariosViewModel inmPropietarios = new()
            {
                PropietarioId = id
            };
            return View(inmPropietarios);
        }

        [HttpPost]
        public async Task<IActionResult> CrearInmPropietarios(InmPropietariosViewModel inmPropietariosViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int propietario = inmPropietariosViewModel.PropietarioId;
                    foreach (var x in inmPropietariosViewModel.inmProp)
                    {
                        InmPropietarios inmPropietarios = new()
                        {
                            PropietarioId = propietario,
                            InmuebleId = x.InmuebleId,
                            FechaInicio = x.FechaInicio,
                            FechaFin = x.FechaFin

                        };
                        await _inmPropietariosService.RegistrarInmPropietarios(inmPropietarios);
                    }
                    TempData["Accion"] = "Crear";
                    TempData["Mensaje"] = "inmueble añadido con éxito";
                    return RedirectToAction("IndexPropietario");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "No se pudo registrar el inmueble";
                    TempData["Mensaje"] = "Error";
                    return RedirectToAction("IndexPropietario");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Se encontró un error";
            return RedirectToAction("IndexPropietario");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarInmPropietario(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Accion"] = "Confirmación";
                    InmPropietarios inmPropietarios = await _inmPropietariosService.ObtenerInmPropietariosId(id);
                    await _inmPropietariosService.EliminarInmPropietarios(id);
                    TempData["Accion"] = "EliminarInmPropietario";
                    TempData["Mensaje"] = "Inmuebles eliminado con éxito.";
                    return RedirectToAction("VerInmuebles");
                }
                catch (Exception)
                {
                    return RedirectToAction("VerInmuebles");
                }
            }
            else
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error.";
                return RedirectToAction("VerInmuebles");
            }

        }
    }

}
