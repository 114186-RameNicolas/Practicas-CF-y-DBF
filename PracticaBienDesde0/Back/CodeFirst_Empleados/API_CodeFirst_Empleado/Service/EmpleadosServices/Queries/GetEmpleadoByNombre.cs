using API_CodeFirst_Empleado.Data;
using API_CodeFirst_Empleado.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API_CodeFirst_Empleado.Service.EmpleadosServices.Queries
{
    public class GetEmpleadoByNombre
    {
        public class GetEmpleadoByNombreQuery : IRequest<List<EmpleadoDto>>
        {
            public string Nombre { get; set; }
        }
        public class GetEmpleadoByNombreQueryHandler : IRequestHandler<GetEmpleadoByNombreQuery, List<EmpleadoDto>>
        {
            private readonly ApplicationContext _context;

            public GetEmpleadoByNombreQueryHandler(ApplicationContext applicationContext)
            {
                _context = applicationContext;
            }


            public async Task<List<EmpleadoDto>> Handle(GetEmpleadoByNombreQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var empleados = await _context.Empleado
                        .Include(e => e.Cargo)
                        .Include(e => e.Sucursal)
                        .ThenInclude(s => s.Ciudad)
                        .Where(e => e.Nombre.ToLower() == request.Nombre.ToLower())
                        .ToListAsync();

                    var empleadosDto = empleados.Select(e => new EmpleadoDto
                    {
                        Id = e.Id,
                        Nombre = e.Nombre,
                        Apellido = e.Apellido,
                        DNI = e.DNI,
                        Sucursal = new SucursalDto
                        {
                            Id = e.Sucursal.Id,
                            Nombre = e.Sucursal.Nombre,

                            Ciudad = new CiudadDto
                            {
                                Id = e.Sucursal.Ciudad.Id,
                                Nombre = e.Sucursal.Ciudad.Nombre
                            }

                        },

                        Cargo = new CargoDto
                        {
                            Id = e.Cargo.Id,
                            Nombre = e.Cargo.Nombre
                        },

                        Error = null,
                        Exito = true,
                        Codigo = HttpStatusCode.OK,

                    }).ToList();

                    return empleadosDto;
                }
                catch(Exception ex)
                {
                    throw new Exception("Error " + HttpStatusCode.NotFound);
                }
            }
        }
    }
}
