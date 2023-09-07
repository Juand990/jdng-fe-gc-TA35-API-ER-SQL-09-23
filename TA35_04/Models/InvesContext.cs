using Microsoft.EntityFrameworkCore;

namespace TA35_04.Models
{
    public partial class InvesContext : DbContext
    {
        public InvesContext(DbContextOptions<InvesContext> options)
            : base(options)
        {
        }

        public DbSet<Facultad> Facultad { get; set; }
        public DbSet<Investigadores> Investigadores { get; set; }
        public DbSet<Equipos> Equipos { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facultad>(entity =>
            {
                entity.ToTable("Facultad");

                entity.HasKey(p => new { p.Codigo });

                entity.Property(p => p.Codigo).HasColumnName("Codigo");

                entity.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(255)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Investigadores>(entity =>
            {
                entity.ToTable("Investigadores");

                entity.HasKey(p => new { p.DNI });

                entity.Property(p => p.DNI).HasColumnName("DNI");

                entity.Property(p => p.NomApels)
                .HasColumnName("NomApels")
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.HasOne(d => d.Facultad)
                .WithMany(s => s.Investigadores)
                .HasForeignKey(s => s.FacultadCod)
                .HasConstraintName("FacultadCod_fk");
            });
            modelBuilder.Entity<Equipos>(entity =>
            {
                entity.ToTable("Equipos");

                entity.HasKey(p => new { p.NumSerie });

                entity.Property(p => p.NumSerie).HasColumnName("NumSerie");

                entity.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.HasOne(d => d.Facultad)
                .WithMany(s => s.Equipos)
                .HasForeignKey(s => s.FacultadCod)
                .HasConstraintName("FacultadCod_fk");
            });
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("Reserva");

                entity.HasKey(s => new { s.DniInves, s.NumSerieEq });

                entity.Property(s => s.DniInves).HasColumnName("DniInves");

                entity.Property(s => s.NumSerieEq).HasColumnName("NumSerieEq");

                entity.HasOne(d => d.Investigadores)
                .WithMany(s => s.Reserva)
                .HasForeignKey(s => s.DniInves)
                .HasConstraintName("DniInves_fk");

                entity.HasOne(d => d.Equipos)
                .WithMany(s => s.Reserva)
                .HasForeignKey(s => s.NumSerieEq)
                .HasConstraintName("NumSerieEq_fk");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
