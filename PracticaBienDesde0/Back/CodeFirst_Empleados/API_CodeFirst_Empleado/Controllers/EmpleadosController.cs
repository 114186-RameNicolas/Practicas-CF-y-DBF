﻿using API_CodeFirst_Empleado.Dtos;
using API_CodeFirst_Empleado.Models;
using API_CodeFirst_Empleado.Service.EmpleadosServices.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using static API_CodeFirst_Empleado.Service.EmpleadosServices.Command.DeleteEmpleado;
using static API_CodeFirst_Empleado.Service.EmpleadosServices.Command.PostEmpleado;
using static API_CodeFirst_Empleado.Service.EmpleadosServices.Command.PutEmpleado;
using static API_CodeFirst_Empleado.Service.EmpleadosServices.Queries.GetAllEmpleado;
using static API_CodeFirst_Empleado.Service.EmpleadosServices.Queries.GetEmpleadoByNombre;
using static API_CodeFirst_Empleado.Service.EmpleadosServices.Queries.GetEmpleadoByNombreAndApellido;

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

        [HttpGet]
        [Route("/obtener/por/nombre")]
        public async Task<List<EmpleadoDto>> getEmpleadosPorNombre(string nombre)
        {
            return await _mediator.Send(new GetEmpleadoByNombreQuery { Nombre = nombre });
        }

        [HttpGet]
        [Route("/obtener/por/nombreyApellido")]
        public async Task<EmpleadoDto> getEmpleadosPorNombreAndApelldio(string nombre, string apellido)
        {
            return await _mediator.Send(new GetEmpleadoByNombreAndApellidoQuery { Nombre = nombre , Apellido = apellido}) ;
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

        [HttpPut]
        [Route("actualizar/empleado")]
        public async Task<IActionResult> putEmpleado([FromBody] PutEmpleadoCommand putEmpleado)
        {
            var jsonOption = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var empleado = await _mediator.Send(putEmpleado);

            var json = JsonSerializer.Serialize(empleado, jsonOption);

            return Ok(json);
        }

        [HttpDelete]
        [Route("delete/empleado")]
        public async Task<Empleado> deleteEmpleado(Guid id)
        {
            return await _mediator.Send(new DeleteEmpleadoCommand { Id = id});
        }
    }
}
