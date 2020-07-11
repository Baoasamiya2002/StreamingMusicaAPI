using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiRest.Models
{
    public class Lista_reproduccion
    {
        public int Id { set; get; }
        public string Nombre_lista { set; get; }
        public int UsuarioId { set; get; }
        public virtual List<CancionLista_reproduccion> CancionListas_reproduccion { set; get;}
    }
}