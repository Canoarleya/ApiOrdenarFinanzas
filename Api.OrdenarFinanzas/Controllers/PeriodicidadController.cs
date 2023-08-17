using Api.OrdenarFinanzas.Data.Dto;
using Api.OrdenarFinanzas.Data.Models;
using Api.OrdenarFinanzas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.OrdenarFinanzas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodicidadController : ControllerBase
    {
        private readonly IPeriodicidadService _periodicidadService;

        public PeriodicidadController(IPeriodicidadService periodicidadService)
        {
            _periodicidadService = periodicidadService;
        }

        [HttpPost]
        [Route("PostObtenerPeriodicidades")]
        public async Task<ActionResult<IEnumerable<Periodicidad>>> PostObtenerPeriodicidades()
        {

            var periodicidad = await _periodicidadService.PostObtenerPeriodicidadesAsync();

            if (periodicidad == null)
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

            return Ok(periodicidad);
        }


        [HttpPost]
        [Route("PostCrearPeriodicidad")]
        public async Task<ActionResult> PostCrearPeriodicidad(Periodicidad periodicidad)
        {

            if (periodicidad == null)
            {
                return Problem("Entity set 'ApiOrdenarFinanzasDBContext.periodicidad'  is null.");
            }

            var _periodicidad = await _periodicidadService.PostCrearPeriodicidadAsync(periodicidad);

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
