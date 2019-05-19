using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaestroMunicipos.Model
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Departamento> Departamento { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.DepartamentoId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.Property(e => e.MunicipioId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.DepartamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipio_Departamento");
            });

        }
    }
}