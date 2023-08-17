using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.OrdenarFinanzas.Services
{
    public interface IPeriodicidadService
    {
        Task<ActionResult<IEnumerable<Periodicidad>>> PostObtenerPeriodicidadesAsync();
        Task<ActionResult<Int64>>? PostCrearPeriodicidadAsync(Periodicidad periodicidad);

    }
}
