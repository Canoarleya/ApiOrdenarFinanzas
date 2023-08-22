using Api.OrdenarFinanzas.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.OrdenarFinanzas.Data.Dto
{
    public class PagosDto
    {
        public long IdPago { get; set; }
        public string? DescripcionPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public long IdTipoPago { get; set; }

        public string? DescritipoPago { get; set; }
        //public virtual TipoPago TipoPago { get; set; }
        public long IdSubtipo { get; set; }
        public string DescriSubtipo { get; set; }

    }
}
