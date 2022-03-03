using CristalImb.Business.Abstract;
using CristalImb.Business.Business;
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
    [Authorize(Roles = "Administrador")]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly ICargoService _cargoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
           
        }

        [HttpGet]
        public async Task<IActionResult> IndexEmpleado()
        {
            var listEmpleado = await _empleadoService.ObtenerEmpleado();
            return View(await _empleadoService.ObtenerEmpleado());
        }

        [HttpGet]
        public async Task<IActionResult> RegistrarEmpleadoAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEmpleado(Empleado empleado)
        {
            await _empleadoService.GuardarEmpleado(empleado);
            TempData["Accion"] = "GuardarEmpleado";
            TempData["Mensaje"] = "Empleado guardado con éxito.";

            return RedirectToAction("IndexEmpleado");
        }

        [HttpGet]
        public async Task<IActionResult> EditarEmpleado(int id = 0)
        {
            return View(await _empleadoService.ObtenerEmpleadoId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarEmpleado(int? id, Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _empleadoService.GuardarEmpleado(empleado);
                    return RedirectToAction("IndexEmpleado");
                }
                else
                {
                    if (id != empleado.EmpleadoId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexEmpleado");
                    }
                    try
                    {
                        await _empleadoService.EditarEmpleado(empleado);
                        TempData["Accion"] = "EditarEmpleado";
                        TempData["Mensaje"] = "Empleado editado con éxito.";
                        return RedirectToAction("IndexEmpleado");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexEmpleado");
                    }
                }
            }
            else
            {
                return View(empleado);
            }

        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexTipoInmuebles");
            }
            Empleado empleado = await _empleadoService.ObtenerEmpleadoId(id.Value);
            try
            {
                if (empleado.Estado == true)
                    empleado.Estado = false;
                else if (empleado.Estado == false)
                    empleado.Estado = true;

                await _empleadoService.EditarEmpleado(empleado);
                TempData["Accion"] = "EditarEstado";
                TempData["Mensaje"] = "Estado editardo correctamente";
                return RedirectToAction("IndexEmpleado");
            }
            catch (Exception)
            {
                return RedirectToAction("IndexEmpleado");
            }
        }

    }
}

