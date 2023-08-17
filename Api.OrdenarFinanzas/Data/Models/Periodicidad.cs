using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.OrdenarFinanzas.Data.Models
{
    public class Periodicidad
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdPeriodicidad { get; set; }

        [Required]
        public string DescripcionPeriodicidad { get; set; }

    }
}
