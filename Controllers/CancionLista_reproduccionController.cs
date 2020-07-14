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

    public class CancionLista_reproduccionController : ControllerBase
    {
        private readonly StreamingMusicaContext _contexto;

        public CancionLista_reproduccionController(StreamingMusicaContext contexto){
            _contexto = contexto;
        }

        [HttpGet]
        [Route("")]
        public IActionResult getCanciones()
        {
            var cancionesLista = _contexto.CancionLista_reproduccion.ToList();
            return Ok(cancionesLista);
        }

        [HttpGet]
        [Route("byId/{idLista}")]
        public IActionResult getCancionesById(int idLista)
        {
            var cancionesLista = _contexto.CancionLista_reproduccion.Where(listaBD => listaBD.Lista_reproduccionId == idLista);            
            return Ok(cancionesLista);
        }

        [HttpPost]
        [Route("crear")]
        public IActionResult setCancionLista(CancionLista_reproduccion cancionLista)
        {
            _contexto.CancionLista_reproduccion.Add(cancionLista);
            _contexto.SaveChanges();   
            var lista = new Lista_reproduccion();
            lista.Id = -1;
            return Ok(lista);
        }

        [HttpDelete]
        [Route("eliminar/{idCancion}/{idLista}")]
        public IActionResult EliminarCancionLista(int idCancion, int idLista)
        {
            var cancionListaExistente = _contexto.CancionLista_reproduccion.
            FirstOrDefault(listaBD => listaBD.Lista_reproduccionId == idLista &&
            listaBD.CancionId == idCancion);
            _contexto.CancionLista_reproduccion.Remove(cancionListaExistente);
            _contexto.SaveChanges();
            var lista = new Lista_reproduccion();
            lista.Id = 0;
            return Ok(lista);
        }
    }
}