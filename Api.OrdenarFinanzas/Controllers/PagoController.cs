using Api.OrdenarFinanzas.Data.Dto;
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
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }


        [HttpPost]
        [Route("PostObtenerPagos")]
        public async Task<ActionResult<IEnumerable<PagosDto>>> PostObtenerPagos()
        {

            var pago = await _pagoService.PostObtenerPagosAsync();

            if (pago == null)
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

            return Ok(pago);
        }

        [HttpPost]
        [Route("PostCrearPago")]
        public async Task<ActionResult> PostCrearPago(Pago pago)
        {

            if (pago == null)
            {
                return Problem("Entity set 'ApiOrdenarFinanzasDBContext.periodicidad'  is null.");
            }

            var _pago = await _pagoService.PostCrearPagoAsync(pago);

            if (_pago == null)
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
