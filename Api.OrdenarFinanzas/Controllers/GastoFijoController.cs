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
            return Ok();
        }

        [HttpPost]
        [Route("PostConsultarGastosFijosPorTipo")]
        public async Task<ActionResult<IEnumerable<GastoFijoDto>>> PostConsultarGastosFijosPorTipo(long idTipoGastoFijo)
        {

            if (idTipoGastoFijo == null)
            {
                return Problem("Entity set 'ApiOrdenarFinanzasDBContext.periodicidad'  is null.");
            }

            var _gastosFijo = await _gastoFijoService.PostConsultarGastosFijosPorTipoAsync(idTipoGastoFijo);

            if (_gastosFijo == null)
            {
                return Problem("Error creando la nueva periodicidad");
            }
            return Ok(_gastosFijo);
        }


    }
}
