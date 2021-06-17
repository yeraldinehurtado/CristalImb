using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [DisplayName("Nombre rol")]
        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        public string NombreRol { get; set; }

        [DisplayName("Módulo")]
        [Required(ErrorMessage = "El módulo es obligatorio")]
        public string Modulo { get; set; }

        public int Permisos { get; set; }
        public string Estado { get; set; }

    }
}
