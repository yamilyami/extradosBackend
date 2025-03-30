using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

namespace TPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JuegoController : ControllerBase
    {
       
        public class Juego
        {
            public int IdJuego { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public string Jugador1 { get; set; } 
            public string Jugador2 { get; set; } 
            public int IdTorneo { get; set; }
            public string Ganador { get; set; } 
        }

        [HttpPost]
        public IActionResult CreateJuego([FromBody] Juego juego)
        {
           
            return CreatedAtAction(nameof(GetJuegoById), new { id = juego.IdJuego }, juego);
        }

        [HttpGet]
        public IActionResult GetJuegos()
        {
          
            var juegos = new List<Juego>
            {
                new Juego
                {
                    IdJuego = 1,
                    FechaInicio = new DateTime(2025, 1, 20, 15, 0, 0),
                    FechaFin = new DateTime(2025, 1, 20, 15, 30, 0),
                    Jugador1 = "JugadorA",
                    Jugador2 = "JugadorB",
                    IdTorneo = 1,
                    Ganador = "JugadorA"
                },
                new Juego
                {
                    IdJuego = 2,
                    FechaInicio = new DateTime(2025, 1, 21, 10, 0, 0),
                    FechaFin = new DateTime(2025, 1, 21, 10, 30, 0),
                    Jugador1 = "JugadorC",
                    Jugador2 = "JugadorD",
                    IdTorneo = 1,
                    Ganador = "JugadorD"
                }
            };

            return Ok(juegos);
        }

        [HttpGet("{id}")]
        public IActionResult GetJuegoById(int id)
        {
          
            var juego = new Juego
            {
                IdJuego = id,
                FechaInicio = new DateTime(2025, 1, 20, 15, 0, 0),
                FechaFin = new DateTime(2025, 1, 20, 15, 30, 0),
                Jugador1 = "JugadorA",
                Jugador2 = "JugadorB",
                IdTorneo = 1,
                Ganador = "JugadorA"
            };

            if (juego == null)
            {
                return NotFound();
            }

            return Ok(juego);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJuego(int id, [FromBody] Juego juego)
        {
            if (id != juego.IdJuego)
            {
                return BadRequest("El ID del juego no coincide.");
            }

           
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJuego(int id)
        {
            
            return NoContent();
        }
    }
}
