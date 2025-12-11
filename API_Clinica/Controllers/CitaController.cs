using API_Clinica.Autenticación;
using API_Clinica.Data;
using API_Clinica.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API_Clinica.Controllers
{
    [BasicAuthentication]
    [Route("api/[controller]")]
    [ApiController]

    public class CitaController : Controller
    {
        CitaQuery estQuery;

        public CitaController()
        {
            estQuery = new CitaQuery();
        }

        // GET: api/<CitaController>
        [HttpGet]
        public List<CitaMedica> Get()
        {
            List<CitaMedica> citaMedicas = estQuery.GetCitas();
            return citaMedicas;
        }

        // GET api/<CitaController>/5
        [HttpGet("{id}")]
        public CitaMedica Get(string id)
        {
            CitaMedica cita = estQuery.BuscarCita(id);
            return cita;
        }

        // POST api/<CitaController>
        [HttpPost]
        public void Post([FromBody] CitaMedica cita)
        {
            estQuery.AgregarCita(cita);
        }

        // PUT api/<CitaController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CitaMedica cita)
        {
            estQuery.ActualizarCita(id, cita);
        }

        // DELETE api/<CitaController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            estQuery.InactivarCita(id);
        }
    }
}
