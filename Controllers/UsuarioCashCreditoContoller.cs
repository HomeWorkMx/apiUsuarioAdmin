using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using msUsuario.Interceptor;
using System.Collections.Generic;
using System.Threading.Tasks;
using apiUsuarioAdministrador.Entities;

using ProblemDetails = apiUsuarioAdministrador.Entities.ProblemDetails;
using NotFoundResult = apiUsuarioAdministrador.Entities.NotFoundResult;
using System;

namespace apiUsuarioAdministrador.Controllers
{
    [TypeFilter(typeof(InterceptorLogAttribute))]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UsuarioCashCreditoController : Controller
    {
        private msUsuarioClient _clientMsUsuario;

        public UsuarioCashCreditoController(msUsuarioClient clientMsUsuario)
        {
            _clientMsUsuario = clientMsUsuario;

        }

        [HttpGet("UsuarioCashCreditoGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioCashCreditoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioCashCreditoDto>>> UsuarioCashCreditoGetAll()
        {
            var Usuarios = await _clientMsUsuario.UsuarioCashCreditoGetAllAsync();
            if (Usuarios == null) return NotFound();
            return Ok(Usuarios);
        }

        [HttpGet("UsuarioCashCreditoGet/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioCashCreditoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioCashCreditoDto>>> UsuarioCashCreditoGet(int id)
        {
            var usuarios  = await _clientMsUsuario.UsuarioCashCreditoGetByIdAsync(id);
            if (usuarios == null) return NotFound();
            return Ok(usuarios);
        }

        [HttpGet("UsuarioCashCreditoGetByIdClienteAndOrIdProveedor")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioCashCreditoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioCashCreditoDto>>> UsuarioCashCreditoGetByIdClienteAndOrIdProveedor(int idCliente, int idProveedor)
        {
            try
            {
                var Usuarios = await _clientMsUsuario.UsuarioCashCreditoGetByIdClienteAndOrIdProveedorAsync(idCliente, idProveedor);
                if (Usuarios == null) return NotFound();
                return Ok(Usuarios);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("UsuarioCashCreditoInsert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioCashCreditoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioCashCreditoDto>>> UsuarioCashCreditoInsert(UsuarioCashCreditoDto item)
        {
            if (item == null) return BadRequest(item);
            var usuarios = await _clientMsUsuario.UsuarioCashCreditoInsertAsync(item);
            
            return Ok(usuarios);
        }

        [HttpPost("UsuarioCashCreditoInsertMasive")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioCashCreditoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioCashCreditoDto>>> UsuarioCashCreditoInsertMasive(List<UsuarioCashCreditoDto> items)
        {
            if (items == null) return BadRequest(items);
            List<UsuarioCashCreditoDto> usuarios = new List<UsuarioCashCreditoDto>();
            foreach (UsuarioCashCreditoDto UsuarioCashCredito in items)
            {
                UsuarioCashCreditoDto usuario = await _clientMsUsuario.UsuarioCashCreditoInsertAsync(UsuarioCashCredito);
                usuarios.Add(usuario);
            }
            return Ok(usuarios);
        }

        [HttpPost("UsuarioCashCreditoSave")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioCashCreditoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioCashCreditoDto>>> UsuarioInsertOrUpdate(UsuarioCashCreditoDto input)
        {
            if (input == null) return BadRequest(input);
            var entidad = await _clientMsUsuario.UsuarioCashCreditoSaveAsync(input);
            return Ok(entidad);
        }
        
        [HttpPut("UsuarioCashCreditoUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioCashCreditoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioCashCreditoDto>>> UsuarioUpdate(UsuarioCashCreditoDto input)
        {
            if (input == null) return BadRequest();
            var entidad = await _clientMsUsuario.UsuarioCashCreditoSaveAsync(input);
            return Ok(entidad);
        }
        
        [HttpDelete("UsuarioCashCreditoDelete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioCashCreditoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> UsuarioCashCreditoDelete(int id)
        {
            if (id <= 0) return BadRequest(ModelState);
            await _clientMsUsuario.UsuarioCashCreditoDeleteAsync(id);
            return NoContent();
        }

    }
}
