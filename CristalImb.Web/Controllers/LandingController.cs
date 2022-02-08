using CristalImb.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    public class LandingController : Controller
    {
        private readonly IInmuebleService _inmuebleService;
        private readonly ITipoInmuebleService _tipoInmuebleService;
        private readonly IZonaService _zonaService;
        private readonly IServiciosInmuebleService _serviciosInmuebleService;

        public LandingController(IInmuebleService inmuebleService, ITipoInmuebleService tipoInmuebleService, IZonaService zonaService, IServiciosInmuebleService serviciosInmuebleService)
        {
            _inmuebleService = inmuebleService;
            _tipoInmuebleService = tipoInmuebleService;
            _zonaService = zonaService;
            _serviciosInmuebleService = serviciosInmuebleService;
        }

        //landing inicio
        public async Task<IActionResult> IndexLanding()
        {
            return View(await _inmuebleService.ObtenerListaInmueblesOferta());
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
