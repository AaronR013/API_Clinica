using API_Clinica.Autenticación;
using API_Clinica.Data;
using API_Clinica.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API_Clinica.Controllers
{
    [BasicAuthentication]
    [Route("api/[controller]")]
    [ApiController]

    public class MedicoController : Controller
    {
        MedicoQuery estQuery;

        public MedicoController()
        {
            estQuery = new MedicoQuery();
        }

        // GET: api/<MedicoController>
        [HttpGet]
        public List<Medico> Get()
        {
            List<Medico> medicos = estQuery.GetMedicos();
            return medicos;
        }

        // GET api/<MedicoController>/5
        [HttpGet("{id}")]
        public Medico Get(string id)
        {
            Medico medico = estQuery.BuscarMedico(id);
            return medico;
        }

        // POST api/<MedicoController>
        [HttpPost]
        public void Post([FromBody] Medico medico)
        {
            estQuery.AgregarMedico(medico);
        }

        // PUT api/<MedicoController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Medico medico)
        {
            estQuery.ActualizarMedico(id, medico);
        }

        // DELETE api/<MedicoController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            estQuery.InactivarMedico(id);
        }
    }
}
