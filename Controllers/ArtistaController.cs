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

    public class ArtistaController : ControllerBase
    {
        private readonly StreamingMusicaContext _contexto;

        public ArtistaController(StreamingMusicaContext contexto){
            _contexto = contexto;
        }

        [HttpGet]
        [Route("")]
        public IActionResult getAllArtistas()
        {
            var artistas = _contexto.Artistas.ToList();
            return Ok(artistas);
        } 

        [HttpGet]
        [Route("busqueda/{palabra}")]
        public IActionResult getArtistas(string palabra)
        {
            var artistas = _contexto.Artistas.Where(artistaBD => artistaBD.Nombre_artista.Contains(palabra)).ToList();
            return Ok(artistas);
        }

        [HttpGet]
        [Route("id")]
        public IActionResult getArtistaById(int id)
        {
            var artista = _contexto.Artistas.FirstOrDefault(artistaBD => artistaBD.Id == id);
            if (artista == null)
            {
                return NotFound();
            }
            return Ok(artista);
        }

        [HttpPost]
        [Route("crear")]
        public IActionResult setArtista(Artista artista)
        {
            _contexto.Artistas.Add(artista);
            _contexto.SaveChanges();   
            CreatedAtAction(nameof(getArtistaById), new { artista.Id }, artista);
            var nuevoArtista = new Artista();
            nuevoArtista.Id = artista.Id;
            return Ok(nuevoArtista);
        }
    }
}