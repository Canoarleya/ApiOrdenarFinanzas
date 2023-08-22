using Api.OrdenarFinanzas.Data.Dto;
using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.OrdenarFinanzas.Services
{
    public interface IGastoFijoService
    {
        Task<ActionResult<IEnumerable<GastoFijo>>> PostObtenerGastosFijosAsync();
        Task<ActionResult<Int64>> PostCrearGastoFijoAsync(GastoFijo gastoFijo);
        Task<ActionResult<IEnumerable<GastoFijoDto>>> PostConsultarGastosFijosPorTipoAsync(long idTipoGastoFijo);
    }
}
