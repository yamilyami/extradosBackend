using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

namespace TPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JuezController : ControllerBase
    {
       
        public class Juez
        {
            public int IdJuez { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Certificacion { get; set; }
        }

        [HttpPost]
        public IActionResult CreateJuez([FromBody] Juez juez)
        {
            
            return CreatedAtAction(nameof(GetJuezById), new { id = juez.IdJuez }, juez);
        }

        [HttpGet]
        public IActionResult GetJueces()
        {
          
            var jueces = new List<Juez>
            {
                new Juez { IdJuez = 1, Nombre = "Juan", Apellido = "Perez", Certificacion = "Nivel 1" },
                new Juez { IdJuez = 2, Nombre = "Maria", Apellido = "Gomez", Certificacion = "Nivel 2" }
            };

            return Ok(jueces);
        }

        [HttpGet("{id}")]
        public IActionResult GetJuezById(int id)
        {
           
            var juez = new Juez { IdJuez = id, Nombre = "Juan", Apellido = "Perez", Certificacion = "Nivel 1" };

            if (juez == null)
            {
                return NotFound();
            }

            return Ok(juez);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJuez(int id, [FromBody] Juez juez)
        {
            if (id != juez.IdJuez)
            {
                return BadRequest("El ID del juez no coincide.");
            }

         
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJuez(int id)
        {
            return NoContent();
        }
    }
}
