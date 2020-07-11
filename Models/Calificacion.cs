using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiRest.Models
{
    public class Calificacion
    {
        public int Id { set; get; }
        public int Valor_calificacion { set; get; }
        public int UsuarioId { set; get; }
        public int CancionId { set; get; }
    }
}