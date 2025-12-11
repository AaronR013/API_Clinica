using API_Clinica.Autenticación;
using API_Clinica.Data;
using API_Clinica.Modelo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Clinica.Controllers
{

    [BasicAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecarioController : ControllerBase
    {

        BibliotecarioQuery estQuery;

        public BibliotecarioController()
        {
            estQuery = new BibliotecarioQuery();
        }


        // GET: api/<BibliotecarioController>
        [HttpGet]
        public List<Bibliotecario> Get()
        {
            List<Bibliotecario> bibliotecarios = estQuery.GetBibliotecarios();
            return bibliotecarios;
        }


        // GET api/<BibliotecarioController>/5
        [HttpGet("{id}")]
        public Bibliotecario Get(string id)
        {
            Bibliotecario bibliotecario = estQuery.BuscarBibliotecario(id);
            return bibliotecario;
        }


        // POST api/<BibliotecarioController>
        [HttpPost]
        public void Post([FromBody] Bibliotecario bibliotecario)
        {
            estQuery.AgregarBibliotecario(bibliotecario);
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Bibliotecario bibliotecario)
        {
            estQuery.ActualizarBibliotecario(id, bibliotecario);
        }

        // DELETE api/<BibliotecarioController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            estQuery.InactivarBibliotecario(id);
        }
    }
}



