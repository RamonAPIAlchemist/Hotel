using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly HabitacionServices _habitacionServices;

        public HabitacionController(HabitacionServices habitacionServices)
        {
            _habitacionServices = habitacionServices;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<List<Habitacion>>> GetId(int id)
        {
            var habitacion = await _habitacionServices.GetHabitacion(id);
            if (habitacion == null)
            {
                return NotFound(); // Retorna 404 si no se encuentra la habitación
            }
            return Ok(habitacion);
        }

        [HttpPost("Post")]
        public async Task<ActionResult> Post([FromBody] Habitacion Ohabitacion)
        {
            await _habitacionServices.PostHabitacion(Ohabitacion);
            return Ok("Habitacion registrada");
        }

       // [HttpPut("Put")]
       // public async Task<ActionResult> Put([FromBody] Habitacion Ohabitacion)
       // {
           // await _habitacionServices.PutHabitacion(Ohabitacion);
           // return Ok("Habitacion actualizada");
        //}

        [HttpPut("Put/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Habitacion Ohabitacion)
        {
            Ohabitacion.id_habitacion = id; // Asegura que el ID se asigne a la habitación
            await _habitacionServices.PutHabitacion(Ohabitacion);
            return Ok("Habitacion actualizada");
        }


        [HttpDelete]
        [Route("Delete/{id}")] // Cambiado para incluir el separador
        public async Task<ActionResult<List<Habitacion>>> DeleteHabitacion(int id)
        {
            var result = await _habitacionServices.DeleteHabitacion(id);
            if (result == null)
            {
                return NotFound(); // Retorna 404 si no se encuentra la habitación
            }

            return Ok("Habitacion eliminada");
        }
    }
}
