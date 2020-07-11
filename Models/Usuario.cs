using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiRest.Models
{
    public class Usuario
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Password { set; get; }
        public string Salt { set; get; }
    }
}