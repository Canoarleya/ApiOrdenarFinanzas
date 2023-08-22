using Api.OrdenarFinanzas.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.OrdenarFinanzas.Data.Dto
{
    public class GastoFijoDto
    {
        public long IdGastoFijo { get; set; }

        public string DescripcionGastoFijo { get; set; }
        public decimal MontoEstimado { get; set; }

        public long IdPeriodicidad { get; set; }
        public string DescripcionPeriodicidad { get; set; }

        public long IdTipoGastoFijo { get; set; }
        public string DescripcionTpoGastoFijo{ get; set; }
    }
}
