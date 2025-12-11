using API_Clinica.Autenticación;
using API_Clinica.Data;
using API_Clinica.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API_Clinica.Controllers
{
    [BasicAuthentication]
    [Route("api/[controller]")]
    [ApiController]

    public class PacienteController : Controller
    {
        PacienteQuery estQuery;

        public PacienteController()
        {
            estQuery = new PacienteQuery();
        }

        // GET: api/<PacienteController>
        [HttpGet]
        public List<Paciente> Get()
        {
            List<Paciente> pacientes = estQuery.GetPacientes();
            return pacientes;
        }

        // GET api/<PacienteController>/5
        [HttpGet("{cedula}")]
        public Paciente Get(string cedula)
        {
            Paciente paciente = estQuery.BuscarPaciente(cedula);
            return paciente;
        }

        // POST api/<PacienteController>
        [HttpPost]
        public void Post([FromBody] Paciente paciente)
        {
            estQuery.AgregarPaciente(paciente);
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Paciente paciente)
        {
            estQuery.ActualizarPaciente(id, paciente);
        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            estQuery.InactivarPaciente(id);
        }
    }
}
