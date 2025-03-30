using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

namespace TPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizadorController : ControllerBase
    {
      
        public class Organizador
        {
            public int IdOrganizador { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Empresa { get; set; } 
        }

        [HttpPost]
        public IActionResult CreateOrganizador([FromBody] Organizador organizador)
        {
           
            return CreatedAtAction(nameof(GetOrganizadorById), new { id = organizador.IdOrganizador }, organizador);
        }

        [HttpGet]
        public IActionResult GetOrganizadores()
        {
        
            var organizadores = new List<Organizador>
            {
                new Organizador { IdOrganizador = 1, Nombre = "Carlos", Apellido = "Lopez", Empresa = "Torneos SA" },
                new Organizador { IdOrganizador = 2, Nombre = "Ana", Apellido = "Martinez", Empresa = "Eventos SL" }
            };

            return Ok(organizadores);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrganizadorById(int id)
        {
          
            var organizador = new Organizador { IdOrganizador = id, Nombre = "Carlos", Apellido = "L�pez", Empresa = "Torneos SA" };

            if (organizador == null)
            {
                return NotFound();
            }

            return Ok(organizador);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrganizador(int id, [FromBody] Organizador organizador)
        {
            if (id != organizador.IdOrganizador)
            {
                return BadRequest("El ID del organizador no coincide.");
            }

            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrganizador(int id)
        {
           
            return NoContent();
        }
    }
}
