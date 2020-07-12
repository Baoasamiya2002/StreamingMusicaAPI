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

    public class CancionController : ControllerBase
    {
        private readonly StreamingMusicaContext _contexto;

        public CancionController(StreamingMusicaContext contexto){
            _contexto = contexto;
        }

        [HttpGet]
        [Route("genero/{idGenero}")]
        public IActionResult getCancionesPorGenero(int idGenero)
        {
            var canciones = _contexto.Canciones.Where(cancionBD => cancionBD.GeneroId == idGenero).ToList();
            return Ok(canciones);
        }

        [HttpGet]
        [Route("listaReproduccion/{idLista}")]
        public IActionResult getCancionesPorLista(int idLista)
        {
            var cancionesId = _contexto.CancionLista_reproduccion.
                Where(listaBD => listaBD.Lista_reproduccionId == idLista).
                Select(listaBD => listaBD.CancionId).ToList();
            return Ok(cancionesId);
        } 

        [HttpGet]
        [Route("album/{idAlbum}")]
        public IActionResult getCancionesPorAlbum(int idAlbum)
        {
            var canciones = _contexto.Canciones.Where(cancionBD => cancionBD.AlbumId == idAlbum).ToList();
            return Ok(canciones);
        } 

        [HttpGet]
        [Route("busqueda/{palabra}")]
        public IActionResult getCanciones(string palabra)
        {
            var canciones = _contexto.Canciones.Where(cancionBD => cancionBD.Nombre_cancion.Contains(palabra)).ToList();
            return Ok(canciones);
        }

        [HttpGet]
        [Route("id")]
        public IActionResult getCancionById(int id)
        {
            var cancion = _contexto.Canciones.FirstOrDefault(cancionBD => cancionBD.Id == id);
            if (cancion == null)
            {
                return NotFound();
            }
            return Ok(cancion);
        }

        [HttpPost]
        [Route("crear")]
        public IActionResult setCancion(Cancion cancion)
        {
            _contexto.Canciones.Add(cancion);
            _contexto.SaveChanges();   
            CreatedAtAction(nameof(getCancionById), new { cancion.Id }, cancion);
            var nuevoCancion = new Cancion();
            nuevoCancion.Id = cancion.Id;
            return Ok(nuevoCancion);
        }
    }
}