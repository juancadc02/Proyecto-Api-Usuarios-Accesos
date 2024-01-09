using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proyecto_Api_Usuarios_Accesos.Contexto;
using Proyecto_Api_Usuarios_Accesos.Modelos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        private readonly IConfiguration _configuration;

        public ControladorUsuarios(gestorBibliotecaDbContext contexto, IConfiguration configuration)
        {
            this.contexto = contexto;
            _configuration = configuration;
        }

        // GET: api/<ControladorUsuarios>
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return contexto.Usuarios.ToList();
        }

       
        // POST: api/<ControladorUsuarios>
        [HttpPost("anadirUsu")]
        public IActionResult anadirUsu([FromBody] Usuarios usuario)
        {
            try
            {
                if (ModelState.IsValid) // Verifica si el modelo es válido
                {
                    contexto.Usuarios.Add(usuario);
                    contexto.SaveChanges();

                    return Ok(new { message = "Usuario registrado correctamente", usuario });
                }
                return BadRequest("Datos del usuario no válidos");
            }
            catch (Exception ex)
            {
                // Registra el error para diagnóstico
                Console.WriteLine($"Error al registrar el usuario: {ex}");
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }
        [HttpPost("iniciarSesion")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Aquí deberías implementar la lógica para verificar el usuario y contraseña contra tu base de datos o sistema de autenticación.
            // Por simplicidad, este es un ejemplo básico:
            if (ValidarUsuario(model.email_usuario, model.clave_usuario))
            {
                var token = GenerateJwtToken(model.email_usuario);
                return Ok(new { token });
            }

            return Unauthorized("Credenciales inválidas");
        }

        private bool ValidarUsuario(string email_usuario, string clave_usuario)
        {
            // Crear una instancia de DbContext (esto depende de cómo hayas configurado tu proyecto y servicios)
            // Aquí estoy suponiendo que tienes una inyección de dependencias para ApplicationDbContext.
            using (var context = new gestorBibliotecaDbContext())
            {
                // Consultar el usuario por email
                var email_usuaril = context.Usuarios.FirstOrDefault(u => u.email_usuario == email_usuario);

                // Verificar si se encontró el usuario y si la contraseña coincide (en un escenario real, deberías comparar hash de contraseñas)
                if (email_usuaril != null && email_usuaril.clave_usuario == clave_usuario)
                {
                    return true;
                }

                return false;
            }
        }

        private string GenerateJwtToken(string email_usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email_usuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // ID único para el token
                // Aquí puedes agregar más claims según tus necesidades.
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:ExpireHours"])); // Expira en un número de horas configurado

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string email_usuario { get; set; }
        public string clave_usuario { get; set; }
    }

}
