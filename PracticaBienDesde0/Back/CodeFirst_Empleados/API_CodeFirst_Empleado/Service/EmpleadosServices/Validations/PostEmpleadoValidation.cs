using FluentValidation;
using static API_CodeFirst_Empleado.Service.EmpleadosServices.Command.PostEmpleado;

namespace API_CodeFirst_Empleado.Service.EmpleadosServices.Validations
{
    public class PostEmpleadoValidation : AbstractValidator<PostEmpleadoCommand>
    {
        public PostEmpleadoValidation()
        {
            RuleFor(e => e.Nombre).NotEmpty().WithMessage("Ingresar Nombre");
            RuleFor(e => e.Apelldio).NotEmpty().WithMessage("Ingresar Apellido");
            RuleFor(e => e.DNI).NotEmpty().WithMessage("Ingrear DNI");
            RuleFor(e => e.FechaAlta).NotEmpty().WithMessage("Ingresar Fecha de alta");
        }
    }


}
