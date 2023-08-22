using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.OrdenarFinanzas.Data.Models
{
    public class GastoFijo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdGastoFijo { get; set; }

        [Required]
        public string DescripcionGastoFijo { get; set; }

        [Required]
        public decimal MontoEstimado { get; set; }

        public long IdPeriodicidad { get; set; }
        [ForeignKey("IdPeriodicidad")]
        public virtual Periodicidad? Periodicidad { get; set; }

        public long IdTipoGastoFijo { get; set; }
        [ForeignKey("IdTipoGastoFijo")]
        public virtual TipoGastoFijo? TipoGastoFijo { get; set; }

    }
}
