using API_CodeFirst_Empleado.Data;
using API_CodeFirst_Empleado.Dtos;

using API_CodeFirst_Empleado.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API_CodeFirst_Empleado.Service.EmpleadosServices.Queries
{
    public class GetAllEmpleado
    {
        public class GetAllEmpleadoQuery : IRequest<List<EmpleadoDto>>
        {

        }

        public class GetAllEmpleadoQueryHandler : IRequestHandler<GetAllEmpleadoQuery, List<EmpleadoDto>>
        {

            private readonly ApplicationContext _context;

            public GetAllEmpleadoQueryHandler(ApplicationContext applicationContext)
            {
                _context = applicationContext;
            }

            public async Task<List<EmpleadoDto>> Handle(GetAllEmpleadoQuery request, CancellationToken cancellationToken)
            {

                try
                {
                    var empleados = await _context.Empleado
                        .Include(e => e.Cargo)
                        .Include(e => e.Sucursal)
                        .ToListAsync(); 
                    
                    if (empleados.Count != 0)
                    {
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
                    else
                    {
                        throw new Exception("No hay empleados en la base de datos");
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
