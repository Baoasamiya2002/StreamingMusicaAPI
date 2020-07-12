using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GeneroController : ControllerBase
    {
        private readonly StreamingMusicaContext _contexto;

        public GeneroController(StreamingMusicaContext contexto){
            _contexto = contexto;
        } 

        [HttpGet]
        [Route("")]
        public IActionResult getAllGeneros()
        {
            var generos = _contexto.Generos.ToList();
            return Ok(generos);
        }

        [HttpGet]
        [Route("busqueda/{palabra}")]
        public IActionResult getGeneros(string palabra)
        {
            var generos = _contexto.Generos.Where(generoBD => generoBD.Nombre_genero.Contains(palabra)).ToList();
            return Ok(generos);
        }

        [HttpGet]
        [Route("id")]
        public IActionResult getGeneroById(int id)
        {
            var genero = _contexto.Generos.FirstOrDefault(generoBD => generoBD.Id == id);
            if (genero == null)
            {
                return NotFound();
            }
            return Ok(genero);
        }

        [HttpPost]
        [Route("crear")]
        public IActionResult setGenero(Genero genero)
        {
            _contexto.Generos.Add(genero);
            _contexto.SaveChanges();   
            CreatedAtAction(nameof(getGeneroById), new { genero.Id }, genero);
            var nuevoGenero = new Genero();
            nuevoGenero.Id = genero.Id;
            return Ok(nuevoGenero);
        }
    }
}