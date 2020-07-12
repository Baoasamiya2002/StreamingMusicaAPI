/*
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
    public class CuentaController : ControllerBase
    {
        private readonly GestionCuentasContext _contexto;
        List<Cuenta> cuentas { set; get; }
        public CuentaController(GestionCuentasContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Obtener()
        {
            var cuentas = _contexto.Cuentas.ToList();
            return Ok(cuentas);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var cuenta = _contexto.Cuentas.FirstOrDefault(a => a.Id == id);
            if (cuenta == null)
            {
                return NotFound();
            }
            return Ok(cuenta);
        }

        [HttpPost]
        [Route("crear")]
        public IActionResult Crear(Cuenta cuenta)
        {
            UtilidadContrasena utilidadContrasena = new UtilidadContrasena();
            var salt = BitConverter.ToString(utilidadContrasena.GetSalt());
            var contrasenaHash = utilidadContrasena.Hash(cuenta.Contrasena, salt);
            cuenta.Salt = salt;
            cuenta.Contrasena = contrasenaHash;
            _contexto.Cuentas.Add(cuenta);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ObtenerPorId), new { cuenta.Id }, cuenta);
        }

        [HttpPost]
        [Route("iniciarSesion")]
        public IActionResult IniciarSesion(Cuenta cuenta)
        {
            var cuentaExistente = _contexto.Cuentas.FirstOrDefault(cuentaBD => cuentaBD.Usuario == cuenta.Usuario);
            if (cuentaExistente == null)
            {
                return NotFound();
            }
            if (cuentaExistente.Acceso == false) {
                return BadRequest(); 
            }
            UtilidadContrasena utilidadContrasena = new UtilidadContrasena();
            var salt = cuentaExistente.Salt;
            var contrasenaHash = utilidadContrasena.Hash(cuenta.Contrasena, salt);
            if(cuentaExistente.Contrasena != contrasenaHash){
                return BadRequest();
            }
            return Content("sesión iniciada");
        }

        [HttpPut]
        [Route("modificar/{id}")]
        public IActionResult Modificar(int id, Cuenta cuenta)
        {
            var cuentaExistente = _contexto.Cuentas.FirstOrDefault(cuentaBD => cuentaBD.Id == id);
            if (cuentaExistente == null)
            {
                return NotFound();
            }
            cuentaExistente.Nombre = cuenta.Nombre;
            cuentaExistente.Usuario = cuenta.Usuario;
            cuentaExistente.Acceso = cuenta.Acceso;
            UtilidadContrasena utilidadContrasena = new UtilidadContrasena();
            var salt = cuentaExistente.Salt;
            var contrasenaHash = utilidadContrasena.Hash(cuenta.Contrasena, salt);
            cuentaExistente.Contrasena = contrasenaHash;
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ObtenerPorId), new { cuentaExistente.Id }, cuentaExistente);
        }

        [HttpPatch]
        [Route("modificarCont/{id}")]
        public IActionResult ModificarCont(int id, Cuenta cuenta)
        {
            if(cuenta == null)
            {
                return BadRequest();
            }
            var cuentaExistente = _contexto.Cuentas.Find(id);
            if (cuentaExistente == null)
            {
                return NotFound();
            }
            cuentaExistente.Id = id;
            UtilidadContrasena utilidadContrasena = new UtilidadContrasena();
            var salt = cuentaExistente.Salt;
            var contrasenaHash = utilidadContrasena.Hash(cuenta.Contrasena, salt);
            cuentaExistente.Contrasena = contrasenaHash;
            _contexto.Cuentas.Update(cuentaExistente);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ObtenerPorId), new { cuentaExistente.Id }, cuentaExistente);
        }               

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            var cuentaExistente = _contexto.Cuentas.Find(id);
            if (cuentaExistente == null)
            {
                return NotFound();
            }
            cuentaExistente.Acceso = false;
            _contexto.Cuentas.Update(cuentaExistente);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ObtenerPorId), new { cuentaExistente.Id }, cuentaExistente);
        }
    }
}*/


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