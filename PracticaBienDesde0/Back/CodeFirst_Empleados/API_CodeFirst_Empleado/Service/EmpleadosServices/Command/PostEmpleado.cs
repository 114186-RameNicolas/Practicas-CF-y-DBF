using API_CodeFirst_Empleado.Data;
using API_CodeFirst_Empleado.Dtos;
using API_CodeFirst_Empleado.Models;
using API_CodeFirst_Empleado.Service.EmpleadosServices.Validations;
using MediatR;
using System.Net;

namespace API_CodeFirst_Empleado.Service.EmpleadosServices.Command
{
    public class PostEmpleado
    {
        public class PostEmpleadoCommand : IRequest<Empleado>
        {
            public string Nombre { get; set; }
            public string Apelldio { get; set; }
            public string DNI { get; set; }
            public SucursalDto Sucursal { get; set; }
            public CargoDto Cargo { get; set; }
            public DateTime FechaAlta { get; set; }

        }

        public class PostEmpleadoCommandHandler : IRequestHandler<PostEmpleadoCommand , Empleado>
        {
            private readonly ApplicationContext _context;
            private readonly PostEmpleadoValidation _validation;

            public PostEmpleadoCommandHandler(ApplicationContext context, PostEmpleadoValidation validationRules)
            {
                _context = context;
                _validation = validationRules;
            }

            public async Task<Empleado> Handle(PostEmpleadoCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _validation.Validate(request);
                    using (var transaction = _context.Database.BeginTransaction())
                    {

                        Empleado empleado = new Empleado();
                        empleado.Id = Guid.NewGuid();
                        empleado.Nombre = request.Nombre;
                        empleado.Apellido = request.Apelldio;
                        empleado.DNI = request.DNI;

                        // Obten las instancias existentes de Sucursal, Ciudad y Cargo
                        var sucursal = await _context.Sucursal.FindAsync(request.Sucursal.Id);
                        var ciudad = await _context.Ciudad.FindAsync(request.Sucursal.Ciudad.Id);
                        var cargo = await _context.Cargo.FindAsync(request.Cargo.Id);

                        // Asigna las instancias obtenidas a las propiedades del empleado
                        empleado.Sucursal = sucursal;
                        sucursal.Ciudad = ciudad;
                        empleado.Cargo = cargo;

                        empleado.FechaAlta = request.FechaAlta;

                        await _context.Empleado.AddAsync(empleado);
                        await _context.SaveChangesAsync();


                        transaction.Commit();

                        return empleado;
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                 
            }
        }
    }
}
