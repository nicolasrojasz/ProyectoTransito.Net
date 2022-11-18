using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectoConduccion.Entities
{
    public partial class Matricula
    {
        public Matricula()
        {
            Conductors = new HashSet<Conductor>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(15, ErrorMessage = "Longitud maxima de 15 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public DateTime FechaExpedicion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public DateTime FechaExpiracion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public bool Activo { get; set; }

        public virtual ICollection<Conductor> Conductors { get; set; }
    }
}
