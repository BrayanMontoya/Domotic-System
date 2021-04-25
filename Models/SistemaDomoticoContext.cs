using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SistemaDomotico.Models
{
    public partial class SistemaDomoticoContext : DbContext
    {
        public SistemaDomoticoContext()
        {
        }

        public SistemaDomoticoContext(DbContextOptions<SistemaDomoticoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dispositivo> Dispositivos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-CL711V1O\\SQLEXPRESS;Database=SistemaDomotico;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dispositivo>(entity =>
            {
                entity.HasKey(e => e.IdDispositivo);

                entity.ToTable("Dispositivo");

                entity.Property(e => e.IdDispositivo).HasColumnName("ID_Dispositivo");

                entity.Property(e => e.EstadoEnchufe).HasColumnName("estado_enchufe");

                entity.Property(e => e.EstadoFoco).HasColumnName("estado_foco");

                entity.Property(e => e.Humedad).HasColumnName("humedad");

                entity.Property(e => e.Temperatura).HasColumnName("temperatura");

                entity.Property(e => e.Usuario).HasColumnName("usuario");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Dispositivos)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dispositivo_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
