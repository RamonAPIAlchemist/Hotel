using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaServices _reservaServices;

        public ReservaController(ReservaServices reservaServices)
        {
            _reservaServices = reservaServices;
        }

        //-------------------Get------------------------------
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> Get(int id)
        {
            var reserva = await _reservaServices.GetReserva(id);
            if (reserva != null)
            {
                return Ok(reserva);
            }
            return NotFound("Reserva no encontrada");
        }

        //-------------------Post------------------------------
        [HttpPost]
        public async Task<ActionResult> Post(Reserva reserva)
        {
            await _reservaServices.PostReserva(reserva);
            return Ok("Reserva registrada");
        }

        //-------------------Put------------------------------
        [HttpPut]
        public async Task<ActionResult> Put(Reserva reserva)
        {
            var result = await _reservaServices.PutReserva(reserva);
            if (result)
            {
                return Ok("Reserva actualizada");
            }
            return NotFound("Reserva no encontrada");
        }

        //-------------------Delete------------------------------
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _reservaServices.DeleteReserva(id);
            if (result)
            {
                return Ok("Reserva eliminada");
            }
            return NotFound("Reserva no encontrada");
        }
    }
}
