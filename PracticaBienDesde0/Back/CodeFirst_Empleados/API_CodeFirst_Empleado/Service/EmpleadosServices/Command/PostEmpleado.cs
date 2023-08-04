using API_CodeFirst_Empleado.Data;
using API_CodeFirst_Empleado.Dtos;
using API_CodeFirst_Empleado.Models;
using MediatR;
using System.Net;

namespace API_CodeFirst_Empleado.Service.EmpleadosServices.Command
{
    public class PostEmpleado
    {
        public class PostEmpleadoCommand : IRequest<Empleado>
        {
            public Guid Id { get; set; }
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

            public PostEmpleadoCommandHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<Empleado> Handle(PostEmpleadoCommand request, CancellationToken cancellationToken)
            {
                try
                {
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
