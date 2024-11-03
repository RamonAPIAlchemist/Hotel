using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Habitacion
    {
        [Key]
        public int id_habitacion { get; set; }

        [Required]
        [StringLength(20)]
        public string numero { get; set; }

        [Required]
        [StringLength(20)]
        public string tipo { get; set; }

        [Required]
        public int capacidad { get; set; }


        [Required]
        public int precio_base { get; set; }

        [Required]
        public string estado { get; set; }


    }
}
