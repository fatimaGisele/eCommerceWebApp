using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace appPDWebMVC.Models

{
    public partial class MydbContext : DbContext
    {
        public MydbContext() { }

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
         => optionsBuilder.UseMySql("server=localhost;port=3306;database=mydb;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci").HasCharSet("utf8mb4");

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

                entity.ToTable("cliente").HasCharSet("utf8").UseCollation("utf8_general_ci");

                entity.Property(e => e.ID).HasColumnType("int(11)").HasColumnName("id");
                entity.Property(e => e.Nombre).HasMaxLength(45).HasColumnName("nombre");
                entity.Property(e => e.Apellido).HasMaxLength(45).HasColumnName("apellido");
                entity.Property(e => e.Mail).HasMaxLength(45).HasColumnName("mail");
                entity.Property(e => e.Usuario).HasMaxLength(45).HasColumnName("usuario");
                entity.Property(e => e.Contraseña).HasMaxLength(45).HasColumnName("contraseña");
                entity.Property(e => e.Telefono).HasColumnType("int(11)").HasColumnName("telefono");
                entity.Property(e => e.Rol).HasColumnType("int(11)").HasColumnName("rol");
            });

            modelBuilder.Entity<ClienteCarrito>(entity =>
            {

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

            modelBuilder.Entity<ClienteMediodepago>(entity =>
            {
                entity.HasKey(e => new { e.ClienteId, e.MedioDePagoId }).HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity
               .ToTable("cliente_mediodepago")
               .HasCharSet("utf8")
               .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.ClienteId, "fk_clienteData_has_medio_de_pago_clienteData1_idx");
                entity.HasIndex(e => e.MedioDePagoId, "fk_clienteData_has_medio_de_pago_medio_de_pago1_idx");

                entity.Property(e => e.ClienteId)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCliente");
                entity.Property(e => e.MedioDePagoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("idmedio_de_pago");
                entity.Property(e => e.Tipo)
                    .HasMaxLength(45)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.Cliente).WithMany(p => p.ClienteMediodepagos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clienteData_has_medio_de_pago_clienteData");

                entity.HasOne(d => d.MedioDePago).WithMany(p => p.ClienteMediodepagos)
                    .HasForeignKey(d => d.MedioDePagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clienteData_has_medio_de_pago_medio_de_pago1");
            });


            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PRIMARY");
                entity.ToTable("genero").HasCharSet("utf8").UseCollation("utf8_general_ci");

                entity.Property(e => e.ID).ValueGeneratedNever().HasColumnType("int(11)").HasColumnName("idgenero");
                entity.Property(e => e.GeneroTipo).HasMaxLength(45).HasColumnName("genero");
            });

            modelBuilder.Entity<IndumentariaHasVenta>(entity =>
            {
                entity.HasKey(e => new { e.IndumentariaId, e.VentaId }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("indumentaria_has_venta").HasCharSet("utf8").UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.IndumentariaId, "fk_indumentaria_has_ventas_indumentaria1_idx");
                entity.HasIndex(e => e.VentaId, "fk_indumentaria_has_ventas_ventas1_idx");

                entity.Property(e => e.IndumentariaId).HasColumnType("int(11)").HasColumnName("indumentaria_id");
                entity.Property(e => e.VentaId).HasColumnType("int(11)").HasColumnName("ventas_id");
                entity.Property(e => e.Cantidad).HasColumnType("int(11)").HasColumnName("cantidad");
            });

            modelBuilder.Entity<Indumentarium>(entity =>
            {
                entity.HasKey(e => new { e.ID, e.CategoriaId, e.GeneroId }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 }); ;
                entity.ToTable("indumentaria").HasCharSet("utf8").UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.CategoriaId, "fk_indumentaria_categoria1_idx");
                entity.HasIndex(e => e.GeneroId, "fk_indumentaria_genero1_idx");

                entity.Property(e => e.ID).ValueGeneratedOnAdd().HasColumnType("int(11)").HasColumnName("id");
                entity.Property(e => e.Nombre).HasMaxLength(45).HasColumnName("nombre");
                entity.Property(e => e.Tipo).HasMaxLength(45).HasColumnName("tipo");
                entity.Property(e => e.Detalle).HasMaxLength(500).HasColumnName("detalle");
                entity.Property(e => e.Precio).HasPrecision(10, 2).HasColumnName("precio");
                entity.Property(e => e.Talle).HasColumnType("int(11)").HasColumnName("talle");
                entity.Property(e => e.Stock).HasColumnType("int(11)").HasColumnName("stock");
                entity.Property(e => e.Img).HasMaxLength(100).HasColumnName("img");
                entity.Property(e => e.CategoriaId).HasColumnType("int(11)").HasColumnName("categoria_id");
                entity.Property(e => e.GeneroId).HasColumnType("int(11)").HasColumnName("genero_id");

                entity.HasOne(d => d.Categoria).WithMany(p => p.Indumentaria).HasForeignKey(d => d.CategoriaId)
               .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_indumentaria_categoria1");

                entity.HasOne(d => d.Genero).WithMany(p => p.Indumentaria).HasForeignKey(d => d.GeneroId)
                .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_indumentaria_genero1");

            });

            modelBuilder.Entity<MedioDePago>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PRIMARY");
                entity.ToTable("medio_de_pago").HasCharSet("utf8").UseCollation("utf8_general_ci");

                entity.Property(e => e.ID).HasColumnType("int(11)").HasColumnName("id");
                entity.Property(e => e.Numero).HasColumnType("int(11)").HasColumnName("numero");

            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => new { e.ID, e.ClienteId }).HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                entity.ToTable("ventas").HasCharSet("utf8").UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.ClienteId, "fk_ventas_cliente1_idx");

                entity.Property(e => e.ID).HasColumnType("int(11)").HasColumnName("idventas");
                entity.Property(e => e.Fecha).HasColumnType("datetime").HasColumnName("fecha");
                entity.Property(e => e.Total).HasColumnName("total");
                entity.Property(e => e.ClienteId).HasColumnType("int(11)").HasColumnName("cliente_id");

                entity.HasOne(d => d.Cliente).WithMany(p => p.Ventas).HasForeignKey(d => d.ClienteId)
               .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ventas_cliente1");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

