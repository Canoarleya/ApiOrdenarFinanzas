using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.OrdenarFinanzas.Services
{
    public interface ITipoPagoService
    {
        Task<ActionResult<IEnumerable<TipoPago>>> PostObtenerTiposPagoAsync();
        Task<ActionResult<Int64>> PostCrearTipoPagoAsync(TipoPago tipoPago);
    }
}
