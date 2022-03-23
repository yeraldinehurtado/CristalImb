using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Business.Dtos.Inmuebles
{
    public class InmuebleDetalleDto
    {
        public int InmuebleId { get; set; }
        //public List<IFormFile> Files { get; set; }
        public List<IFormFile> Files { get; set; }


    }
}
