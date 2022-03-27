using CristalImb.Business.Abstract;
using CristalImb.Business.Business;
using CristalImb.Business.Dtos.Inmuebles;
using CristalImb.Web.ViewModels.Inmuebles;
using CristalImb.Model.Entities;
using CristalImb.Web.ViewModels.InmPropietarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CristalImb.Web.Controllers
{
    [Authorize(Roles = "Administrador, Empleado")]
    public class InmuebleController : Controller
    {
        private readonly IPropietarioService _propietarioService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IInmuebleService _inmuebleService;
        private readonly ITipoInmuebleService _tipoInmuebleService;
        private readonly IZonaService _zonaService;
        private readonly IEstadosInmuebleService _estadosInmuebleService;
        private readonly IServiciosInmuebleService _serviciosInmuebleService;
        private readonly IInmPropietariosService _inmPropietariosService;

        public InmuebleController(IWebHostEnvironment webHostEnvironment, IInmuebleService inmuebleService, ITipoInmuebleService tipoInmuebleService, IZonaService zonaService, IEstadosInmuebleService estadosInmuebleService, IPropietarioService propietarioService, IServiciosInmuebleService serviciosInmuebleService, IInmPropietariosService inmPropietariosService)
        {
            _webHostEnvironment = webHostEnvironment;
            _inmuebleService = inmuebleService;
            _tipoInmuebleService = tipoInmuebleService;
            _zonaService = zonaService;
            _estadosInmuebleService = estadosInmuebleService;
            _serviciosInmuebleService = serviciosInmuebleService;
            _inmPropietariosService = inmPropietariosService;
            _propietarioService = propietarioService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexInmueble()
        {
            var listInmueble = await _inmuebleService.ObtenerInmueble();
            return View(await _inmuebleService.ObtenerInmueble());
        }

        [HttpGet]
        public async Task<IActionResult> RegistrarInmuebleAsync()
        {

            ViewData["ListaTipos"] = new SelectList(await _tipoInmuebleService.ObtenerListaTiposEstado(), "TipoInmuebleId", "NombreTipoInm");
            ViewData["ListaEstadosInm"] = new SelectList(await _estadosInmuebleService.ObteneEstadosInmueblesEstado(), "IdEstadoInm", "NombreEstado");
            ViewData["listaZona"] = new SelectList(await _zonaService.ObtenerListaZonaEstado(), "ZonaId", "NombreZona");
            ViewData["ListaServicios"] = new SelectList(await _serviciosInmuebleService.ObtenerListaServiciosEstado(), "ServicioInmuebleId", "Nombre");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegistrarInmueble(InmuebleDto inmuebleDto)
        {
            try
            {
                var CodigoExiste = await _inmuebleService.CodigoExiste(inmuebleDto.Codigo);
                if (CodigoExiste != null)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "El código del inmueble ya se encuentra registrado";
                    return RedirectToAction("IndexInmueble");
                }

                if (inmuebleDto.Files != null)
                {
                    inmuebleDto.Estado = true;
                    var idInmueble = await _inmuebleService.GuardarInmueble(inmuebleDto);
                    if (idInmueble != null)
                    {
                        string uniqueFileName;
                        foreach (var archivo in inmuebleDto.Files)
                        {
                            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "imagenesInmueble");
                            //uniqueFileName = Guid.NewGuid().ToString() + "_" + archivo.FileName;
                            uniqueFileName = DateTime.Now.ToString("yyyymmssfff") + "_" + (archivo.FileName).Trim(); //otra opción
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            // Use CopyTo() method provided by IFormFile interface to
                            // copy the file to wwwroot/images folder
                            // archivo.CopyTo(new FileStream(filePath, FileMode.Create));
                            using (var fileStream = new FileStream(filePath, FileMode.Create))//Guardar imagen
                            {
                                await archivo.CopyToAsync(fileStream);
                            }
                            _inmuebleService.CrearInmuebleDetalleArchivos(idInmueble.Value, uniqueFileName);
                        }

                        
                        if (await _inmuebleService.GuardarCambios())
                        {
                            await _inmuebleService.PrimerImagen(idInmueble.Value);
                            TempData["Accion"] = "GuardarInmueble";
                            TempData["Mensaje"] = "Inmueble guardado con éxito.";
                            return RedirectToAction("IndexInmueble");

                        }


                    }
                    return View(inmuebleDto);


                }
                return View(inmuebleDto);


            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Ingresaste un valor inválido";
                return RedirectToAction("IndexInmueble");
            }
        
    }

        [HttpGet]
        public async Task<IActionResult> EditarInmueble(int id = 0)
        {
            ViewData["ListaTipos"] = new SelectList(await _tipoInmuebleService.ObtenerListaTiposEstado(), "TipoInmuebleId", "NombreTipoInm");
            ViewData["ListaEstadosInm"] = new SelectList(await _estadosInmuebleService.ObteneEstadosInmueblesEstado(), "IdEstadoInm", "NombreEstado");
            ViewData["listaZona"] = new SelectList(await _zonaService.ObtenerListaZonaEstado(), "ZonaId", "NombreZona");
            ViewData["ListaServicios"] = new SelectList(await _serviciosInmuebleService.ObtenerListaServiciosEstado(), "ServicioInmuebleId", "Nombre");
            return View(await _inmuebleService.ObtenerInmuebleId(id));
        }
        
        [HttpPost]
        public async Task<IActionResult> EditarInmueble(int? id, Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                
                if (id == 0)
                {
                    await _inmuebleService.GuardarInmueble1(inmueble);
                    return RedirectToAction("IndexInmueble");
                }
                else
                {
                    if (id != inmueble.InmuebleId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexInmueble");
                    }
                    try
                    {
                        await _inmuebleService.EditarInmueble(inmueble);
                        TempData["Accion"] = "EditarInmueble";
                        TempData["Mensaje"] = "Inmueble editado con éxito.";
                        return RedirectToAction("IndexInmueble");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexInmueble");
                    }
                }
            }
            else
            {
                return View(inmueble);
            }

        }
        

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexInmueble");
            }
            Inmueble inmueble = await _inmuebleService.ObtenerInmuebleId(id.Value);
            try
            {
                if (inmueble.Estado == true)
                    inmueble.Estado = false;
                else if (inmueble.Estado == false)
                    inmueble.Estado = true;

                await _inmuebleService.EditarInmueble(inmueble);
                TempData["Accion"] = "EditarEstado";
                TempData["Mensaje"] = "Estado editardo correctamente";
                return RedirectToAction("IndexInmueble");
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error";
                return RedirectToAction("IndexInmueble");
            }
        }

        public async Task<IActionResult> DetallesInmueble(int? id)
        {
            if (id != null)
            {
                return View(await _inmuebleService.ObtenerInmuebleId(id.Value));
            }

            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Hubo un error realizando la operación";
            return RedirectToAction("IndexInmueble");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarInmueble(int id)
        {
            try
            {
                TempData["Accion"] = "Confirmación";
                await _inmuebleService.EliminarInmueble(id);
                return RedirectToAction(nameof(IndexInmueble));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Hubo un error realizando la operación";
                return RedirectToAction("IndexInmueble");
            }

        }

        public async Task<IActionResult> VerPropietarios(int id)
        {
            ViewBag.PropietarioId = id;
            return View(await _inmPropietariosService.ObtenerListaInmPropietariosPorId2(id));
        }

        //------------------------------

        public async Task<IActionResult> VerImagenes(int id)
        {
            ViewBag.InmuebleDetalleId = id;
            return View(await _inmuebleService.ObtenerInmuebleImgId(id));
        }

        //[HttpPost]
        //public async Task<IActionResult> EliminarImagen(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            TempData["Accion"] = "Confirmación";
        //            InmuebleDetalleArchivos inmuebleDetalleArch = (InmuebleDetalleArchivos)await _inmuebleService.ObtenerInmuebleImgId(id);
        //            await _inmuebleService.EliminarInmuebleDetalleArchivo(id);
        //            TempData["Accion"] = "EliminarInmueble";
        //            TempData["Mensaje"] = "Imagen eliminada exitosamente";
        //            return RedirectToAction("IndexInmueble");
        //        }
        //        catch (Exception)
        //        {
        //            return RedirectToAction("IndexInmueble");
        //        }
        //    }
        //    else
        //    {
        //        TempData["Accion"] = "Error";
        //        TempData["Mensaje"] = "Error.";
        //        return RedirectToAction("IndexInmueble");
        //    }

        //}



        [HttpPost]
        public async Task<IActionResult> EliminarImagen(int id)
        {

            if (id == 0)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Error.";
                return RedirectToAction("IndexInmueble");
            }
            else
            {

                await _inmuebleService.EliminarImagenesInm(id);

                TempData["Accion"] = "EliminarImagenesInm";
                TempData["Mensaje"] = "Imagen eliminada con éxito.";
                return RedirectToAction("IndexInmueble");
            }

            

            

        }

        [HttpGet]
        public IActionResult AgregarImagen(int id)
        {
            InmuebleDetalleDto inmu = new()
            {
                InmuebleId = id
            };
            return View(inmu);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarImagen(InmuebleDetalleDto inmuebleDetalleDto)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (inmuebleDetalleDto.InmuebleId != 0)
                    {
                        string uniqueFileName;
                        foreach (var archivo in inmuebleDetalleDto.Files)
                        {
                            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "imagenesInmueble");
                            //uniqueFileName = Guid.NewGuid().ToString() + "_" + archivo.FileName;
                            uniqueFileName = DateTime.Now.ToString("yyyymmssfff") + "_" + (archivo.FileName).Trim(); //otra opción
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            // Use CopyTo() method provided by IFormFile interface to
                            // copy the file to wwwroot/images folder
                            // archivo.CopyTo(new FileStream(filePath, FileMode.Create));
                            using (var fileStream = new FileStream(filePath, FileMode.Create))//Guardar imagen
                            {
                                await archivo.CopyToAsync(fileStream);
                            }

                            InmuebleDetalleArchivos inmuebleDetalleArchivos = new()
                            {
                                InmuebleId = inmuebleDetalleDto.InmuebleId,
                                NombreArchivo = uniqueFileName
                            };
                            await _inmuebleService.GuardarImagenes(inmuebleDetalleArchivos);


                        }
                        TempData["Accion"] = "CrearInmuebleDetalleArchivos";
                        TempData["Mensaje"] = "Imagen guardada con éxito.";
                        return RedirectToAction("IndexInmueble");


                    }
                    return View(inmuebleDetalleDto);


                    
                }
                catch (Exception)
                {
                    TempData["Accion"] = "Error";
                    TempData["Mensaje"] = "No se pudo registrar la imagen";
                    return RedirectToAction("IndexInmueble");
                }
            }
            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Se encontró un error";
            return RedirectToAction("IndexInmueble");
        }

    }
}
