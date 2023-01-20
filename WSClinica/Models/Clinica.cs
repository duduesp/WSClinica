using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WSClinica.Models
{
    
        public class Clinica
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public DateTime FechaInicioActividades { get; set; }


        [Required]
        [Column(TypeName = "varchar(60)")]
        public string Email { get; set; }

        public List<Habitacion> Habitaciones { get; set; }
        }
    }
