using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectoConduccion.Entities
{
    public partial class Conductor
    {
        public Conductor()
        {
            Sanciones = new HashSet<Sancione>();
        }

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(15, ErrorMessage = "Longitud maxima de 15 caracteres")]
        public string Identificacion { get; set; }
       
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, ErrorMessage = "Longitud maxima de 30 caracteres")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, ErrorMessage = "Longitud maxima de 30 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, ErrorMessage = "Longitud maxima de 30 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(15, ErrorMessage = "Longitud maxima de 15 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int MatriculaId { get; set; }

        public virtual Matricula Matricula { get; set; }
        public virtual ICollection<Sancione> Sanciones { get; set; }
    }
}
