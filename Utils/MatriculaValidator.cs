using FluentValidation;
using ProyectoConduccion.Entities;


namespace ProyectoConduccion.Utils
{
    public class MatriculaValidator:AbstractValidator<Matricula>
    {
        public MatriculaValidator()
        {
            RuleFor(s => s.Numero).Length(15).WithMessage("Excede los 15 caracteres");
            RuleFor(s => s.FechaExpedicion).NotEmpty().WithMessage("FechaExpedicion Obligatorio");
            RuleFor(s => s.FechaExpiracion).NotEmpty().WithMessage("Fecha Expiracion Obligatorio");
            RuleFor(s => s.Activo).NotEmpty().WithMessage("Estado Obligatorio");
        }
    }
}
