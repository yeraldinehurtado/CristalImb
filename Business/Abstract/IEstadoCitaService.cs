using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IEstadoCitaService
    {
        Task<IEnumerable<EstadoCita>> ObtenerCitas();
        Task<IEnumerable<EstadoCita>> ObtenerEstadosCitaEstado();
        Task GuardarEstadoCita(EstadoCita estadoCita);
        Task<EstadoCita> ObtenerEstadoCitaId(int id);
        Task EditarEstadoCita(EstadoCita estadoCita);
    }
}
