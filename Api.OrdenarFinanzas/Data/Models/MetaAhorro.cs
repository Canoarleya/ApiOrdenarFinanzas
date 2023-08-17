using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.OrdenarFinanzas.Data.Models
{
    public class MetaAhorro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdMetaAhorro { get; set; }

        [Required]
        public string DescripcionMetaAhorro { get; set; }

        [Required]
        public decimal MontoObjetivo { get; set; }

        [Required]
        public decimal BaseInicial { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public decimal MontoPeriodico { get; set; }

        [ForeignKey("IdPeriodicidad")]
        public virtual Periodicidad IdPeriodicidad { get; set; }

        [Required]
        public DateTime FechaProyectadaFin { get; set; }
    }
}
