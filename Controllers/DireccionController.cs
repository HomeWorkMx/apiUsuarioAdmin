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
    public class DireccionController : Controller
    {
        private msUsuarioClient _clientMsUsuario;

        public DireccionController(msUsuarioClient clientMsUsuario)
        {
            _clientMsUsuario = clientMsUsuario;

        }

        [HttpGet("DireccionGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DireccionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<DireccionDto>>> DireccionGetAll()
        {
            var Usuarios = await _clientMsUsuario.DireccionGetAllAsync();
            if (Usuarios == null) return NotFound();
            return Ok(Usuarios);
        }

        [HttpGet("DireccionGet/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DireccionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<DireccionDto>>> DireccionGet(int id)
        {
            var usuarios  = await _clientMsUsuario.DireccionGetAsync(id);
            if (usuarios == null) return NotFound();
            return Ok(usuarios);
        }

        [HttpGet("DireccionGetByProveedor")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DireccionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<DireccionDto>>> DireccionGetByProveedor(int id)
        {
            try
            {
                var Usuarios = await _clientMsUsuario.DireccionGetByProveedorAsync(id);
                if (Usuarios == null) return NotFound();
                return Ok(Usuarios);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("DireccionInsert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DireccionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<DireccionDto>>> DireccionInsert(DireccionDto item)
        {
            if (item == null) return BadRequest(item);
            var usuarios = await _clientMsUsuario.DireccionInsertAsync(item);
            
            return Ok(usuarios);
        }

        [HttpPost("DireccionInsertMasive")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DireccionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<DireccionDto>>> DireccionInsertMasive(List<DireccionDto> items)
        {
            if (items == null) return BadRequest(items);
            List<DireccionDto> usuarios = new List<DireccionDto>();
            foreach (DireccionDto Direccion in items)
            {
                DireccionDto usuario = await _clientMsUsuario.DireccionInsertAsync(Direccion);
                usuarios.Add(usuario);
            }
            return Ok(usuarios);
        }

        [HttpPost("DireccionSave")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DireccionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<DireccionDto>>> UsuarioInsertOrUpdate(DireccionDto input)
        {
            if (input == null) return BadRequest(input);
            var entidad = await _clientMsUsuario.DireccionSaveAsync(input);
            return Ok(entidad);
        }
        
        [HttpPut("DireccionUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DireccionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<DireccionDto>>> UsuarioUpdate(DireccionDto input)
        {
            if (input == null) return BadRequest();
            var entidad = await _clientMsUsuario.DireccionSaveAsync(input);
            return Ok(entidad);
        }
        
        [HttpDelete("DireccionDelete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DireccionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> DireccionDelete(int id)
        {
            if (id <= 0) return BadRequest(ModelState);
            await _clientMsUsuario.DireccionDeleteAsync(id);
            return NoContent();
        }

    }
}
