using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.OrdenarFinanzas.Services
{
    public interface IMetaAhorroService
    {
        Task<ActionResult<IEnumerable<MetaAhorro>>> PostObtenerMetasAhorrosAsync();
        Task<ActionResult<Int64>> PostCrearMetaAhorroAsync(MetaAhorro metaAhorro);
    }
}
