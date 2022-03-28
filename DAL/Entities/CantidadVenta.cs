﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class CantidadVenta
    {
        [Key]
        public int IdCantidadVenta { get; set; }

        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }





    }
}
