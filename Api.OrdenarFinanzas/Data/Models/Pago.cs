using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.OrdenarFinanzas.Data.Models
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdPago { get; set; }

        [Required]
        public string DescripcionPago { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public long IdSubtipo { get; set; }

        [ForeignKey("IdTipoPago")]
        public virtual TipoPago IdTipoPago { get; set; }


    }
}
