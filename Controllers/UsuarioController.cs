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

    public class UsuarioController : ControllerBase
    {
        private readonly StreamingMusicaContext _contexto;

        public UsuarioController(StreamingMusicaContext contexto){
            _contexto = contexto;
        }     

        
        [HttpGet]
        [Route("")]
        public IActionResult getUsers()
        {
            var users = _contexto.Usuarios.ToList();
            return Ok(users);
        }
        [HttpGet]
        [Route("id")]
        public IActionResult getUserById(int id)
        {
            var user = _contexto.Usuarios.FirstOrDefault(usBD => usBD.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Usuario user)
        {
            var userValido = new Usuario();
            var cuentaExistente = _contexto.Usuarios.FirstOrDefault(usuarioBD => usuarioBD.Nombre == user.Nombre);
            if(cuentaExistente == null)
            {    
                userValido.Id = -1;
            } else {
                if(cuentaExistente.Password != user.Password)
                {
                    userValido.Id = -1;
                } else {
                    userValido.Id = cuentaExistente.Id;  
                }
            }            
            return Ok(userValido);
        }
        /* ESTA FORMA REGRESA TODO EL USUARIO REGISTRADO
        [HttpPost]
        [Route("registro")]
        public IActionResult Registro(Usuario user)
        {            
            _contexto.Usuarios.Add(user);
            _contexto.SaveChanges();        
            return CreatedAtAction(nameof(getUserById), new { user.Id}, user);            
        }
        ESTA REGRESA SOLO EL ID    */
        [HttpPost]
        [Route("registro")]
        public IActionResult Registro(Usuario user)
        {            
            _contexto.Usuarios.Add(user);
            _contexto.SaveChanges();   
            CreatedAtAction(nameof(getUserById), new { user.Id}, user);
            var usr2 = new Usuario();
            usr2.Id = user.Id;
            return Ok(usr2);
        }
    }
}