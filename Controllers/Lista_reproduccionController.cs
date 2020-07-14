using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiRest.Models;
using ApiRest.Utilities;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class Lista_reproduccionController : ControllerBase
    {

        private readonly StreamingMusicaContext _contexto;

        public Lista_reproduccionController(StreamingMusicaContext contexto){
            _contexto = contexto;
        }  

        //OBTIENE LAS LISTAS DE REPRODUCCION
        [HttpGet]
        [Route("")]
        public IActionResult getListas_rep()
        {
            var list = _contexto.Listas_Reproduccion.ToList();
            return Ok(list);
        }

        [HttpGet]
        [Route("buscar/{palabra}")]
        public IActionResult BuscarListas_reproduccion(String palabra)
        {
            var list = _contexto.Listas_Reproduccion.Where(listBD => listBD.Nombre_lista.Contains(palabra));            
            return Ok(list);
        }

        //REGRESA LAS LISTAS DE REPRODUCCION SEGUN EL USUARIO
        [HttpGet]
        [Route("listasByUser/{idUsuario}")]
        public IActionResult getListas_repByIdUsuario(int idUsuario)
        {
            var list = _contexto.Listas_Reproduccion.Where(listBD => listBD.UsuarioId == idUsuario);            
            return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult getListaById(int id)
        {
            var lista = _contexto.Listas_Reproduccion.Find(id);
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }

        [HttpPost]
        [Route("crearLista")]
        public IActionResult CrearLista_Reproduccion(Lista_reproduccion lista)
        {
            _contexto.Listas_Reproduccion.Add(lista);
            _contexto.SaveChanges();
            CreatedAtAction(nameof(getListaById), new { lista.Id }, lista);
            var nuevoLista = new Lista_reproduccion();
            nuevoLista.Id = lista.Id;
            nuevoLista.Nombre_lista = "Nueva";
            return Ok(nuevoLista);
        }        

        [HttpDelete]
        [Route("eliminarLista/{id}")]
        public void EliminarLista_reproduccion(int id)
        {
            _contexto.Listas_Reproduccion.Remove(_contexto.Listas_Reproduccion.Find(id));
            _contexto.SaveChanges();
        }
    }
}