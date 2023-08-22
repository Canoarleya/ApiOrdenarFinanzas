using Api.OrdenarFinanzas.Data;
using Api.OrdenarFinanzas.Data.Dto;
using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.OrdenarFinanzas.Services
{
    public class GastoFijoService : IGastoFijoService
    {
        private readonly ApiOrdenarFinanzasDBContext _context;

        public GastoFijoService(ApiOrdenarFinanzasDBContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<long>> PostCrearGastoFijoAsync(GastoFijo gastoFijo)
        {
            if (_context.GastosFijos == null)
            {
                return null;
            }

            if (GastoFijoExistsPorNombre(gastoFijo.DescripcionGastoFijo))
            {
                return null;
            }

            _context.GastosFijos.Add(gastoFijo);
            var _tipoGastoFijo = await _context.SaveChangesAsync();

            return _tipoGastoFijo;

        }

        private bool GastoFijoExistsPorNombre(string descripcion)
        {
            return (_context.GastosFijos?.Any(e => e.DescripcionGastoFijo.ToLower().Trim() == descripcion)).GetValueOrDefault();
        }

        public async Task<ActionResult<IEnumerable<GastoFijo>>> PostObtenerGastosFijosAsync()
        {
            if (_context.GastosFijos == null)
            {
                return null;
            }
            //var GastosFijos = await _context.GastosFijos.Include(u => u.User).ToListAsync();
            var gastosFijos = await _context.GastosFijos.Include(p => p.Periodicidad).Include(t => t.TipoGastoFijo).ToListAsync();

            return gastosFijos;
        }

        public async Task<ActionResult<IEnumerable<GastoFijoDto>>> PostConsultarGastosFijosPorTipoAsync(long idTipoGastoFijo)
        {
            if (_context.GastosFijos == null)
            {
                return null;
            }
            var gastosFijos = await _context.GastosFijos.Include(p => p.Periodicidad).Include(t => t.TipoGastoFijo).Where(gf => gf.IdTipoGastoFijo == idTipoGastoFijo).ToListAsync();

            List<GastoFijoDto> ListaGastoFijoDto = gastosFijos.Select(a => new GastoFijoDto()
            {
                IdGastoFijo = a.IdGastoFijo,
                DescripcionGastoFijo = a.DescripcionGastoFijo,
                MontoEstimado = a.MontoEstimado,
                IdPeriodicidad = a.IdPeriodicidad,
                DescripcionPeriodicidad = a.Periodicidad.DescripcionPeriodicidad,
                IdTipoGastoFijo = a.IdGastoFijo,
                DescripcionTpoGastoFijo = a.TipoGastoFijo.DescripcionTipoGastoFijo
            }).ToList();


            
            return ListaGastoFijoDto;
        }
    }
}
