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
    public class LibroController : ControllerBase
    {

        LibroQuery estQuery;

        public LibroController()
        {
            estQuery = new LibroQuery();
        }


        // GET: api/<LibroController>
        [HttpGet]
        public List<Libro> Get()
        {
            List<Libro> libros = estQuery.GetLibros();
            return libros;
        }


        // GET api/<LibroController>/5
        [HttpGet("{id}")]
        public Libro Get(string id)
        {
            Libro bibliotecario = estQuery.BuscarLibro(id);
            return bibliotecario;
        }


        // POST api/<LibroController>
        [HttpPost]
        public void Post([FromBody] Libro libro)
        {
            estQuery.AgregarLibro(libro);
        }

        // PUT api/<LibroController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Libro libro)
        {
            estQuery.ActualizarLibro(id, libro);
        }

        // DELETE api/<LibroController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            estQuery.InactivarLibro(id);
        }
    }
}

