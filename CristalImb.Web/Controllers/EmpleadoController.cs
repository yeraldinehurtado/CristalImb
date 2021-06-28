using CristalImb.Business.Abstract;
using CristalImb.Business.Business;
using CristalImb.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
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
        public IActionResult RegistrarEmpleado()
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

        public async Task<IActionResult> DetallesEmpleados(int? id)
        {
            if (id != null)
            {
                return View(await _empleadoService.ObtenerEmpleadoId(id.Value));
            }

            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Hubo un error realizando la operación";
            return RedirectToAction("IndexEmpleado");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarEmpleado(int id)
        {
            try
            {
                TempData["Accion"] = "Confirmación";
                await _empleadoService.EliminarEmpleado(id);
                return RedirectToAction(nameof(IndexEmpleado));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Hubo un error realizando la operación";
                return RedirectToAction("IndexEmpleado");
            }

        }
    }
}
