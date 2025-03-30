using Microsoft.AspNetCore.Mvc;

//using System.Collections.Generic;

namespace TPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JugadorController : ControllerBase
    {
        
        public class Jugador
        {
            public int IdJugador { get; set; }
            public string Alias { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int TorneosGanados { get; set; }
        }

        [HttpPost]
        public IActionResult CreateJugador([FromBody] Jugador jugador)
        {
          
            return CreatedAtAction(nameof(GetJugadorById), new { id = jugador.IdJugador }, jugador);
        }

        [HttpGet]
        public IActionResult GetJugadores()
        {
          
            var jugadores = new List<Jugador>
            {
                new Jugador { IdJugador = 1, Alias = "ElMaestro", Nombre = "Pedro", Apellido = "Ruiz", TorneosGanados = 3 },
                new Jugador { IdJugador = 2, Alias = "ChicaPro", Nombre = "Sof�a", Apellido = "Mart�nez", TorneosGanados = 5 }
            };

            return Ok(jugadores);
        }

        [HttpGet("{id}")]
        public IActionResult GetJugadorById(int id)
        {
           
            var jugador = new Jugador { IdJugador = id, Alias = "ElMaestro", Nombre = "Pedro", Apellido = "Ruiz", TorneosGanados = 3 };

            if (jugador == null)
            {
                return NotFound();
            }

            return Ok(jugador);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJugador(int id, [FromBody] Jugador jugador)
        {
            if (id != jugador.IdJugador)
            {
                return BadRequest("El ID del jugador no coincide.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJugador(int id)
        {
            
            return NoContent();
        }
    }
}
