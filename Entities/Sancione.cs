using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectoConduccion.Entities
{
    public partial class Sancione
    {
        public int Id { get; set; }

        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int ConductorId { get; set; }
        public virtual Conductor Conductor { get; set; }
    }
}
