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

    public class CalificacionController : ControllerBase
    {
        private readonly StreamingMusicaContext _contexto;

        public CalificacionController(StreamingMusicaContext contexto){
            _contexto = contexto;
        } 

        [HttpGet]
        [Route("{idUsuario}/{idCancion}")]
        public IActionResult getCalificacion(int idUsuario, int idCancion)
        {
            var calificacion = _contexto.Calificaciones.
            Where(calificacionBD => calificacionBD.UsuarioId == idUsuario && 
            calificacionBD.CancionId == idCancion);
            return Ok(calificacion);
        }

        [HttpGet]
        [Route("id")]
        public IActionResult getCalificacionById(int id)
        {
            var calificacion = _contexto.Calificaciones.FirstOrDefault(calificacionBD => calificacionBD.Id == id);
            if (calificacion == null)
            {
                return NotFound();
            }
            return Ok(calificacion);
        }

        [HttpPost]
        [Route("crear")]
        public IActionResult setCalificacion(Calificacion calificacion)
        {
            _contexto.Calificaciones.Add(calificacion);
            _contexto.SaveChanges();   
            CreatedAtAction(nameof(getCalificacionById), new { calificacion.Id }, calificacion);
            var nuevoCalificacion = new Calificacion();
            nuevoCalificacion.Id = calificacion.Id;
            return Ok(nuevoCalificacion);
        }
    }
}