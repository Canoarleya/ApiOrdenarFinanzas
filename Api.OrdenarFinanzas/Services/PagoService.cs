using Api.OrdenarFinanzas.Data;
using Api.OrdenarFinanzas.Data.Dto;
using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Api.OrdenarFinanzas.Services
{
    public class PagoService: IPagoService
    {
        private readonly ApiOrdenarFinanzasDBContext _context;

        public PagoService(ApiOrdenarFinanzasDBContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<long>> PostCrearPagoAsync(Pago pago)
        {
            if (_context.Pagos == null)
            {
                return null;
            }

            //if (GastoFijoExistsPorNombre(gastoFijo.DescripcionGastoFijo))
            //{
            //    return null;
            //}

            _context.Pagos.Add(pago);
            var _pago = await _context.SaveChangesAsync();

            return _pago;
        }

        public async Task<ActionResult<IEnumerable<PagosDto>>> PostObtenerPagosAsync()
        {
            if (_context.Pagos == null)
            {
                return null;
            }

            var pagos = await _context.Pagos.Include(p => p.TipoPago).ToListAsync();

            var resultado = pagos.Join(
                 _context.GastosFijos,
                 PG => PG.IdSubtipo,
                 GF => GF.IdGastoFijo,
                 (PG, GF) => new
                 {   Pagos = PG,
                     DesSubtipo = GF.DescripcionGastoFijo
                 }).Where(result => result.Pagos.IdTipoPago == 2).Union(pagos.Join(
                 _context.MetasAhorro,
                 PG => PG.IdSubtipo,
                 MA => MA.IdMetaAhorro,
                 (PG, MA) => new
                 {
                     Pagos = PG,
                     DesSubtipo = MA.DescripcionMetaAhorro
                 }).Where(result => result.Pagos.IdTipoPago == 1)).Union(pagos.Join(
                 _context.Pagos,
                 PG => PG.IdPago,
                 PG2 => PG2.IdPago,
                 (PG, MA) => new
                 {
                     Pagos = PG,
                     DesSubtipo = "Pagos no programados"
                 }).Where(result => result.Pagos.IdTipoPago == 3))
                 .ToList();

            List<PagosDto> ListaPagosDto = resultado.Select(a => new PagosDto()
            {
                IdPago = a.Pagos.IdPago,
                DescripcionPago = a.Pagos.DescripcionPago,
                Fecha = a.Pagos.Fecha,
                Monto = a.Pagos.Monto,
                IdTipoPago = a.Pagos.IdTipoPago,
                IdSubtipo = a.Pagos.IdSubtipo,
                DescriSubtipo = a.DesSubtipo,
                DescritipoPago = a.Pagos.TipoPago.DescripcionTipoPago

            }).ToList();

            
            return ListaPagosDto;
        }
    }
}
