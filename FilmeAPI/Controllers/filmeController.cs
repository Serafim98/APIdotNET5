using FilmeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class filmeController:ControllerBase
    {
        static int id = 1;
        private static List<Filme> filmes = new List<Filme>();
        [HttpPost]
        public IActionResult addFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(recuperarFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult recuperarFilmes()
        {
            return Ok(filmes);
        }


        [HttpGet("{id}")]
        public IActionResult recuperarFilmesPorId(int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
                return Ok(filme);
            return NotFound();
        }
    }
}
