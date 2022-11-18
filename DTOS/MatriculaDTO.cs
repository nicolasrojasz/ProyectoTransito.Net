using System;
using System.ComponentModel.DataAnnotations;


namespace ProyectoConduccion.DTOS
{
    public class MatriculaDTO
    {
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
    }
}
