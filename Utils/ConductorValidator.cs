using FluentValidation;
using ProyectoConduccion.Entities;

namespace ProyectoConduccion.Utils
{
    public class ConductorValidator : AbstractValidator<Conductor>
    {
        public ConductorValidator()
        {
            RuleFor(s => s.Identificacion).NotEmpty().WithMessage("Identificacion Obligatorio");
            RuleFor(s => s.Identificacion).Length(15).WithMessage("Excede los 15 caracteres");

            RuleFor(s => s.Nombre).NotEmpty().WithMessage("Nombre Obligatorio");
            RuleFor(s => s.Nombre).Length(30).WithMessage("Excede los 30 caracteres");

            RuleFor(s => s.Apellidos).NotEmpty().WithMessage("Apellidos Obligatorio");
            RuleFor(s => s.Apellidos).Length(30).WithMessage("Excede los 30 caracteres");

            RuleFor(s => s.Direccion).NotEmpty().WithMessage("Direccion Obligatorio");
            RuleFor(s => s.Direccion).Length(30).WithMessage("Excede los 30 caracteres");

            RuleFor(s => s.Telefono).NotEmpty().WithMessage("Telefono Obligatorio");
            RuleFor(s => s.Telefono).Length(15).WithMessage("Excede los 15 caracteres");

            RuleFor(s => s.MatriculaId).NotEmpty().WithMessage("MatriculaId Obligatorio");
        }
    }
}
