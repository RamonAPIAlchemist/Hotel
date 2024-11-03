using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class HabitacionReserva
    {
        [Key]
        public int id_habitacion_reserva { get; set; }

        [Required]
        public int id_reserva { get; set; }

        [Required]
        public int id_habitacion { get; set; }

        [Required]
        public int precio_noche { get; set; }

        [Required]
        public int cantidad_noches { get; set; }
    }
}
