using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Travelus.DA.Models
{
    public partial class BDTravelContext : DbContext
    {
        public BDTravelContext()
        {
        }

        public BDTravelContext(DbContextOptions<BDTravelContext> options, IConfiguration configuration)
                                                                          : base(options)
            
        {
        }

        public virtual DbSet<TbAuthorHasLibro> TbAuthorHasLibros { get; set; }
        public virtual DbSet<TblAuthor> TblAuthors { get; set; }
        public virtual DbSet<TblEditorial> TblEditorials { get; set; }
        public virtual DbSet<TblLibro> TblLibros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAuthorHasLibro>(entity =>
            {
                entity.HasKey(e => e.AuthorLibroId)
                    .HasName("PK__tbAuthor__05BE6A5B43D9AF3D");

                entity.ToTable("tbAuthor_Has_Libro");

                entity.Property(e => e.AuthorLibroId).HasColumnName("authorLibro_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaModificacion");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.UsuarioCreacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioCreacion");

                entity.Property(e => e.UsuarioModificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioModificacion");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.TbAuthorHasLibros)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_IdtbAuthor_Has_Libro__Author");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.TbAuthorHasLibros)
                    .HasForeignKey(d => d.Isbn)
                    .HasConstraintName("FK_IdtbAuthor_Has_Libro__Libro");
            });

            modelBuilder.Entity<TblAuthor>(entity =>
            {
                entity.ToTable("tblAuthor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaModificacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioCreacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioCreacion");

                entity.Property(e => e.UsuarioModificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioModificacion");
            });

            modelBuilder.Entity<TblEditorial>(entity =>
            {
                entity.ToTable("tblEditorial");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaModificacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sede)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("sede");

                entity.Property(e => e.UsuarioCreacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioCreacion");

                entity.Property(e => e.UsuarioModificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioModificacion");
            });

            modelBuilder.Entity<TblLibro>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__tblLibro__447D36EB56DE1352");
                
                entity.ToTable("tblLibro");

                entity.Property(e => e.Isbn)
                    .ValueGeneratedOnAdd()
                    .ValueGeneratedNever()
                    .HasColumnName("ISBN");

                entity.Property(e => e.EditorialId).HasColumnName("editorial_id");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaModificacion");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.NPaginas)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("n_paginas");

                entity.Property(e => e.Sinopsis)
                    .HasColumnType("text")
                    .HasColumnName("sinopsis");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.UsuarioCreacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioCreacion");

                entity.Property(e => e.UsuarioModificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioModificacion");

                entity.HasOne(d => d.Editorial)
                    .WithMany(p => p.TblLibros)
                    .HasForeignKey(d => d.EditorialId)
                    .HasConstraintName("FK_IdLibroEditorial");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        public int BeforeSaveChanges()
        {
            int id=0;
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                
                if (entry.Entity is TblLibro trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.FechaModificacion = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("Id").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.FechaCreacion = utcNow;
                            trackable.FechaModificacion = utcNow;
                            break;
                    }
                }
                

                    
                base.SaveChanges(true);
                    
                
            }
            


            return id;
        }
        
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
