using Api_DbFirst.Dtos;
using Clases.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api_DbFirst.Service.EmpleadoBusiness.Queries
{
    public class GetAllEmpleado
    {
        public class GetAllEmpeadoQuery : IRequest<List<EmpleadoDto>>
        {

        }

        public class GetAllEmpeladoQueryHandler : IRequestHandler<GetAllEmpeadoQuery, List<EmpleadoDto>>
        {
            private readonly ContextBD _context;

            public GetAllEmpeladoQueryHandler(ContextBD contextBD)
            {
                _context = contextBD;
            }

            public async Task<List<EmpleadoDto>> Handle(GetAllEmpeadoQuery request, CancellationToken cancellationToken)
            {
                var empleados = await _context.Empleado.Include(x => x.Cargo).Include(x => x.Sucursal.ciudad).ToListAsync();

                var empleadosDTO = new List<EmpleadoDto>();

                foreach (var empleado in empleados)
                {
                    var empleadoDTO = new EmpleadoDto
                    {
                        Id = empleado.Id,
                        Nombre = empleado.Nombre,
                        Apellido = empleado.Apellido,

                        Cargo = new CargoDto
                        {
                            Id = empleado.Cargo.Id,
                            Nombre = empleado.Cargo.Nombre,
                        },

                        Sucursal = new SucursalDto
                        {
                            Id = empleado.Sucursal.Id,
                            Nombre = empleado.Sucursal.Nombre,

                            Ciudad = new CiudadDto
                            {
                                Nombre = empleado.Sucursal.ciudad.Nombre
                            },
                        },

                        DNI = empleado.DNI,
                        FechaAlta = empleado.FechaAlta.Date
                    };

                    empleadosDTO.Add(empleadoDTO);
                }

                return empleadosDTO;
            }
        }

    }
}
