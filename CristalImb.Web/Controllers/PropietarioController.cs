using CristalImb.Business.Abstract;
using CristalImb.Business.Business;
using CristalImb.Model.DAL;
using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.InmPropietarios;
using CristalImb.Web.ViewModels.PaginadorGenerico;
using CristalImb.Web.ViewModels.Propietarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    [Authorize(Roles = "Administrador, Empleado")]
    public class PropietarioController : Controller
    {
        private readonly AppDbContext _DbContext;
        private List<Inmueble> inmuebles;
        private PaginadorGenerico<Inmueble> _PaginadorInmuebles;
        private readonly IPropietarioService _propietarioService;
        private readonly IInmuebleService _inmuebleService;
        private readonly IInmPropietariosService _inmPropietariosService;
        

        public PropietarioController(IPropietarioService propietarioService, IInmuebleService inmuebleService, IInmPropietariosService inmPropietariosService, AppDbContext context)
        {
            _propietarioService = propietarioService;
            _inmuebleService = inmuebleService;
            _inmPropietariosService = inmPropietariosService;
            _DbContext = context;
        }

        [DisplayName("Lista de propietarios")]
        [HttpGet]
        public async Task<IActionResult> IndexPropietario()
        {
            var listPropietario = await _propietarioService.ObtenerPropietario();
            return View(await _propietarioService.ObtenerPropietario());

        }

        [HttpGet]
        public async Task<IActionResult> VerInmuebles(int id)
        {
            //inmuebles = _DbContext.inmuebles.ToList();

            ViewBag.InmuebleId = id;
            //if (!string.IsNullOrEmpty(search))
            //{
            //    foreach (var item in search.Split(new char[] { ' ' },
            //             StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        inmuebles = inmuebles.Where(x => x.Codigo.Contains(item) ||
            //                                      x.Descripcion.Contains(item) ||
            //                                      x.Direccion.Contains(item) ||
            //                                      x.Valor.Contains(item))
            //                                      .ToList();
            //        return View(inmuebles.ToList());
            //    }
            //    return View(await _inmPropietariosService.ObtenerListaInmPropietariosPorId(id));
            //}

                return View(await _inmPropietariosService.ObtenerListaInmPropietariosPorId(id));
        }

        [HttpGet]
        public IActionResult RegistrarPropietario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPropietario(PropietariosViewModel propietariosViewModel)
        {
            if (ModelState.IsValid)
            {
                Propietario propietario = new()
                {
                    Identificacion = propietariosViewModel.Identificacion,
                    Nombre = propietariosViewModel.Nombre,
                    Apellido = propietariosViewModel.Apellido,
                    Telefono = propietariosViewModel.Telefono,
                    Celular = propietariosViewModel.Celular,
                    Correo = propietariosViewModel.Correo,
                    Estado = false
                };
                try
                {
                    var identificacionExiste = await _propietarioService.identificacionPropExiste(propietario.Identificacion);
                    if (identificacionExiste != null)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "El número de identificación ya se encuentra registrado";
                        return RedirectToAction("IndexPropietario");
                    }
                    await _propietarioService.GuardarPropietario(propietario);
                    TempData["Accion"] = "GuardarPropietario";
                    TempData["Mensaje"] = "Propietario guardado con éxito.";
                    return RedirectToAction("IndexPropietario");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ingresaste un valor inválido";
                    return RedirectToAction("IndexPropietario");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return RedirectToAction("IndexPropietario");
        }

        [HttpGet]
        public async Task<IActionResult> EditarPropietario(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexPropietario");
            }
            Propietario propietario = await _propietarioService.ObtenerPropietarioId(id.Value);
            PropietariosViewModel propietariosViewModel = new()
            {
                PropietarioId = propietario.PropietarioId,
                Identificacion = propietario.Identificacion,
                Nombre = propietario.Nombre,
                Apellido = propietario.Apellido,
                Telefono = propietario.Telefono,
                Celular = propietario.Celular,
                Correo = propietario.Correo,
                Estado = propietario.Estado
            };
            return View(propietariosViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarPropietario(PropietariosViewModel propietariosViewModel)
        {
            if (ModelState.IsValid)
            {
                Propietario prop = new()
                {
                    PropietarioId = propietariosViewModel.PropietarioId,
                    Identificacion = propietariosViewModel.Identificacion,
                    Nombre = propietariosViewModel.Nombre,
                    Apellido = propietariosViewModel.Apellido,
                    Telefono = propietariosViewModel.Telefono,
                    Celular = propietariosViewModel.Celular,
                    Correo = propietariosViewModel.Correo
                    
                };

                try
                {
                    if (IdentificacionExiste(propietariosViewModel.Identificacion, propietariosViewModel.PropietarioId))
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "El número de identificación ya se encuentra registrado";
                        return RedirectToAction("IndexPropietario");
                    }
                        await _propietarioService.EditarPropietario(prop);
                        TempData["Accion"] = "EditarPropietario";
                        TempData["Mensaje"] = "Propietario editado correctamente";
                        return RedirectToAction("IndexPropietario");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ingresaste un valor inválido";
                    return RedirectToAction("IndexPropietario");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return RedirectToAction("IndexPropietario");


        }

        public async Task<IActionResult> SeleccionarInmuebles()
        {
            var selectInmuebles = await _inmuebleService.ObtenerListaInmueblesEstado();
            return View(await _inmuebleService.ObtenerListaInmueblesEstado());
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


        [HttpGet]
        public async Task<IActionResult> CrearInmPropietarios(int id)
        {
            ViewBag.ListarInmueble = new SelectList(await _inmuebleService.ObtenerListaInmueblesEstado(), "InmuebleId", "Codigo");
            InmPropietariosViewModel inmProp = new()
            {
                PropietarioId = id
            };
            return View(inmProp);
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
                            FechaInicio = DateTime.Now,
                            Estado = true,
                            asociado = "Si"


                    };
                        await _inmPropietariosService.RegistrarInmPropietarios(inmPropietarios);
                        await _inmuebleService.AlertaPropietario(inmPropietarios.InmuebleId);
                        await _propietarioService.ActivarEstadoPropierario(inmPropietarios.PropietarioId);
                        TempData["Accion"] = "GuardarPropInmueble";
                        TempData["Mensaje"] = "inmueble(s) añadido con éxito";
                    }
                    
                    return RedirectToAction("IndexPropietario");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "No se pudo registrar el inmueble";
                    return RedirectToAction("IndexPropietario");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Se encontró un error";
            return RedirectToAction("IndexPropietario");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarInmPropietario(int id, InmPropietariosViewModel inmPropietariosViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Accion"] = "Confirmación";
                    InmPropietarios inmPropietarios = await _inmPropietariosService.ObtenerInmPropietariosId(id);
                    inmPropietarios.FechaFin = DateTime.Now;
                    inmPropietarios.Estado = false;
                    inmPropietarios.asociado = "No";

                    var idPropietario = inmPropietarios.PropietarioId;

                    var guardaInmuebleId = inmPropietarios.InmuebleId;

                    await _inmPropietariosService.EditarInmPropietario(inmPropietarios);
                    await _inmuebleService.EliminarAlertaPropietario(guardaInmuebleId);
                    await _propietarioService.DesactivarEstadoPropierario(idPropietario);
                    TempData["Accion"] = "EliminarInmPropietario";
                    TempData["Mensaje"] = "Inmueble eliminado con éxito.";
                    return RedirectToAction("IndexPropietario");
                }
                catch (Exception)
                {
                    return RedirectToAction("IndexPropietario");
                }
            }
            else
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error.";
                return RedirectToAction("IndexPropietario");
            }

        }
        private bool IdentificacionExiste(int identificacion, int id)
        {
            return _DbContext.propietarios.Where(c => c.PropietarioId != id).Any(p => p.Identificacion == identificacion);
        }
    }

}
