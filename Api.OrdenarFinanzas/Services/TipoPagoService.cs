using Api.OrdenarFinanzas.Data;
using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Api.OrdenarFinanzas.Services
{
    public class TipoPagoService : ITipoPagoService
    {
        private readonly ApiOrdenarFinanzasDBContext _context;

        public TipoPagoService(ApiOrdenarFinanzasDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<long>> PostCrearTipoPagoAsync(TipoPago tipoPago)
        {
            if (_context.TiposPago == null)
            {
                return null;
            }

            if (TipoPagoExistsPorNombre(tipoPago.DescripcionTipoPago))
            {
                return null;
            }

            _context.TiposPago.Add(tipoPago);
            var _tipoPago = await _context.SaveChangesAsync();

            return _tipoPago;
        }

        private bool TipoPagoExistsPorNombre(string descripcion)
        {
            return (_context.TiposPago?.Any(e => e.DescripcionTipoPago.ToLower().Trim() == descripcion)).GetValueOrDefault();
        }

        public async Task<ActionResult<IEnumerable<TipoPago>>> PostObtenerTiposPagoAsync()
        {
            if (_context.TiposPago == null)
            {
                return null;
            }
            var TiposPago = await _context.TiposPago.ToListAsync();
            return TiposPago;
        }
    }
}
