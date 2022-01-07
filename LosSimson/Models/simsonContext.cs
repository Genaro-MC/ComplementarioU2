using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LosSimson.Models
{
    public partial class simsonContext : DbContext
    {
        public simsonContext()
        {
        }

        public simsonContext(DbContextOptions<simsonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Episodio> Episodios { get; set; }
        public virtual DbSet<Temporadum> Temporada { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4");

            modelBuilder.Entity<Episodio>(entity =>
            {
                entity.ToTable("episodio");

                entity.HasIndex(e => e.IdTemporada, "fk_episodio_temporada");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(45)
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.NombreIngles).HasMaxLength(45);

                entity.Property(e => e.Trama).HasColumnType("text");

                entity.HasOne(d => d.IdTemporadaNavigation)
                    .WithMany(p => p.Episodios)
                    .HasForeignKey(d => d.IdTemporada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_episodio_temporada");
            });

            modelBuilder.Entity<Temporadum>(entity =>
            {
                entity.ToTable("temporada");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
