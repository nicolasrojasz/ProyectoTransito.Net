using System;
using System.ComponentModel.DataAnnotations;


namespace ProyectoConduccion.DTOS
{
    public class ConductorDTO
    {
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
        public String? MatriculaRegistrada { get; set; }
        public DateTime FechaExpedicion { get; set; }
    
    }
}
