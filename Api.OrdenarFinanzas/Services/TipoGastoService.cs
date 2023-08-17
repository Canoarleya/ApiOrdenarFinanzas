using Api.OrdenarFinanzas.Data;
using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.OrdenarFinanzas.Services
{
    public class TipoGastoService : ITipoGastoService
    {
        private readonly ApiOrdenarFinanzasDBContext _context;

        public TipoGastoService(ApiOrdenarFinanzasDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Int64>> PostCrearTipoGastoAsync(TipoGastoFijo tipoGastoFijo)
        {
            if (_context.TiposGastosFijos == null)
            {
                return null;
            }

            if (TipoGastoFijoExistsPorNombre(tipoGastoFijo.DescripcionTipoGastoFijo))
            {
                return null;
            }

            _context.TiposGastosFijos.Add(tipoGastoFijo);
            var _tipoGastoFijo = await _context.SaveChangesAsync();

            return _tipoGastoFijo;


        }

        private bool TipoGastoFijoExistsPorNombre(string descripcion)
        {
            return (_context.TiposGastosFijos?.Any(e => e.DescripcionTipoGastoFijo.ToLower().Trim() == descripcion)).GetValueOrDefault();
        }


        public async Task<ActionResult<IEnumerable<TipoGastoFijo>>> PostObtenerTipoGastosAsync()
        {
            if (_context.TiposGastosFijos == null)
            {
                return null;
            }
            //var user = await _context.Periodicidades.FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);
            var TiposGastosFijos = await _context.TiposGastosFijos.Include(u => u.User).ToListAsync();

            return TiposGastosFijos;
        }
    }
}
