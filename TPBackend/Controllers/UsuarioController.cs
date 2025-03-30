using Microsoft.AspNetCore.Mvc;

namespace TPBackend.Controllers
{
     [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        // Clase Usuario que coincide con la estructura de tu tabla
        public class Usuario
        {
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Alias { get; set; }
            public string Email { get; set; }
            public string Pais { get; set; }
            public string Foto { get; set; }
            public int IdRol { get; set; }
        }

       [HttpPost]
        public IActionResult CreateUsuario([FromBody] Usuario usuario)
        {
            // exito
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            // Simulación de obtener usuarios de la base de datos
            var usuarios = new List<Usuario>
        {
            new Usuario
            {
                IdUsuario = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Alias = "jperez",
                Email = "jperez@example.com",
                Pais = "Argentina",
                Foto = "foto1.jpg",
                IdRol = 2
            }
        };
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            var usuario = new Usuario
            {
                IdUsuario = id,
                Nombre = "Juan",
                Apellido = "Pérez",
                Alias = "jperez",
                Email = "jperez@example.com",
                Pais = "Argentina",
                Foto = "foto1.jpg",
                IdRol = 2
            };

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest("El ID del usuario no coincide.");
            }

            // lógica para actualizar el usuario 

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            // lógica para eliminar el usuario

            return NoContent();
        }
    }
}

