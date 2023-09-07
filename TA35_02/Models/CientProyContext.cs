using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace TA35_02.Models
{
    public partial class CientProyContext : DbContext
    {
        public CientProyContext(DbContextOptions<CientProyContext> options)
            : base(options)
        {
        }

        public DbSet<Cientificos> Cientificos { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<AsignadoA> AsignadoA { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cientificos>(entity =>
            {
                entity.ToTable("Cientificos");

                entity.HasKey(p => new { p.DNI });

                entity.Property(p => p.DNI).HasColumnName("DNI");

                entity.Property(p => p.NomApels)
                .HasColumnName("NomApels")
                .HasMaxLength(255)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Proyectos>(entity =>
            {
                entity.ToTable("Proyectos");

                entity.HasKey(p => new { p.Id });

                entity.Property(p => p.Id).HasColumnName("Id");

                entity.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(p => p.Horas)
                .HasColumnName("Horas");
            });
            modelBuilder.Entity<AsignadoA>(entity =>
            {
                entity.ToTable("AsignadoA");

                entity.HasKey(s => new { s.CientificoDni, s.ProyectoId });

                entity.Property(s => s.CientificoDni).HasColumnName("CientificoDni");

                entity.Property(s => s.ProyectoId).HasColumnName("ProyectoId");

                entity.HasOne(d => d.Cientificos)
                .WithMany(s => s.AsignadoA)
                .HasForeignKey(s => s.CientificoDni)
                .HasConstraintName("CientDni_fk");

                entity.HasOne(d => d.Proyectos)
                .WithMany(s => s.AsignadoA)
                .HasForeignKey(s => s.ProyectoId)
                .HasConstraintName("Proyectos_fk");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }    
}
