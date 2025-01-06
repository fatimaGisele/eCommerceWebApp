using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace appPDWebMVC.Models
{
    public class MydbContext : DbContext
    {
        public MydbContext(){ }

        public MydbContext(DbContextOptions<MydbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Carrito> Carritos { get; set; }

        public virtual DbSet<Categorium> Categoria { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<ClienteCarrito> ClienteCarritos { get; set; }

        public virtual DbSet<ClienteMediodepago> ClienteMediodepagos { get; set; }

        public virtual DbSet<Genero> Generos { get; set; }

        public virtual DbSet<IndumentariaHasVenta> IndumentariaHasVentas { get; set; }

        public virtual DbSet<Indumentarium> Indumentaria { get; set; }

        public virtual DbSet<MedioDePago> MedioDePagos { get; set; }

        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;database=mydb;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PRIMARY");

                entity
                    .ToTable("carrito")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.IndumentariaId, "fk_carrito_indumentaria1_idx");

                entity.Property(e => e.ID).HasColumnType("int(11)").HasColumnName("idCarrito");
                entity.Property(e => e.IndumentariaId).HasColumnType("int(11)").HasColumnName("idIndumentaria");
                entity.Property(e => e.MontoTotal).HasPrecision(10).HasColumnName("montoTotal");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PRIMARY");

                entity
                    .ToTable("categoria")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.ID).HasColumnType("int(11)").HasColumnName("id");
                entity.Property(e => e.CategoriaNombre).HasMaxLength(45).HasColumnName("categoria_nombre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PRIMARY");
                entity
               .ToTable("cliente")
               .HasCharSet("utf8")
               .UseCollation("utf8_general_ci");

                entity.Property(e => e.ID).HasColumnType("int(11)").HasColumnName("id");
                entity.Property(e => e.Nombre).HasMaxLength(45).HasColumnName("nombre");
                entity.Property(e => e.Apellido).HasMaxLength(45).HasColumnName("apellido");
                entity.Property(e => e.Mail).HasMaxLength(45).HasColumnName("mail");
                entity.Property(e => e.Usuario).HasMaxLength(45).HasColumnName("usuario");
                entity.Property(e => e.Contraseña).HasMaxLength(45).HasColumnName("contraseña");
                entity.Property(e => e.Telefono).HasColumnType("int(11)").HasColumnName("telefono");
                entity.Property(e => e.Rol).HasColumnType("int(11)").HasColumnName("rol");
            });

            modelBuilder.Entity<ClienteCarrito>(entity => {

                entity.HasKey(e => new { e.CarritoId, e.ClienteId }).HasName("PRIMARY")
                      .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity
               .ToTable("cliente_carrito")
               .HasCharSet("utf8")
               .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.CarritoId, "fk_clienteData_has_carrito_carrito1_idx");

                entity.HasIndex(e => e.ClienteId, "fk_clienteData_has_carrito_clienteData1_idx");

                entity.Property(e => e.ClienteId).HasColumnType("int(11)").HasColumnName("idCliente");
                entity.Property(e => e.CarritoId).HasColumnType("int(11)").HasColumnName("idCarrito");
                entity.Property(e => e.Cantidad).HasColumnType("int(11)").HasColumnName("cantidad");

                entity.HasOne(d => d.CarritoNav).WithMany(p => p.ClienteCarrito).HasForeignKey(d => d.CarritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clienteData_has_carrito_carrito1");

                entity.HasOne(d => d.ClienteNav).WithMany(p => p.ClienteCarritos).HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clienteData_has_carrito_clienteData1");


            });
        }
    }
   
}
