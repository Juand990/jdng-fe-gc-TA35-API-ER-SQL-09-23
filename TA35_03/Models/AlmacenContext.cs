using Microsoft.EntityFrameworkCore;

namespace TA35_03.Models
{
    public partial class AlmacenContext : DbContext
    {
        public AlmacenContext(DbContextOptions<AlmacenContext> options)
            : base(options)
        {
        }

        public DbSet<Cajeros> Cajeros { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<MaqRegistradoras> Maquinas { get; set; }
        public DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cajeros>(entity =>
            {
                entity.ToTable("Cajeros");

                entity.HasKey(p => new { p.Codigo });

                entity.Property(p => p.Codigo).HasColumnName("Codigo");

                entity.Property(p => p.NomApels)
                .HasColumnName("NomApels")
                .HasMaxLength(255)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Productos>(entity =>
            {
                entity.ToTable("Productos");

                entity.HasKey(p => new { p.Codigo });

                entity.Property(p => p.Codigo).HasColumnName("Codigo");

                entity.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(255)
                .IsUnicode(false);
                entity.Property(p => p.Precio)
                .HasColumnName("Precio");
            });
            modelBuilder.Entity<MaqRegistradoras>(entity =>
            {
                entity.ToTable("MaqRegistradoras");

                entity.HasKey(p => new { p.Codigo });

                entity.Property(p => p.Codigo).HasColumnName("Codigo");

                entity.Property(p => p.Piso)
                .HasColumnName("Piso");               
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Venta");

                entity.HasKey(s => new { s.CajeroId, s.ProductoId, s.MaquinaId });

                entity.Property(s => s.CajeroId).HasColumnName("CajeroId");

                entity.Property(s => s.ProductoId).HasColumnName("ProductosId");

                entity.Property(s => s.MaquinaId).HasColumnName("MaquinaId");

                entity.HasOne(d => d.Cajero)
                .WithMany(s => s.Venta)
                .HasForeignKey(s => s.CajeroId)
                .HasConstraintName("CajeroId_fk");

                entity.HasOne(d => d.Producto)
                .WithMany(s => s.Venta)
                .HasForeignKey(s => s.ProductoId)
                .HasConstraintName("ProductoId_fk");

                entity.HasOne(d => d.Maquina)
                .WithMany(s => s.Venta)
                .HasForeignKey(s => s.MaquinaId)
                .HasConstraintName("MaqId_fk");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
