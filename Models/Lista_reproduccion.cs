using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Text.Json.Serialization;

namespace ApiRest.Models
{
    public class Lista_reproduccion
    {
        public int Id { set; get; }
        public string Nombre_lista { set; get; }
        public int UsuarioId { set; get; }
        [JsonIgnore]
        public virtual List<CancionLista_reproduccion> CancionListas_reproduccion { set; get;}
    }
}