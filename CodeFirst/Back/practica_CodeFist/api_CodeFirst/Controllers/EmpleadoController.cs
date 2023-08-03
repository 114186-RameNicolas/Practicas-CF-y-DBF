using Api_DbFirst.Dtos;
using Clases.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Api_DbFirst.Service.EmpleadoBusiness.Command.PostEmpleado;
using static Api_DbFirst.Service.EmpleadoBusiness.Queries.GetAllEmpleado;

namespace api_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmpleadoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/obtener/empleados")]
        public async Task<List<EmpleadoDto>> Get()
        {
            return await _mediator.Send(new GetAllEmpeadoQuery());
        }

        [HttpPost]
        [Route("/post/empleado")]
        public async Task<Empleado> Post([FromBody] PostEmpleadoCommand postEmpleado)
        {
            return await _mediator.Send(postEmpleado);
        }

    }
}
