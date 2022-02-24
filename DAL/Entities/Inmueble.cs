﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class Inmueble
    {
        [Key]
        public int InmuebleId { get; set; }
        [Required(ErrorMessage = "El código es obligatorio")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Tipo de inmueble")]
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public int TipoId { get; set; }

        [DisplayName("Estado inmueble")]
        [Required(ErrorMessage = "El estado de inmueble es obligatorio")]
        public int IdEstadoInm { get; set; }

        [DisplayName("Zona inmueble")]
        [Required(ErrorMessage = "La zona del inmueble es obligatoria")]
        public int ZonaId { get; set; }

        [DisplayName("Servicio inmueble")]
        [Required(ErrorMessage = "El servicio es obligatorio")]
        public int ServicioInmuebleId { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        [RegularExpression("^[0-9]*$*.*,", ErrorMessage = "Ingrese valores numéricos")]
        [UIHint("Currency")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public string Valor { get; set; }

        [DisplayName("Área")]
        [Required(ErrorMessage = "El area es obligatorio")]
        public string Area { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La dirección es obligatorio")]
        public string Direccion { get; set; }

        public bool oferta { get; set; }

        public bool Estado { get; set; }

        public virtual EstadosInmueble EstadosInmueble { get; set; }
        public virtual TipoInmuebles TipoInmuebles { get; set; }
        public virtual Zona Zona { get; set; }
        public virtual ServiciosInmueble ServiciosInmueble { get; set; }
        public virtual List<InmPropietarios> InmPropietario { get; set; }
        public virtual List<Cita> citas { get; set; }
    }
}
