using API_CodeFirst_Empleado.Data;
using API_CodeFirst_Empleado.Dtos;
using API_CodeFirst_Empleado.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API_CodeFirst_Empleado.Service.EmpleadosServices.Command
{
    public class PutEmpleado
    {
        public class PutEmpleadoCommand : IRequest<Empleado>
        {
            public Guid Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string Apellido { get; set; } = null!;
            public string DNI { get; set; } = null!;
            public SucursalDto Sucursal { get; set; }
            public CargoDto Cargo { get; set; } 
            public DateTime FechaAlta { get; set; }
        }

        public class PutEmpleadoCommandHandler : IRequestHandler<PutEmpleadoCommand, Empleado>
        {
            private readonly ApplicationContext _context;
            
            public PutEmpleadoCommandHandler(ApplicationContext applicationContext)
            {
                _context = applicationContext;
            }

            public async Task<Empleado> Handle(PutEmpleadoCommand request, CancellationToken cancellationToken)
            {
                EmpleadoDto em = new EmpleadoDto();
                try
                {
                    var empleado = await _context.Empleado.FirstOrDefaultAsync(p => p.Id == request.Id);

                    if (empleado != null)
                    {
                        empleado.Nombre = request.Nombre;
                        empleado.Apellido = request.Apellido;
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
                        
                        await _context.SaveChangesAsync();

                        return empleado;
                    }
                    else
                    {
                        throw new Exception("No existe ese empleado");
                    }
                }
                catch(Exception e)
                {
                    //em.Error = e.Message;
                    //em.Exito = false;
                    //em.Codigo = HttpStatusCode.NotFound;
                    throw e;
                }
                
            
            }

        }

    }
}
