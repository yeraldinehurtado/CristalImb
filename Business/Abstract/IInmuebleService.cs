using CristalImb.Business.Dtos.Inmuebles;
using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IInmuebleService
    {
        Task<IEnumerable<Inmueble>> ObtenerInmueble();
        Task<IEnumerable<Inmueble>> ObtenerListaInmueblesEstado();
        Task<IEnumerable<Inmueble>> ObtenerListaInmueblesOferta();
        Task<IEnumerable<Inmueble>> ObtenerListaInmueblesArriendo();
        Task<IEnumerable<Inmueble>> ObtenerListaInmueblesVenta();
        Task<IEnumerable<InmuebleDetalleArchivos>> ObtenerInmuebleId2(int id);
        Task GuardarInmueble1(Inmueble inmueble);
        Task<int?> GuardarInmueble(InmuebleDto inmuebleDto);
        Task<Inmueble> ObtenerInmuebleId(int id);
        Task EditarInmueble(Inmueble inmueble);
        Task EliminarInmueble(int id);
        Task AgregarInmProp(Propietario propietario, Inmueble inmueble);
        Task<Inmueble> CodigoExiste(string codigo);
        Task<Inmueble> CodigoExisteEditar(string codigo, int inmuebleId);
        Task<bool> GuardarCambios();
        void CrearInmuebleDetalleArchivos(int inmuebleId, string nombreArchivo);
        Task EliminarInmuebleDetalleArchivo(int id);
        Task<Inmueble> TipoDeInmuebleExiste(int tipo);
        Task<Inmueble> ZonaExiste(int zona);
        Task<IEnumerable<InmuebleDetalleArchivos>> ObtenerInmuebleImgId(int id);
        Task<IEnumerable<InmuebleDetalleArchivos>> BuscarInmuebles(int tipo);
        Task<InmuebleDetalleArchivos> ObtenerImagenesId(int id);
        Task EditarImagenesInm(InmuebleDetalleArchivos inmuebleDetalleArchivos);
        Task EliminarImagenesInm(int id);
        Task GuardarImagenes(InmuebleDetalleArchivos inmuebleDetalleArchivos);
        Task PrimerImagen(int id);
        Task AlertaPropietario(int id);
        Task EliminarAlertaPropietario(int id);
        Task<InmPropietarios> ObtenerInmPropId(int id);
        Task PrimerImagenAgregar(int id);



    }
}
