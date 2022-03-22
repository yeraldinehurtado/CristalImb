using System;
using CristalImb.Business.Abstract;
using CristalImb.Model.DAL;
using CristalImb.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CristalImb.Business.Dtos.Inmuebles;

namespace CristalImb. Business.Business
{
    public class InmuebleService : IInmuebleService
    {
        private readonly AppDbContext _context;
        public InmuebleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inmueble>> ObtenerInmueble()
        {
            return await _context.inmuebles.Include(p => p.TipoInmuebles).Include(c => c.Zona).Include(c => c.ServiciosInmueble).Include(f => f.EstadosInmueble).ToListAsync();
        }

        public async Task<IEnumerable<Inmueble>> ObtenerListaInmueblesEstado()
        {
            return await _context.inmuebles.Where(s => s.Estado == true).ToListAsync();
        }
        public async Task<IEnumerable<InmuebleDetalleArchivos>> ObtenerListaInmueblesOferta()
        {
            return await _context.inmuebleDetalleArchivos.Where(s => s.Inmueble.oferta == true && s.Inmueble.IdEstadoInm==3 && s.Inmueble.Estado == true).ToListAsync();
        }

        public async Task GuardarInmueble1(Inmueble inmueble)
        {
            _context.Add(inmueble);
            await _context.SaveChangesAsync();
        }

        public async Task<int?> GuardarInmueble(InmuebleDto inmuebleDto)
        {
            Inmueble inmueble = new()
            {

                Area = inmuebleDto.Area,
                Codigo = inmuebleDto.Codigo,
                Descripcion = inmuebleDto.Descripcion,
                Direccion = inmuebleDto.Direccion,
                Estado = true,
                IdEstadoInm = inmuebleDto.IdEstadoInm,
                InmuebleId = inmuebleDto.InmuebleId,
                oferta = inmuebleDto.oferta,
                ServicioInmuebleId = inmuebleDto.ServicioInmuebleId,
                TipoId = inmuebleDto.TipoId,
                Valor = inmuebleDto.Valor,
                ZonaId = inmuebleDto.ZonaId,




            };
            _context.Add(inmueble);
            if (await GuardarCambios())
                return inmueble.InmuebleId;
            else
            {
                return null;
            }
        }

        public void CrearInmuebleDetalleArchivos(int inmuebleId, string nombreArchivo)
        {

            InmuebleDetalleArchivos inmuebleDetalleArchivos = new()
            {
                InmuebleId = inmuebleId,
                NombreArchivo = nombreArchivo
            };
            _context.Add(inmuebleDetalleArchivos);

        }
        public async Task EliminarInmuebleDetalleArchivo(int id)
        {
            var inmImagen = await ObtenerInmuebleImgId(id);
            _context.Remove(inmImagen);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }




        public async Task<Inmueble> ObtenerInmuebleId(int id)
        {
            return await _context.inmuebles.FirstOrDefaultAsync(x => x.InmuebleId == id);
        }

        public async Task<InmuebleDetalleArchivos> ObtenerImagenesId(int id)
        {
            return await _context.inmuebleDetalleArchivos.FirstOrDefaultAsync(e => e.InmuebleDetalleId == id);
        }
        public async Task<IEnumerable<InmuebleDetalleArchivos>> ObtenerInmuebleImgId(int id)
        {
            return await _context.inmuebleDetalleArchivos.Include(i => i.Inmueble).Where(s => s.InmuebleId == id).ToListAsync();
        }

        public async Task EditarImagenesInm(InmuebleDetalleArchivos inmuebleDetalleArchivos)
        {
            _context.Update(inmuebleDetalleArchivos);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarImagenesInm(int id)
        {
            var inmuebleDetalleArchivos = await ObtenerImagenesId(id);
            _context.Remove(inmuebleDetalleArchivos);
            await _context.SaveChangesAsync();
        }
        public async Task EditarInmueble(Inmueble inmueble)
        {
            _context.Update(inmueble);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarInmueble(int id)
        {
            var inmueble = await ObtenerInmuebleId(id);
            _context.Remove(inmueble);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarInmProp(Propietario propietario, Inmueble inmueble)
        {
            _context.Add(propietario);
            _context.Add(inmueble);
            await _context.SaveChangesAsync();
        }


        public async Task<Inmueble> CodigoExiste(string codigo)
        {
            return await _context.inmuebles.FirstOrDefaultAsync(x => x.Codigo == codigo);
        }
        public async Task<IEnumerable<Inmueble>> CodigoExisteEditar(string codigo)
        {
            return await _context.inmuebles.Where(c => c.Codigo == codigo).ToListAsync();
        }
        public async Task<Inmueble> TipoDeInmuebleExiste(int tipo)
        {
            return await _context.inmuebles.FirstOrDefaultAsync(x => x.TipoId == tipo);
        }
        public async Task<Inmueble> ZonaExiste(int zona)
        {
            return await _context.inmuebles.FirstOrDefaultAsync(x => x.ZonaId == zona);
        }

        public async Task<IEnumerable<InmuebleDetalleArchivos>> BuscarInmuebles(int tipo)
        {
            return await _context.inmuebleDetalleArchivos.Where(s => s.Inmueble.TipoId== tipo).ToListAsync();
        }
    }
}
