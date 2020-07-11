using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiRest.Models
{
    public class CancionLista_reproduccion
    {
        public int Lista_reproduccionId { set; get; }
        public int CancionId { set; get; }
        public virtual Cancion Cancion { set; get; }
        public virtual Lista_reproduccion Lista_reproduccion { set; get;}
    }
}