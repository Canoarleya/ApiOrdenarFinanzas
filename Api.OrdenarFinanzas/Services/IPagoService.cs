using Api.OrdenarFinanzas.Data.Dto;
using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.OrdenarFinanzas.Services
{
    public interface IPagoService
    {
        Task<ActionResult<IEnumerable<PagosDto>>> PostObtenerPagosAsync();
        Task<ActionResult<Int64>> PostCrearPagoAsync(Pago pago);

    }
}
