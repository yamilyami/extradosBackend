using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;

namespace TPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartaController : ControllerBase
    {
      
        public class Carta
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Ilustracion { get; set; }
            public int Ataque { get; set; }
            public int Defensa { get; set; }
            public List<int> SeriesIds { get; set; } 
        }

      
        public class Serie
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public List<int> CartasIds { get; set; } 
            public DateTime FechaSalida { get; set; }
        }
        private static List<Carta> cartas = new List<Carta>();
        private static List<Serie> series = new List<Serie>();

        [HttpGet]
        public IActionResult GetCartas()
        {
            return Ok(cartas);
        }

        [HttpGet("{id}")]
        public IActionResult GetCartaById(int id)
        {
            var carta = cartas.FirstOrDefault(c => c.Id == id);
            if (carta == null)
                return NotFound("Carta no encontrada.");

            return Ok(carta);
        }

        [HttpPost]
        public IActionResult CreateCarta([FromBody] Carta nuevaCarta)
        {
            if (cartas.Any(c => c.Id == nuevaCarta.Id))
                return BadRequest("Ya existe una carta con este ID.");

            cartas.Add(nuevaCarta);

            foreach (var serieId in nuevaCarta.SeriesIds)
            {
                var serie = series.FirstOrDefault(s => s.Id == serieId);
                if (serie != null)
                {
                    if (serie.CartasIds == null)
                        serie.CartasIds = new List<int>();

                    serie.CartasIds.Add(nuevaCarta.Id);
                }
            }

            return CreatedAtAction(nameof(GetCartaById), new { id = nuevaCarta.Id }, nuevaCarta);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCarta(int id, [FromBody] Carta cartaActualizada)
        {
            var cartaExistente = cartas.FirstOrDefault(c => c.Id == id);
            if (cartaExistente == null)
                return NotFound("Carta no encontrada.");

         
            cartaExistente.Nombre = cartaActualizada.Nombre;
            cartaExistente.Ilustracion = cartaActualizada.Ilustracion;
            cartaExistente.Ataque = cartaActualizada.Ataque;
            cartaExistente.Defensa = cartaActualizada.Defensa;
            cartaExistente.SeriesIds = cartaActualizada.SeriesIds;

       
            foreach (var serie in series)
            {
                if (cartaActualizada.SeriesIds.Contains(serie.Id))
                {
                    if (!serie.CartasIds.Contains(cartaExistente.Id))
                        serie.CartasIds.Add(cartaExistente.Id);
                }
                else
                {
                    serie.CartasIds.Remove(cartaExistente.Id);
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCarta(int id)
        {
            var carta = cartas.FirstOrDefault(c => c.Id == id);
            if (carta == null)
                return NotFound("Carta no encontrada.");

            cartas.Remove(carta);

            // eliminar la carta 
            foreach (var serie in series)
            {
                serie.CartasIds.Remove(id);
            }

            return NoContent();
        }
    }
}
