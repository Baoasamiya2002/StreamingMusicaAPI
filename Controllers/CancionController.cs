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

        List<Cancion> canciones { set; get;}

        
    }
}