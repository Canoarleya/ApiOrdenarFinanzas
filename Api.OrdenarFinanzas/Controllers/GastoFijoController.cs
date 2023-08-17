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
    public class GastoFijoController : ControllerBase
    {
        private readonly IGastoFijoService _gastoFijoService;

        public GastoFijoController(IGastoFijoService gastoFijoService)
        {
            _gastoFijoService = gastoFijoService;
        }


        [HttpPost]
        [Route("PostObtenerGastosFijos")]
        public async Task<ActionResult<IEnumerable<GastoFijo>>> PostObtenerGastosFijos()
        {

            var tipoGastoFijo = await _gastoFijoService.PostObtenerGastosFijosAsync();

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
        [Route("PostCrearGastoFijo")]
        public async Task<ActionResult> PostCrearGastoFijo(GastoFijo gastoFijo)
        {

            if (gastoFijo == null)
            {
                return Problem("Entity set 'ApiOrdenarFinanzasDBContext.periodicidad'  is null.");
            }

            var _gastoFijo = await _gastoFijoService.PostCrearGastoFijoAsync(gastoFijo);

            if (_gastoFijo == null)
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
