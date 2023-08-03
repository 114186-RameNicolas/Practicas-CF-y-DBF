using Api_DbFirst.Dtos;
using Clases.Context;
using Clases.Models;
using MediatR;

namespace Api_DbFirst.Service.EmpleadoBusiness.Command
{
    public class PostEmpleado
    {
        public class PostEmpleadoCommand : IRequest<Empleado>
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string DNI { get; set; }
            public Guid SucursalId { get; set; }
            public string NombreSucursal {get; set; }
            public Guid CargoId { get; set; }
            public string NombreCargo { get; set; }
            public Guid JefeId { get; set; }

        }

        public class PostEmpleadoCommandHandler : IRequestHandler<PostEmpleadoCommand, Empleado>
        {
            private readonly ContextBD _contextBd;

            public PostEmpleadoCommandHandler(ContextBD contextBd)
            {
                _contextBd = contextBd;
            }

            public async Task<Empleado> Handle(PostEmpleadoCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var empleado = new Empleado();
                    empleado.Id = Guid.NewGuid();
                    empleado.Nombre = request.Nombre;
                    empleado.Apellido = request.Apellido;
                    empleado.DNI = request.DNI;
                    empleado.Sucursal.Id = request.SucursalId;
                    empleado.Sucursal.Nombre = request.NombreSucursal;
                    empleado.Cargo.Id = request.CargoId;
                    empleado.Cargo.Nombre = request.NombreCargo;
                    empleado.FechaAlta = DateTime.Now.ToUniversalTime();

                    await _contextBd.AddAsync(empleado);
                    await _contextBd.SaveChangesAsync();

                    return empleado;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
