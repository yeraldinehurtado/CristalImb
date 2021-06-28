using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CristalImb.Business.Abstract
{
    public interface ICitaService
    {
        Task<IEnumerable<Cita>> ObtenerCita();
        Task GuardarCita(Cita cita);
        Task<Cita> ObtenerCitaId(int id);
        Task EditarCita(Cita cita);
        Task EliminarCita(int id);
    }
}