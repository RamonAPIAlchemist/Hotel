using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitacionReservaController : ControllerBase
    {
        private readonly HabitacionReservaServices _habitacionReservaServices;

        public HabitacionReservaController(HabitacionReservaServices habitacionReservaServices)
        {
            _habitacionReservaServices = habitacionReservaServices;
        }

        //-------------------Get------------------------------
        [HttpGet("{id}")]
        public async Task<ActionResult<HabitacionReserva>> Get(int id)
        {
            var habitacionReserva = await _habitacionReservaServices.GetHabitacionReserva(id);
            if (habitacionReserva != null)
            {
                return Ok(habitacionReserva);
            }
            return NotFound("Habitación de reserva no encontrada");
        }

        //-------------------Post------------------------------
        [HttpPost]
        public async Task<ActionResult> Post(HabitacionReserva habitacionReserva)
        {
            await _habitacionReservaServices.PostHabitacionReserva(habitacionReserva);
            return Ok("Habitación de reserva registrada");
        }

        //-------------------Put------------------------------
        [HttpPut]
        public async Task<ActionResult> Put(HabitacionReserva habitacionReserva)
        {
            var result = await _habitacionReservaServices.PutHabitacionReserva(habitacionReserva);
            if (result)
            {
                return Ok("Habitación de reserva actualizada");
            }
            return NotFound("Habitación de reserva no encontrada");
        }

        //-------------------Delete------------------------------
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _habitacionReservaServices.DeleteHabitacionReserva(id);
            if (result)
            {
                return Ok("Habitación de reserva eliminada");
            }
            return NotFound("Habitación de reserva no encontrada");
        }
    }
}
