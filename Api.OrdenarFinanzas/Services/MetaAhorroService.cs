using Api.OrdenarFinanzas.Data;
using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.OrdenarFinanzas.Services
{
    public class MetaAhorroService : IMetaAhorroService
    {
        private readonly ApiOrdenarFinanzasDBContext _context;

        public  MetaAhorroService(ApiOrdenarFinanzasDBContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<long>> PostCrearMetaAhorroAsync(MetaAhorro metaAhorro)
        {
            if (_context.MetasAhorro == null)
            {
                return null;
            }

            /*
            if (GastoFijoExistsPorNombre(gastoFijo.DescripcionGastoFijo))
            {
                return null;
            }*/

            _context.MetasAhorro.Add(metaAhorro);
            var _metaAhorro = await _context.SaveChangesAsync();

            return _metaAhorro;
        }

        public async Task<ActionResult<IEnumerable<MetaAhorro>>> PostObtenerMetasAhorrosAsync()
        {
            if (_context.MetasAhorro == null)
            {
                return null;
            }
            //var GastosFijos = await _context.GastosFijos.Include(u => u.User).ToListAsync();
            var metasAhorro = await _context.MetasAhorro.ToListAsync();

            return metasAhorro;
        }
    }
}
