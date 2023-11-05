using Microsoft.AspNetCore.Mvc;
using Proyecto_Api_Usuarios_Accesos.Contexto;
using Proyecto_Api_Usuarios_Accesos.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Api_Usuarios_Accesos.Controllers
{
    /// <summary>
    /// Controlador de la tabla usuarios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorUsuarios : ControllerBase
    {
        private readonly gestorBibliotecaDbContext contexto;
        public ControladorUsuarios(gestorBibliotecaDbContext contexto)
        {
            this.contexto = contexto;
        }

        // GET: api/<ControladorUsuarios>
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return contexto.Usuarios.ToList();
        }

        [HttpPost("añadirUsuario")]
        public async Task<IActionResult> añadirUsuario([FromBody] Usuarios nuevoUsuario)
        {
            if (nuevoUsuario == null)
            {
                return BadRequest("Los datos del acceso no son validos");

            }
            contexto.Usuarios.Add(nuevoUsuario);
            await contexto.SaveChangesAsync();
            return Ok("Usuario añadido");
        }

        // GET api/<ControladorUsuarios>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ControladorUsuarios>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ControladorUsuarios>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ControladorUsuarios>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
