using System;

using System.ComponentModel.DataAnnotations;


namespace ProyectoConduccion.DTOS
{
    public class SancioneDTO
    {
        public int Id { get; set; }

        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int ConductorId { get; set; }
        public string? NombreConductor { get; set; }
    }
}
