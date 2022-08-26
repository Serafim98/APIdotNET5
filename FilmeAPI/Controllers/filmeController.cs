using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dto;
using FilmeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class filmeController:ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public filmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        static int id = 1;
        private static List<Filme> filmes = new List<Filme>();
        [HttpPost]
        public IActionResult addFilme([FromBody] createFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(recuperarFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> recuperarFilmes()
        {
            return _context.Filmes;
        }


        [HttpGet("{id}")]
        public IActionResult recuperarFilmesPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                readFilmeDto filmeDto = _mapper.Map<readFilmeDto>(filme);
                return Ok(filme);
            }
                
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] updateFilmeDto filmeDto)
        {
            Filme filme = new Filme();
            if(filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
