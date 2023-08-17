using Api.OrdenarFinanzas.Data.Models;
using Api.OrdenarFinanzas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.OrdenarFinanzas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoGastoController : ControllerBase
    {
        private readonly ITipoGastoService _tipoGastoService;
        public TipoGastoController(ITipoGastoService tipoGastoService)
        {
            _tipoGastoService = tipoGastoService;
        }

        [HttpPost]
        [Route("PostObtenerTipoGastos")]
        public async Task<ActionResult<IEnumerable<TipoGastoFijo>>> PostObtenerTipoGastos()
        {

            var tipoGastoFijo = await _tipoGastoService.PostObtenerTipoGastosAsync();

            if (tipoGastoFijo == null)
            {
                return NotFound();
            }
            /*
            var token = _accountService.GenerateJwtToken(user);

            var userDto = new UserDto
            {
                UserName = user.UserName,
                Role = user.Role,
                Token = token
            };*/

            return Ok(tipoGastoFijo);
        }

        [HttpPost]
        [Route("PostCrearTipoGasto")]
        public async Task<ActionResult> PostCrearTipoGasto(TipoGastoFijo tipoGastoFijo)
        {

            if (tipoGastoFijo == null)
            {
                return Problem("Entity set 'ApiOrdenarFinanzasDBContext.periodicidad'  is null.");
            }

            var _tipoGastoFijo = await _tipoGastoService.PostCrearTipoGastoAsync(tipoGastoFijo);

            if (_tipoGastoFijo == null)
            {
                return Problem("Error creando la nueva periodicidad");
            }

            /*
            var userDto = new UserDto
            {
                UserName = user.UserName,
                Role = user.Role,
                Token = token
            };*/

            return Ok();
        }


    }
}
