using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly ServicioServices _servicioServices;
        public ServicioController(ServicioServices servicioServices)
        {
            _servicioServices = servicioServices;
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<List<Servicio>>> GetId(int id)
        {
            var servicio = await _servicioServices.GetServicio(id);
            return Ok(servicio);
        }

        [HttpPost("Post")]
        public async Task<ActionResult> Post([FromBody] Servicio Oservicio)
        {
            await _servicioServices.PostServicio(Oservicio);
            return Ok("Servicio registrada");
        }


        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] Servicio Oservicio)
        {
            await _servicioServices.PutServicio(Oservicio);
            return Ok("Servicio actualizado");
        }

        [HttpDelete]
        [Route("Delete{id}")]

        public async Task<ActionResult<List<Servicio>>> DeleteServicio(int id)
        {
            var estudiante = await _servicioServices.DeleteServicio(id);

            return Ok("Servicio eliminado");
        }
    }
}
