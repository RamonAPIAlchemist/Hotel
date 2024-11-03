using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuespedController : Controller
    {
        private readonly HuespedServices _huespedServices;

        public HuespedController(HuespedServices huespedServices)
        {
            _huespedServices = huespedServices;
        }

        //-------------------Get------------------------------
        [HttpGet]
        [Route("GetId/{id}")]
        public async Task<ActionResult<Huesped>> GetId(int id)
        {
            var huesped = await _huespedServices.GetHuesped(id);
            if (huesped != null)
            {
                return Ok(huesped);
            }
            return NotFound("Huesped no encontrado");
        }

        //-------------------Post------------------------------
        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult> Post(Huesped huesped)
        {
            await _huespedServices.PostHuesped(huesped);
            return Ok("Huesped registrado");
        }

        //-------------------Put------------------------------
        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult> Put(Huesped huesped)
        {
            var result = await _huespedServices.PutHuesped(huesped);
            if (result)
            {
                return Ok("Huésped actualizado");
            }
            return NotFound("Huésped no encontrado");
        }

        //-------------------Delete------------------------------
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _huespedServices.DeleteHuesped(id);
            if (result)
            {
                return Ok("Huesped eliminado");
            }
            return NotFound("Huesped no encontrado");
        }
    }
}
