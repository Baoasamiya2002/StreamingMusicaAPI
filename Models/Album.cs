using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiRest.Models
{
    public class Album
    {
        public int Id { set; get; }
        public string Nombre_album { set; get; }
        public int Lanzamiento { set; get; }
        public string Discografica { set; get; }
    }
}