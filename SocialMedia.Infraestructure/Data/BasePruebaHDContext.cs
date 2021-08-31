using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialMedia.Core.Entities;
using SocialMedia.Infraestructure.Data.Configurations;

#nullable disable

namespace SocialMedia.Infraestructure.Data
{
    public partial class BasePruebaHDContext : DbContext
    {
        public BasePruebaHDContext()
        {
        }

        public BasePruebaHDContext(DbContextOptions<BasePruebaHDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Publicacion> Publicacions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<Security> Securities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Apply the configuration from the current assembly 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
