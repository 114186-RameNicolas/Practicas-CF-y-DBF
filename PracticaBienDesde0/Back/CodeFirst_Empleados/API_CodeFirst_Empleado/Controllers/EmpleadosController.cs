using API_CodeFirst_Empleado.Dtos;
using API_CodeFirst_Empleado.Models;
using API_CodeFirst_Empleado.Service.EmpleadosServices.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using static API_CodeFirst_Empleado.Service.EmpleadosServices.Command.PostEmpleado;
using static API_CodeFirst_Empleado.Service.EmpleadosServices.Queries.GetAllEmpleado;

namespace API_CodeFirst_Empleado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpleadosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("/obtener/todos")]
        public async Task<List<EmpleadoDto>> getEmpleados()
        {
            return await _mediator.Send(new GetAllEmpleadoQuery());
        }

        [HttpPost]
        [Route("/post/empleado")]
        public async Task<IActionResult> postEmpleado([FromBody] PostEmpleadoCommand postEmpleado)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var empleado = await _mediator.Send(postEmpleado);

            var json = JsonSerializer.Serialize(empleado, jsonOptions);

            return Ok(json);
        }
    }
}
