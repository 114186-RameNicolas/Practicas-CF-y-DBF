using API_CodeFirst_Empleado.Data;
using API_CodeFirst_Empleado.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API_CodeFirst_Empleado.Service.EmpleadosServices.Queries
{
    public class GetEmpleadoByNombreAndApellido
    {
        public class GetEmpleadoByNombreAndApellidoQuery : IRequest<EmpleadoDto>
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
        }
        public class GetEmpleadoByNombreAndApellidoQueryHandler : IRequestHandler<GetEmpleadoByNombreAndApellidoQuery, EmpleadoDto>
        {
            private readonly ApplicationContext _context;

            public GetEmpleadoByNombreAndApellidoQueryHandler(ApplicationContext applicationContext)
            {
                _context = applicationContext;
            }


            public async Task<EmpleadoDto> Handle(GetEmpleadoByNombreAndApellidoQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var empleados = await _context.Empleado
                        .Include(e => e.Cargo)
                        .Include(e => e.Sucursal)
                        .ThenInclude(s => s.Ciudad)
                        .FirstOrDefaultAsync(e => 
                        e.Nombre.ToLower() == request.Nombre.ToLower() 
                        && e.Apellido.ToLower() == request.Apellido.ToLower());

                    if (empleados != null)
                    {
                        var empleadosDto = new EmpleadoDto()
                        {
                            Id = empleados.Id,
                            Nombre = empleados.Nombre,
                            Apellido = empleados.Apellido,
                            DNI = empleados.DNI,
                            Sucursal = new SucursalDto
                            {
                                Id = empleados.Sucursal.Id,
                                Nombre = empleados.Sucursal.Nombre,

                                Ciudad = new CiudadDto
                                {
                                    Id = empleados.Sucursal.Ciudad.Id,
                                    Nombre = empleados.Sucursal.Ciudad.Nombre
                                }

                            },

                            Cargo = new CargoDto
                            {
                                Id = empleados.Cargo.Id,
                                Nombre = empleados.Cargo.Nombre
                            },

                            Error = null,
                            Exito = true,
                            Codigo = HttpStatusCode.OK,

                        };

                        return empleadosDto;
                    }
                    else
                    {
                        throw new Exception("Nombre inexistente");
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error " + HttpStatusCode.NotFound);
                }
            }
        }
    
    }
}
