﻿// <auto-generated />
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiRest.Migrations
{
    [DbContext(typeof(StreamingMusicaContext))]
    partial class StreamingMusicaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiRest.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discografica")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Lanzamiento")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_album")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("ApiRest.Models.Artista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre_artista")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("ApiRest.Models.Calificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CancionId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("Valor_calificacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Calificaciones");
                });

            modelBuilder.Entity("ApiRest.Models.Cancion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_cancion")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Canciones");
                });

            modelBuilder.Entity("ApiRest.Models.CancionLista_reproduccion", b =>
                {
                    b.Property<int>("CancionId")
                        .HasColumnType("int");

                    b.Property<int>("Lista_reproduccionId")
                        .HasColumnType("int");

                    b.HasKey("CancionId", "Lista_reproduccionId");

                    b.HasIndex("Lista_reproduccionId");

                    b.ToTable("CancionLista_reproduccion");
                });

            modelBuilder.Entity("ApiRest.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre_genero")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("ApiRest.Models.Lista_reproduccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre_lista")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Listas_Reproduccion");
                });

            modelBuilder.Entity("ApiRest.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Salt")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ApiRest.Models.CancionLista_reproduccion", b =>
                {
                    b.HasOne("ApiRest.Models.Cancion", "Cancion")
                        .WithMany("CancionListas_reproduccion")
                        .HasForeignKey("CancionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRest.Models.Lista_reproduccion", "Lista_reproduccion")
                        .WithMany("CancionListas_reproduccion")
                        .HasForeignKey("Lista_reproduccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
