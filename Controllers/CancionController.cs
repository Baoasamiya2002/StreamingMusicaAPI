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
        [Route("")]
        public IActionResult getCanciones()
        {
            var canciones = _contexto.Canciones.ToList();
            return Ok(canciones);
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
            var cancionesLista = _contexto.CancionLista_reproduccion.ToList();
            return Ok(cancionesLista);
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
            var canciones = _contexto.Canciones.
            Join(
                _contexto.Albums,
                cancionBD => cancionBD.AlbumId,
                albumBD => albumBD.Id,
                (cancionBD, albumBD) => new
                {
                    Id = cancionBD.Id,
                    Nombre_cancion = cancionBD.Nombre_cancion,
                    Album = albumBD.Nombre_album
                }).
                Where(cancionBD => cancionBD.Nombre_cancion.Contains(palabra)).ToList();
            return Ok(canciones);
        }

        [HttpGet]
        [Route("byId/{id}")]
        public IActionResult getCancionById(int id)
        {
            var cancion = _contexto.Canciones.Find(id);            
            Byte[] bytes = System.IO.File.ReadAllBytes(cancion.ruta);
            String file = Convert.ToBase64String(bytes);
            cancion.cancion64 = file;

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
            var ruta = "C:/Users/edson/Desktop/cancionesServer/";
            Cancion cancionAbd = cancion;
            
            byte [] cancionbytes = Convert.FromBase64String(cancion.cancion64);
            System.IO.File.WriteAllBytes(ruta + cancionAbd.Nombre_cancion + ".mp3", cancionbytes);

            cancionAbd.cancion64 = "";
            cancionAbd.ruta = ruta + cancionAbd.Nombre_cancion + ".mp3";
            _contexto.Canciones.Add(cancionAbd);


            _contexto.SaveChanges();   
            CreatedAtAction(nameof(getCancionById), new { cancion.Id }, cancion);
            var nuevoCancion = new Cancion();
            nuevoCancion.Id = cancion.Id;
            return Ok(nuevoCancion);
        }

        [HttpGet]
        [Route("archivoCancion/{cancion}")]
        public void archivoCancion(String cancion)        
        {
            Console.WriteLine(cancion);
            byte [] cancionbytes = Convert.FromBase64String(cancion);
            System.IO.File.WriteAllBytes("C:/Users/edson/Desktop/cancionesServer/prueba.mp3", cancionbytes);
        }
    }
}