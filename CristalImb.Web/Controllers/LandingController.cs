using CristalImb.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CristalImb.Business.Dtos.Inmuebles;
using CristalImb.Model.DAL;
using CristalImb.Web.ViewModels.PaginadorGenerico;


namespace CristalImb.Web.Controllers
{
    public class LandingController : Controller
    {
        private readonly int _RegistrosPorPagina = 10;

        private AppDbContext _DbContext;
        private List<Inmueble> inmuebles;
        private PaginadorGenerico<Inmueble> _PaginadorInmuebles;
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

        public async Task<IActionResult> InmueblesFiltro(InmuebleDetalleArchivos inmuebleDetalleArchivos)
        {
            return View(await _inmuebleService.BuscarInmuebles(inmuebleDetalleArchivos.Inmueble.TipoId));
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


        [HttpGet]
        public async Task<IActionResult> InfoInmueble(int id)
        {

            await _inmuebleService.ObtenerInmuebleId(id);
            if (id != 0)
            {
                return View(await _inmuebleService.ObtenerInmuebleId2(id));
            }
            else
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Hubo un error realizando la operación";
                return RedirectToAction("IndexLanding");
            }

            
        }



    }
}
