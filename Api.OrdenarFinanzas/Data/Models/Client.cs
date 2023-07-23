using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.OrdenarFinanzas.Data.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdCliente { get; set; }

        [Required]
        public string NombresCliente { get; set; }

        [Required]
        public string Apellido1Cliente { get; set; }

        [Required]
        public string Apellido2Cliente { get; set; }

        [Required]
        public string NroDocCliente { get; set; }

        [Required]
        public string EmailCliente { get; set; }

        [Required]
        public string TelContactoCliente { get; set; }

    }
}
