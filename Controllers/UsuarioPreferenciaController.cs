using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using msUsuario.Interceptor;
using System.Collections.Generic;
using System.Threading.Tasks;
using apiUsuarioAdministrador.Entities;

using ProblemDetails = apiUsuarioAdministrador.Entities.ProblemDetails;
using NotFoundResult = apiUsuarioAdministrador.Entities.NotFoundResult;


namespace apiUsuarioAdministrador.Controllers
{
    [TypeFilter(typeof(InterceptorLogAttribute))]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UsuarioPreferenciaController : Controller
    {
        private msUsuarioClient _clientMsUsuario;

        public UsuarioPreferenciaController(msUsuarioClient clientMsUsuario)
        {
            _clientMsUsuario = clientMsUsuario;

        }

        [HttpGet("UsuarioPreferenciaGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioPreferenciaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioPreferenciaDto>>> UsuarioGetAll()
        {
            var Usuarios = await _clientMsUsuario.UsuarioPreferenciaGetAllAsync();
            if (Usuarios == null) return NotFound();
            return Ok(Usuarios);
        }

        [HttpGet("UsuarioPreferenciaGet/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioPreferenciaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioPreferenciaDto>>> UsuarioGet(int id)
        {
            var usuarios  = await _clientMsUsuario.UsuarioGetAsync(id);
            if (usuarios == null) return NotFound();
            return Ok(usuarios);
        }

        [HttpPost("UsuarioPreferenciaInsert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioPreferenciaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioPreferenciaDto>>> UsuarioInsert(UsuarioPreferenciaDto item)
        {
            if (item == null) return BadRequest(item);
            var usuarios = await _clientMsUsuario.UsuarioPreferenciaInsertAsync(item);
            
            return Ok(usuarios);
        }

        [HttpPost("UsuarioPreferenciaInsertMasive")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioPreferenciaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioPreferenciaDto>>> UsuarioPreferenciaInsertMasive(List<UsuarioPreferenciaDto> items)
        {
            if (items == null) return BadRequest(items);
            List<UsuarioPreferenciaDto> usuarios = new List<UsuarioPreferenciaDto>();
            foreach (UsuarioPreferenciaDto usuarioPreferencia in items)
            {
                UsuarioPreferenciaDto usuario = await _clientMsUsuario.UsuarioPreferenciaInsertAsync(usuarioPreferencia);
                usuarios.Add(usuario);
            }
            return Ok(usuarios);
        }

        [HttpPost("UsuarioPreferenciaSave")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioPreferenciaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioPreferenciaDto>>> UsuarioInsertOrUpdate(UsuarioPreferenciaDto input)
        {
            if (input == null) return BadRequest(input);
            var entidad = await _clientMsUsuario.UsuarioPreferenciaSaveAsync(input);
            return Ok(entidad);
        }
        
        [HttpPut("UsuarioPreferenciaUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioPreferenciaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioPreferenciaDto>>> UsuarioUpdate(UsuarioPreferenciaDto input)
        {
            if (input == null) return BadRequest();
            var entidad = await _clientMsUsuario.UsuarioPreferenciaSaveAsync(input);
            return Ok(entidad);
        }
        
        [HttpDelete("UsuarioPreferenciaDelete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioPreferenciaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> UsuarioDelete(int id)
        {
            if (id <= 0) return BadRequest(ModelState);
            await _clientMsUsuario.UsuarioDeleteAsync(id);
            return NoContent();
        }

    }
}
