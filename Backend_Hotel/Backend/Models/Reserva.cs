using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Reserva
    {
        [Key]
        public int id_reserva { get; set; }

        [Required]
        public int id_huesped { get; set; }

        [Required]
        public int id_servicio { get; set; }

        [Required]
        [StringLength(8)]
        public string fecha_reserva { get; set; }

        [Required]
        [StringLength(8)]
        public string fecha_ingreso { get; set; }

        [Required]
        [StringLength(8)]
        public string fecha_salida { get; set; }

        [Required]
        [StringLength(20)]
        public string estado { get; set; }
    }
}
