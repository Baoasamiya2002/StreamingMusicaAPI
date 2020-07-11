using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiRest.Models
{
    public class Cancion
    {
        public int Id { set; get; }
        public string Nombre_cancion { set; get; }
        public int AlbumId { set; get; }
        public int ArtistaId { set; get; }
        public int GeneroId { set; get; }
        public virtual List<CancionLista_reproduccion> CancionListas_reproduccion { set; get;}
    }
}