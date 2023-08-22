using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.OrdenarFinanzas.Data.Models
{
    public class TipoGastoFijo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdTipoGastoFijo { get; set; }

        [Required]
        public string DescripcionTipoGastoFijo { get; set; }

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
