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

    public class AlbumController : ControllerBase
    {
        private readonly StreamingMusicaContext _contexto;

        public AlbumController(StreamingMusicaContext contexto){
            _contexto = contexto;
        } 

        [HttpGet]
        [Route("")]
        public IActionResult getAllAlbums()
        {
            var albums = _contexto.Albums.ToList();
            return Ok(albums);
        }

        [HttpGet]
        [Route("busqueda/{palabra}")]
        public IActionResult getAlbums(string palabra)
        {
            var albums = _contexto.Albums.Where(albumBD => albumBD.Nombre_album.Contains(palabra)).ToList();
            return Ok(albums);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult getAlbumById(int id)
        {
            var album = _contexto.Albums.FirstOrDefault(albumBD => albumBD.Id == id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        [HttpPost]
        [Route("crear")]
        public IActionResult setAlbum(Album album)
        {
            _contexto.Albums.Add(album);
            _contexto.SaveChanges();   
            CreatedAtAction(nameof(getAlbumById), new { album.Id }, album);
            var nuevoAlbum = new Album();
            nuevoAlbum.Id = album.Id;
            return Ok(nuevoAlbum);
        }
    }
}