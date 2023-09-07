using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace TA35_01.Models
{
    public partial class pieprosumContext : DbContext
    {
        public pieprosumContext(DbContextOptions<pieprosumContext> options)
        : base(options)
        {
        }
        public virtual DbSet<Piezas> Piezas { get; set; } = null!;
        public virtual DbSet<Proveedores> Proveedores { get; set; } = null!;
        public virtual DbSet<Suministra> Suministra { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Piezas>(entity =>
            {                
                entity.ToTable("Piezas");

                entity.HasKey(p => new { p.Codigo });

                entity.Property(p => p.Codigo).HasColumnName("Codigo");

                entity.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.ToTable("Proveedores");

                entity.HasKey(r => new { r.Id });

                entity.Property(r => r.Id).HasColumnName("Id");

                entity.Property(r => r.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsUnicode(false);

            });
            modelBuilder.Entity<Suministra>(entity =>
            {
                entity.ToTable("Suministra");

                entity.HasKey(s => new { s.CodigoPieza, s.IdProveedor });

                entity.Property(s => s.CodigoPieza).HasColumnName("CodigoPieza");

                entity.Property(s => s.IdProveedor).HasColumnName("IdProveedor");

                entity.Property(s => s.Precio)
                .HasColumnName("Precio");

                entity.HasOne(d => d.Piezas)
                .WithMany(s => s.Suministra)
                .HasForeignKey(s => s.CodigoPieza)
                .HasConstraintName("piezas_fk");

                entity.HasOne(d => d.Proveedores)
                .WithMany(s => s.Suministra)
                .HasForeignKey(s => s.IdProveedor)
                .HasConstraintName("proveedores_fk");
            });

            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
