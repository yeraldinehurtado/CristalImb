using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class UsuarioIdentity
    {
        [Key, ForeignKey("IdentityUser")]
        public string UsuarioId { get; set; }

        [DisplayName("Identificación")]
        [Required(ErrorMessage = "La identificación es requerida")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Column(TypeName = "nvarchar(10)")]
        public string Identificacion { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; }

        public virtual IdentityUser IdentityUser { get; set; }

    }
}
