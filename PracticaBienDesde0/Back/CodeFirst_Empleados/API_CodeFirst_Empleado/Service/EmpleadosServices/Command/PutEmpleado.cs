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
            public SucursalDto SucursalDto { get; set; }
            public CargoDto Cargo { get; set; } = null!;
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
                Empleado em = new Empleado();
                try
                {
                    var empleado = await _context.Empleado.FirstOrDefaultAsync(p => p.Id == request.Id);

                    if(empleado  != null)
                    {
                        em.Nombre = request.Nombre;
                        em.Apellido = request.Apellido;
                        em.DNI = request.DNI;
                        {
                            Sucursal s = new Sucursal();
                            s.Id = request.SucursalDto.Id;
                            s.Nombre = request.SucursalDto.Nombre;
                            {
                                Ciudad ciu = new Ciudad();
                                ciu.Id = request.SucursalDto.Ciudad.Id;
                                ciu.Nombre = request.SucursalDto.Ciudad.Nombre;
                            }
                        }
                        {
                            Cargo c = new Cargo();
                            c.Id = request.Cargo.Id;
                            c.Nombre = request.Cargo.Nombre;
                        }
                        em.FechaAlta = request.FechaAlta;
                        await _context.Empleado.AddAsync(empleado);
                        await _context.SaveChangesAsync();

                        
                        //em.Exito = true;
                        //em.Codigo = HttpStatusCode.OK;
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
                }
                
                return em;
            
            }

        }

    }
}
