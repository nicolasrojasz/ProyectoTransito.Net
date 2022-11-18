using FluentValidation;
using ProyectoConduccion.Entities;


namespace ProyectoConduccion.Utils
{
    public class SancionesValidator: AbstractValidator<Sancione>
    {
        public SancionesValidator()
        {
           
            RuleFor(s => s.ConductorId).NotEmpty().WithMessage("ConductorId Obligatorio");
           
        }
    }
}
