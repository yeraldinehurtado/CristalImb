using CristalImb.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CristalImb.Business.Dtos.Inmuebles;

namespace CristalImb.Web.Controllers
{
    public class LandingController : Controller
    {
        private readonly IInmuebleService _inmuebleService;
        private readonly ITipoInmuebleService _tipoInmuebleService;
        private readonly IZonaService _zonaService;
        private readonly IServiciosInmuebleService _serviciosInmuebleService;
        private readonly IEstadosInmuebleService _estadosInmuebleService;

        public LandingController(IInmuebleService inmuebleService, ITipoInmuebleService tipoInmuebleService, IZonaService zonaService, IServiciosInmuebleService serviciosInmuebleService, IEstadosInmuebleService estadosInmuebleService)
        {
            _inmuebleService = inmuebleService;
            _tipoInmuebleService = tipoInmuebleService;
            _zonaService = zonaService;
            _serviciosInmuebleService = serviciosInmuebleService;
            _estadosInmuebleService = estadosInmuebleService;
        }

        //landing inicio
        public async Task<IActionResult> IndexLanding()
        {
            ViewData["ListaCodigos"] = new SelectList(await _inmuebleService.ObtenerListaInmueblesEstado(), "InmuebleId", "Codigo");
            ViewData["ListaCodigos"] = new SelectList(await _inmuebleService.ObtenerListaInmueblesEstado(), "InmuebleId", "Valor");
            ViewData["ListaTipos"] = new SelectList(await _tipoInmuebleService.ObtenerListaTiposEstado(), "TipoInmuebleId", "NombreTipoInm");
            ViewData["ListaEstadosInm"] = new SelectList(await _estadosInmuebleService.ObteneEstadosInmueblesEstado(), "IdEstadoInm", "NombreEstado");
            ViewData["listaZona"] = new SelectList(await _zonaService.ObtenerListaZonaEstado(), "ZonaId", "NombreZona");
            ViewData["ListaServicios"] = new SelectList(await _serviciosInmuebleService.ObtenerListaServiciosEstado(), "ServicioInmuebleId", "Nombre");

            return View(await _inmuebleService.ObtenerListaInmueblesOferta());
        }

        public async Task<IActionResult> InmueblesFiltro(InmuebleDto inmueble)
        {
            try
            {
                var CodigoExiste = await _inmuebleService.CodigoExiste(inmueble.Codigo);
                var TipoExiste = await _inmuebleService.TipoDeInmuebleExiste(inmueble.TipoId);
                var ZonaExiste = await _inmuebleService.ZonaExiste(inmueble.ZonaId);
                if (CodigoExiste != null || TipoExiste != null || ZonaExiste != null)
                {
                    return View(await _inmuebleService.ObtenerInmueble());
                }
                else
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "No hay ningún dato de búsqueda.";
                    return RedirectToAction("IndexLanding");
                }

                return View(inmueble);

            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "No hay ningún dato de búsqueda.";
                return RedirectToAction("IndexLanding");
            }
            
        }


        //landing inmuebles en venta
        [HttpGet]
        public async Task<IActionResult> InmueblesVenta()
        {
             return View(await _inmuebleService.ObtenerListaInmueblesEstado());

        }

        //inmuebles en arriendo
        [HttpGet]
        public async Task<IActionResult> InmueblesArriendo()
        {
            return View(await _inmuebleService.ObtenerListaInmueblesEstado());

        }



    }
}
