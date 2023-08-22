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
    public class TipoPagoController : ControllerBase
    {
        private readonly ITipoPagoService _tipoPagoService;

        public TipoPagoController(ITipoPagoService tipoPagoService)
        {
            _tipoPagoService = tipoPagoService;
        }

        [HttpPost]
        [Route("PostObtenerTiposPago")]
        public async Task<ActionResult<IEnumerable<TipoPago>>> PostObtenerTiposPago()
        {

            var tipospago = await _tipoPagoService.PostObtenerTiposPagoAsync();

            if (tipospago == null)
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

            return Ok(tipospago);
        }

        [HttpPost]
        [Route("PostCrearTipoPago")]
        public async Task<ActionResult> PostCrearTipoPago(TipoPago tipoPago)
        {

            if (tipoPago == null)
            {
                return Problem("Entity set 'ApiOrdenarFinanzasDBContext.periodicidad'  is null.");
            }

            var _tipoPago = await _tipoPagoService.PostCrearTipoPagoAsync(tipoPago);

            if (_tipoPago == null)
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
