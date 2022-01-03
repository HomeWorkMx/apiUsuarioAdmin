using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using msUsuario.Interceptor;
using System.Collections.Generic;
using System.Threading.Tasks;
using apiUsuarioAdministrador.Entities;
using apiUsuarioAdministrador.Models;

using ProblemDetails = apiUsuarioAdministrador.Entities.ProblemDetails;
using NotFoundResult = apiUsuarioAdministrador.Entities.NotFoundResult;


namespace apiUsuarioAdministrador.Controllers
{
    [TypeFilter(typeof(InterceptorLogAttribute))]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ApiUsuarioController : Controller
    {
        private msUsuarioClient _clientMsUsuario;

        public ApiUsuarioController(msUsuarioClient clientMsUsuario)
        {
            _clientMsUsuario = clientMsUsuario;

        }

        [HttpGet("UsuarioGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> UsuarioGetAll()
        {
            var Usuarios = await _clientMsUsuario.UsuarioGetAllAsync();
            if (Usuarios == null) return NotFound();
            return Ok(Usuarios);
        }

        [HttpGet("UsuarioGet/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioDto2>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioDto2>>> UsuarioGet(int id)
        {
            var usuarios  = await _clientMsUsuario.UsuarioGetBasicAsync(id);
            if (usuarios == null) return NotFound();
            return Ok(usuarios);
        }

        [HttpGet("UsuarioGetByEmail/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> UsuarioGetByEmail(string email)
        {
            try
            {
                var usuarios = await _clientMsUsuario.GetUserByEmailAsync(email);
                if (usuarios == null) return NotFound();
                return Ok(usuarios);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("UsuarioProveedorGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> UsuarioProveedorGetAll()
        {
            try
            {
                var usuarios = await _clientMsUsuario.ProveedorGetAllAsync();
                if (usuarios == null) return NotFound();
                return Ok(usuarios);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet("UsuariosGetByTipo/{idTipo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProveedorTipoDireccionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<ProveedorTipoDireccionDto>>> UsuariosGetByTipo(int idTipo)
        {
            try
            {
                var proveedoresTipo = await _clientMsUsuario.UsuariosGetByTipoAsync(idTipo);

                List<ProveedorTipoDireccionDto> salida = new List<ProveedorTipoDireccionDto>();
                foreach (ProveedorTipoDto itemProvedorTipo in proveedoresTipo)
                {
                    List<DireccionDto> direccionesProveedor = new List<DireccionDto>();
                    var direccionesByProveedor =  await _clientMsUsuario.DireccionGetByProveedorAsync(int.Parse( itemProvedorTipo.IdUsuario.ToString()));
                    foreach (DireccionDto itemDireccion in direccionesByProveedor)
                        direccionesProveedor.Add(itemDireccion);
                    
                    ProveedorTipoDireccionDto itemProveedorTipoDireccionDto = new ProveedorTipoDireccionDto();
                    itemProveedorTipoDireccionDto.DescripcionTipo = itemProvedorTipo.DescripcionTipo;
                    itemProveedorTipoDireccionDto.DescripcionUsuario = itemProvedorTipo.DescripcionUsuario;
                    itemProveedorTipoDireccionDto.DireccionesProveedor = direccionesProveedor;//->esto en nuevo
                    itemProveedorTipoDireccionDto.EstrellasPromedio =5;//->se calculan en el front
                    itemProveedorTipoDireccionDto.IdTipoUsuario = itemProvedorTipo.IdTipoUsuario;
                    itemProveedorTipoDireccionDto.IdUsuario = itemProvedorTipo.IdUsuario;
                    itemProveedorTipoDireccionDto.NombreUsuario = itemProvedorTipo.NombreUsuario;
                    salida.Add(itemProveedorTipoDireccionDto);
                }

                if (salida == null) return NotFound();
                return Ok(salida);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }



        [HttpPost("UsuarioInsert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> UsuarioInsert(UsuarioDto item)
        {
            if (item == null) return BadRequest(item);
            var usuarios = await _clientMsUsuario.UsuarioInsertAsync(item);
            
            return Ok(usuarios);
        }
        
        [HttpPost("UsuarioSave")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> UsuarioInsertOrUpdate(UsuarioDto input)
        {
            if (input == null) return BadRequest(input);
            var entidad = await _clientMsUsuario.UsuarioSaveAsync(input);
            return Ok(entidad);
        }
        
        [HttpPut("UsuarioUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> UsuarioUpdate(UsuarioDto input)
        {
            if (input == null) return BadRequest();
            var entidad = await _clientMsUsuario.UsuarioUpdateAsync(input);
            return Ok(entidad);
        }
        
        [HttpDelete("UsuarioDelete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> UsuarioDelete(int id)
        {
            if (id <= 0) return BadRequest(ModelState);
            await _clientMsUsuario.UsuarioDeleteAsync(id);
            return NoContent();
        }

        [HttpGet("UsuarioProductoGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductoUsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<ProductoUsuarioDto>>> UsuarioProductoGetAll()
        {
            var Usuarios = await _clientMsUsuario.GetAllAsync();
            if (Usuarios == null) return NotFound();
            return Ok(Usuarios);
        }

        [HttpGet("UsuarioProductoGet/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductoUsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<ProductoUsuarioDto>>> UsuarioProductoGet(int id)
        {
            var usuarios = await _clientMsUsuario.GetAsync(id);
            if (usuarios == null) return NotFound();
            return Ok(usuarios);
        }

        [HttpPost("UsuarioProductoInsert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductoUsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<ProductoUsuarioDto>>> UsuarioProductoInsert(ProductoUsuarioDto item)
        {
            if (item == null) return BadRequest(item);
            var UsuarioProductos = await _clientMsUsuario.InsertAsync(item);

            return Ok(UsuarioProductos);
        }

        [HttpPost("UsuarioProductoSave")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductoUsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<ProductoUsuarioDto>>> UsuarioProductoInsertOrUpdate(ProductoUsuarioDto input)
        {
            if (input == null) return BadRequest(input);
            var entidad = await _clientMsUsuario.SaveAsync(input);
            return Ok(entidad);
        }

        [HttpPut("UsuarioProductoUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductoUsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<IEnumerable<ProductoUsuarioDto>>> UsuarioProductoUpdate(ProductoUsuarioDto input)
        {
            if (input == null) return BadRequest();
            var entidad = await _clientMsUsuario.UpdateAsync(input);
            return Ok(entidad);
        }

        [HttpDelete("UsuarioProductoDelete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductoUsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult> UsuarioProductoDelete(int id)
        {
            if (id <= 0) return BadRequest(ModelState);
            await _clientMsUsuario.DeleteAsync(id);
            return NoContent();
        }

    }
}
