﻿using CristalImb.Business.Abstract;
using CristalImb.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class PropietarioController : Controller
    {
        private readonly IPropietarioService _propietarioService;
        public PropietarioController(IPropietarioService propietarioService)
        {
            _propietarioService = propietarioService;
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
    }
}