using API_CodeFirst_Empleado.Data;
using API_CodeFirst_Empleado.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API_CodeFirst_Empleado.Service.EmpleadosServices.Command
{
    public class DeleteEmpleado
    {
        public class DeleteEmpleadoCommand : IRequest<Empleado>
        {
            public Guid Id { get; set; }
        }
        public class DeleteEmpleadoCommandHandler : IRequestHandler<DeleteEmpleadoCommand, Empleado>
        {
            private readonly ApplicationContext _context;
            public DeleteEmpleadoCommandHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<Empleado> Handle(DeleteEmpleadoCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var empleado = await _context.Empleado.FirstOrDefaultAsync(e => e.Id == request.Id);

                    if(empleado != null)
                    {
                        _context.Empleado.Remove(empleado);
                        await _context.SaveChangesAsync();

                        return empleado;
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(empleado));
                    }
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
