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
    public class MetaAhorroController : ControllerBase
    {
        private readonly IMetaAhorroService _metaAhorroService;

        public MetaAhorroController(IMetaAhorroService metaAhorroService)
        {
            _metaAhorroService = metaAhorroService;
        }
        [HttpPost]
        [Route("PostObtenerMetasAhorros")]
        public async Task<ActionResult<IEnumerable<MetaAhorro>>> PostObtenerMetasAhorros()
        {

            var metasAhorros = await _metaAhorroService.PostObtenerMetasAhorrosAsync();

            if (metasAhorros == null)
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

            return Ok(metasAhorros);
        }


        [HttpPost]
        [Route("PostCrearMetaAhorro")]
        public async Task<ActionResult> PostCrearMetaAhorro(MetaAhorro periodicidad)
        {

            if (periodicidad == null)
            {
                return Problem("Entity set 'ApiOrdenarFinanzasDBContext.periodicidad'  is null.");
            }

            var _periodicidad = await _metaAhorroService.PostCrearMetaAhorroAsync(periodicidad);

            if (_periodicidad == null)
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
