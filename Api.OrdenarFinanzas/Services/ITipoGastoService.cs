using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.OrdenarFinanzas.Services
{
    public interface ITipoGastoService
    {
        Task<ActionResult<IEnumerable<TipoGastoFijo>>> PostObtenerTipoGastosAsync();
        Task<ActionResult<Int64>> PostCrearTipoGastoAsync(TipoGastoFijo tipoGastoFijo);

    }
}
