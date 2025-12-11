using API_Clinica.Autenticación;
using API_Clinica.Data;
using API_Clinica.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API_Clinica.Controllers
{
    [BasicAuthentication]
    [Route("api/[controller]")]
    [ApiController]

    public class HistorialController : Controller
    {
        HistorialQuery estQuery;

        public HistorialController()
        {
            estQuery = new HistorialQuery();
        }

        // GET: api/<HistorialController>
        [HttpGet]
        public List<HistorialMedico> Get()
        {
            List<HistorialMedico> historialMedicos = estQuery.GetHistoriales();
            return historialMedicos;
        }

        // GET api/<HistorialController>/5
        [HttpGet("{id}")]
        public HistorialMedico Get(string id)
        {
            HistorialMedico historial = estQuery.BuscarHistorial(id);
            return historial;
        }

        // POST api/<HistorialController>
        [HttpPost]
        public void Post([FromBody] HistorialMedico historial)
        {
            estQuery.AgregarHistorial(historial);
        }

        // PUT api/<HistorialController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] HistorialMedico historial)
        {
            estQuery.ActualizarCita(id, historial);
        }
    }
}
