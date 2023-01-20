using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    public class Habitacion
    {
        public int Id { get; set; }

        [Range(1, 100, ErrorMessage = "Solo se permite números entre 1 y 100")]
        public int Numero { get; set; }

        [Required]
        [Column(TypeName = "varchar(60)")]
        public string Estado { get; set; }


        public int ClinicaId { get; set; }

        [ForeignKey("ClinicaId")]


        public Clinica Clinica { get; set; }
    }
}
