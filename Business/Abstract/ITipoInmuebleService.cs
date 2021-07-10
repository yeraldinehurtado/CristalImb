using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface ITipoInmuebleService
    {
        Task<IEnumerable<TipoInmueble>> ObtenerTipos();
    }
}
