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

        [HttpGet]
        [Route("")]
        public IActionResult getListas_rep()
        {
            var list = _contexto.Listas_Reproduccion.ToList();
            return Ok(list);
        }
    }
}