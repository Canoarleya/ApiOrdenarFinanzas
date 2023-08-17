using Api.OrdenarFinanzas.Data;
using Api.OrdenarFinanzas.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Api.OrdenarFinanzas.Services
{
    public class PeriodicidadService: IPeriodicidadService
    {
        private readonly ApiOrdenarFinanzasDBContext _context;


        public PeriodicidadService(ApiOrdenarFinanzasDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Periodicidad>>> PostObtenerPeriodicidadesAsync()
        {
            if (_context.Periodicidades == null)
            {
                return null;
            }
            //var user = await _context.Periodicidades.FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);
            var Periodicidades = await _context.Periodicidades.ToListAsync();
            
            return Periodicidades;
        }

        public async Task<ActionResult<Int64>> PostCrearPeriodicidadAsync(Periodicidad periodicidad)
        {
            if (_context.Periodicidades == null)
            {
                return null;
            }

            if (PeriodicidadExistsPorNombre(periodicidad.DescripcionPeriodicidad))
            {
                return null;
            }

            _context.Periodicidades.Add(periodicidad);
            var Periodicidades =  await _context.SaveChangesAsync();

            return Periodicidades;
        }


        private bool PeriodicidadExistsPorNombre(string periodicidad)
        {
            return (_context.Periodicidades?.Any(e => e.DescripcionPeriodicidad.ToLower().Trim() == periodicidad)).GetValueOrDefault();
        }

    }
}
