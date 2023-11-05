using Microsoft.AspNetCore.Mvc;
using Proyecto_Api_Usuarios_Accesos.Contexto;
using Proyecto_Api_Usuarios_Accesos.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Api_Usuarios_Accesos.Controllers
{
    /// <summary>
    /// Controlador de la tabla accesos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorAccesos : ControllerBase
    {
        private readonly gestorBibliotecaDbContext contexto;
        public ControladorAccesos(gestorBibliotecaDbContext contexto)
        {
            this.contexto = contexto;
        }

        // GET: api/<ControladorAccesos>
        [HttpGet]
        public IEnumerable<Accesos> Get()
        {
            return contexto.Accesos.ToList();
        }

        [HttpPost("añadirAcceso")]
        public async Task<IActionResult> añadirAcceso([FromBody]Accesos nuevoAcceso)
        {
            if (nuevoAcceso == null)
            {
                return BadRequest("Los datos del acceso no son validos");

            }
            contexto.Accesos.Add(nuevoAcceso);
            await contexto.SaveChangesAsync();
            return Ok("Acceso añadido");
        }
        // GET api/<ControladorAccesos>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ControladorAccesos>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ControladorAccesos>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ControladorAccesos>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
