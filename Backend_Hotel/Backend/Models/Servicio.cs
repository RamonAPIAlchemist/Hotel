using System.ComponentModel.DataAnnotations;
namespace Backend.Models
{
    public class Servicio
    {

        [Key]
        public int id_servicio { get; set; }


        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }

        [Required]
        public int precio { get; set; }



    }
}

