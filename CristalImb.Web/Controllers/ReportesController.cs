using CristalImb.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CristalImb.Web.Controllers
{
    [Authorize(Roles = "Administrador, Empleado")]
    public class ReportesController : Controller
    {
        private readonly IPropietarioService _propietarioService;
        private readonly IInmuebleService _inmuebleService;
        private readonly IInmPropietariosService _inmPropietariosService;

        public ReportesController(IPropietarioService propietarioService, IInmuebleService inmuebleService, IInmPropietariosService inmPropietariosService)
        {
            _propietarioService = propietarioService;
            _inmuebleService = inmuebleService;
            _inmPropietariosService = inmPropietariosService;
        }

        [DisplayName("Historial de propietarios")]
        [HttpGet]
        public async Task<IActionResult> HistorialPropietarios()
        {
            return View(await _inmPropietariosService.ObtenerInmPropietarios());
        }

        [DisplayName("Historial de Inmuebles")]
        [HttpGet]
        public async Task<IActionResult> HistorialInmuebles(int id)
        {
            return View(await _inmPropietariosService.ObtenerInmPropietarios());
        }
    }
}
