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

        [ForeignKey("IdPeriodicidad")]
        public long IdPeriodicidad { get; set; }
        public virtual Periodicidad? Periodicidad { get; set; }

        [ForeignKey("IdTipoGastoFijo")]
        public long IdTipoGastoFijo { get; set; }
        public virtual TipoGastoFijo? TipoGastoFijo { get; set; }

    }
}
