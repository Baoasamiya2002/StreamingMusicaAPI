using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Models
{
    public class StreamingMusicaContext : DbContext
    {
        public StreamingMusicaContext (DbContextOptions<StreamingMusicaContext> opciones): base(opciones) { }
        public DbSet<Artista> Artistas { set; get; }
        public DbSet<Album> Albums { set; get; }
        public DbSet<Genero> Generos { set; get; }
        public DbSet<Usuario> Usuarios { set; get; }
        public DbSet<CancionLista_reproduccion> CancionLista_reproduccion { set; get;}
        public DbSet<Cancion> Canciones { set; get; }
        public DbSet<Lista_reproduccion> Listas_Reproduccion { set; get; }
        public DbSet<Calificacion> Calificaciones { set; get; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CancionLista_reproduccion>().HasKey(cl => new { cl.CancionId, cl.Lista_reproduccionId });
        }
    }
}