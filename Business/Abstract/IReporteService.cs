using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IReporteService
    {
        Task<IEnumerable<CantidadVenta>> ObtenerCantidadVentas();
        Task<IEnumerable<CantidadArriendo>> ObtenerCantidadArriendos()
    }
}
