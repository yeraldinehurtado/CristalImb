using CristalImb.Business.Abstract;
using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.TipoInmuebles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    [Authorize(Roles = "Admin, Empleado")]
    public class TipoInmueblesController : Controller
    {
        private readonly ITipoInmuebleService _tipoInmuebleService;

        public TipoInmueblesController(ITipoInmuebleService tipoInmuebleService)
        {
            _tipoInmuebleService = tipoInmuebleService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexTipoInmuebles()
        {
            var listTipoInmueble = await _tipoInmuebleService.ObtenerTipos();
            return View(await _tipoInmuebleService.ObtenerTipos());

        }

        [HttpGet]
        public IActionResult RegistrarTipoInmueble()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTipoInmueble(TipoInmueblesViewModel tipoInmueblesViewModel)
        {
            if (ModelState.IsValid)
            {
                TipoInmuebles tipoInmuebles = new()
                {
                    NombreTipoInm = tipoInmueblesViewModel.NombreTipoInm,
                    Estado = true
                };
                try
                {
                    var nombreExiste = await _tipoInmuebleService.nombreTipoExiste(tipoInmuebles.NombreTipoInm);
                    if (nombreExiste != null)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Este nombre de tipo de inmueble ya se encuentra registrado";
                        return RedirectToAction("IndexTipoInmuebles");
                    }
                    await _tipoInmuebleService.GuardarTipoInmueble(tipoInmuebles);
                    TempData["Accion"] = "GuardarTipoInmueble";
                    TempData["Mensaje"] = "Tipo de inmueble guardado con éxito.";
                    return RedirectToAction("IndexTipoInmuebles");
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "Ingresaste un valor inválido";
                    return RedirectToAction("IndexTipoInmuebles");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Ingresaste un valor inválido";
            return RedirectToAction("IndexTipoInmuebles");
        }

        [HttpGet]
        public async Task<IActionResult> EditarTipoInmueble(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexTipoInmuebles");
            }
            TipoInmuebles tipoInmuebles = await _tipoInmuebleService.ObtenerTipoInmuebleId(id.Value);
            TipoInmueblesViewModel tipoInmueblesViewModel = new()
            {
                TipoInmuebleId = tipoInmuebles.TipoInmuebleId,
                NombreTipoInm = tipoInmuebles.NombreTipoInm,
                Estado = tipoInmuebles.Estado
            };
            return View(tipoInmueblesViewModel);
        }
    

    [HttpPost]
    public async Task<IActionResult> EditarTipoInmueble(TipoInmueblesViewModel tipoInmueblesViewModel)
    {
        if (ModelState.IsValid)
        {
            TipoInmuebles tipoInmuebles = new()
            {
                TipoInmuebleId = tipoInmueblesViewModel.TipoInmuebleId,
                NombreTipoInm = tipoInmueblesViewModel.NombreTipoInm,
                Estado = true
            };

            try
            {
                await _tipoInmuebleService.EditarTipoInmueble(tipoInmuebles);
                TempData["Accion"] = "EditarTipoInmueble";
                TempData["Mensaje"] = "Tipo de inmueble editado correctamente";
                return RedirectToAction("IndexTipoInmuebles");
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ingresaste un valor inválido";
                return RedirectToAction("IndexTipoInmuebles");
            }
        }
        TempData["Accion"] = "Error";
        TempData["Mensaje"] = "Ingresaste un valor inválido";
        return RedirectToAction("IndexTipoInmuebles");


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
        TipoInmuebles tipoInmuebles = await _tipoInmuebleService.ObtenerTipoInmuebleId(id.Value);
        try
        {
            if (tipoInmuebles.Estado == true)
                tipoInmuebles.Estado = false;
            else if (tipoInmuebles.Estado == false)
                tipoInmuebles.Estado = true;

            await _tipoInmuebleService.EditarTipoInmueble(tipoInmuebles);
            TempData["Accion"] = "EditarEstado";
            TempData["Mensaje"] = "Estado editado correctamente";
            return RedirectToAction("IndexTipoInmuebles");
        }
        catch (Exception)
        {
            return RedirectToAction("IndexTipoInmuebles");
        }
    }

}
}
