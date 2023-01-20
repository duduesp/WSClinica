using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }


        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        public int NroHistClinica { get; set; }

        public Medico Medico { get; set; }
    }
}
