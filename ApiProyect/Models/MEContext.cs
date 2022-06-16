using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiProyect.Models
{
    public partial class MEContext : DbContext
    {
        public MEContext()
        {
        }

        public MEContext(DbContextOptions<MEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Barrio> Barrios { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
         public virtual DbSet<Devolucion> Devolucion { get; set; }
        public virtual DbSet<DetalleDevolucion> DetalleDevolucion { get; set; }
        public virtual DbSet<DetalleIngresoPedido> DetalleIngresoPedidos { get; set; }
        public virtual DbSet<DetalleNotaPedido> DetalleNotaPedidos { get; set; }
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<EstadoArticulo> EstadoArticulos { get; set; }
        public virtual DbSet<FormaPago> FormaPagos { get; set; }
        public virtual DbSet<IngresoPedidoProveedor> IngresoPedidoProveedors { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<MotivoDevolucion> MotivoDevolucions { get; set; }
        public virtual DbSet<NotaPedido> NotaPedidos { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<TalleArticulo> TalleArticulos { get; set; }
        public virtual DbSet<TipoArticulo> TipoArticulos { get; set; }
         public virtual DbSet<TipoRol> TipoRols { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID=M&E; Password=123456; Server=localhost; Database=M&E; Integrated Security=true; Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Spain.1252");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.IdArticulo)
                    .HasName("articulo_pkey");

                entity.ToTable("articulo");

                entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaModificicacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_modificicacion");

                entity.Property(e => e.IdEstadoArticulo).HasColumnName("id_estado_articulo");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.IdTalle).HasColumnName("id_talle");

                entity.Property(e => e.IdTipoArticulo).HasColumnName("id_tipo_articulo");

                entity.Property(e => e.NombreArticulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre_articulo");

                entity.Property(e => e.Flag).HasColumnName("flag");    

                entity.Property(e => e.PrecioVenta).HasColumnName("precio_venta");

                entity.HasOne(d => d.IdEstadoArticuloNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdEstadoArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_estado_articulo");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_marca");

                entity.HasOne(d => d.IdTalleNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdTalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_talle");

                entity.HasOne(d => d.IdTipoArticuloNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdTipoArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_tipo_articulo");
            });

            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.HasKey(e => e.CodBarrio)
                    .HasName("barrio_pkey");

                entity.ToTable("barrio");

                entity.Property(e => e.CodBarrio).HasColumnName("cod_barrio");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoRol>(entity =>
            {
                entity.HasKey(e => e.IdTipoRol)
                    .HasName("tipo_rol_pkey");

                entity.ToTable("tipo_rol");

                entity.Property(e => e.IdTipoRol).HasColumnName("id_tipo_rol");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("cliente_pkey");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.NombreCliente)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre_cliente");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Direccion).HasColumnName("direccion");

                entity.Property(e => e.CodBarrio).HasColumnName("cod_barrio");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.Flag).HasColumnName("flag");   

                entity.HasOne(d => d.CodBarrioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CodBarrio)
                    .HasConstraintName("fk_cod_barrio");
            });
//TABLA AGHREGADA
            modelBuilder.Entity<Devolucion>(entity =>
            {
                entity.HasKey(e => e.IdDevolucion)
                    .HasName("devolucion_pkey");

                entity.ToTable("devolucion");

                entity.Property(e => e.IdDevolucion).HasColumnName("id_devolucion");

                entity.Property(e => e.NroDevolucion).HasColumnName("nro_devolucion");

                entity.Property(e => e.FechaDevolucion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_devolucion");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.Flag).HasColumnName("flag");   

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Devolucions)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_venta");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Devolucions)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_empleado");
            });
//ACA TERMINA
//TABLA AGREGADA
                       modelBuilder.Entity<DetalleDevolucion>(entity =>
            {
                entity.HasKey(e => e.IdDetalleDevolucion)
                    .HasName("detalle_devolucion_pkey");

                entity.ToTable("detalle_devolucion");

                entity.Property(e => e.IdDetalleDevolucion).HasColumnName("id_detalle_devolucion");

                entity.Property(e => e.IdDevolucion).HasColumnName("id_devolucion");

                entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");

                entity.Property(e => e.IdMotivo).HasColumnName("id_motivo_devolucion");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Flag).HasColumnName("flag");   

                entity.HasOne(d => d.IdDevolucionNavigation)
                    .WithMany(p => p.DetalleDevolucion)
                    .HasForeignKey(d => d.IdDevolucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_devolucion");

                entity.HasOne(d => d.IdMotivoNavigation)
                    .WithMany(p => p.DetalleDevolucion)
                    .HasForeignKey(d => d.IdMotivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_motivo");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.DetalleDevolucion)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_articulo");
            });
//ACA TERMINA
            modelBuilder.Entity<DetalleIngresoPedido>(entity =>
            {
                entity.HasKey(e => e.IdDetalleIngresoPedido)
                    .HasName("detalle_ingreso_pedido_pkey");

                entity.ToTable("detalle_ingreso_pedido");

                entity.Property(e => e.IdDetalleIngresoPedido).HasColumnName("id_detalle_ingreso_pedido");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");

                entity.Property(e => e.Flag).HasColumnName("flag");   

                entity.Property(e => e.IdIngresoPedido).HasColumnName("id_ingreso_pedido");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.DetalleIngresoPedidos)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_articulo");

                entity.HasOne(d => d.IdIngresoPedidoNavigation)
                    .WithMany(p => p.DetalleIngresoPedidos)
                    .HasForeignKey(d => d.IdIngresoPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_ingreso_pedido");
            });

            modelBuilder.Entity<DetalleNotaPedido>(entity =>
            {
                entity.HasKey(e => e.NroDetalleOrdenCompra)
                    .HasName("detalle_nota_pedido_pkey");

                entity.ToTable("detalle_nota_pedido");

                entity.Property(e => e.NroDetalleOrdenCompra).HasColumnName("nro_detalle_orden_compra");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");

                entity.Property(e => e.Flag).HasColumnName("flag");   

                entity.Property(e => e.NroOrdenCompra).HasColumnName("nro_orden_compra");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.DetalleNotaPedidos)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_articulo");

                entity.HasOne(d => d.NroOrdenCompraNavigation)
                    .WithMany(p => p.DetalleNotaPedidos)
                    .HasForeignKey(d => d.NroOrdenCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_nro_orden");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.HasKey(e => e.IdDetalle)
                    .HasName("detalle_venta_pkey");

                entity.ToTable("detalle_venta");

                entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");

                entity.Property(e => e.Flag).HasColumnName("flag");   

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_articulo");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_venta");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Legajo)
                    .HasName("empleado_pkey");

                entity.ToTable("usuario");

                entity.Property(e => e.Legajo).HasColumnName("legajo");

                entity.Property(e => e.CodBarrio).HasColumnName("cod_barrio");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.IdTipoRol).HasColumnName("id_tipo_rol");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Contraseña).HasColumnName("contraseña");
                
                entity.Property(e => e.Flag).HasColumnName("flag");   

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre_completo");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.CodBarrioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CodBarrio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cod_barrio");

                entity.HasOne(d => d.IdTipoRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_tipo_rol");
            });

            modelBuilder.Entity<EstadoArticulo>(entity =>
            {
                entity.HasKey(e => e.IdEstadoArticulo)
                    .HasName("estado_articulo_pkey");

                entity.ToTable("estado_articulo");

                entity.Property(e => e.IdEstadoArticulo).HasColumnName("id_estado_articulo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago)
                    .HasName("forma_pago_pkey");

                entity.ToTable("forma_pago");

                entity.Property(e => e.IdFormaPago).HasColumnName("id_forma_pago");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<IngresoPedidoProveedor>(entity =>
            {
                entity.HasKey(e => e.IdIngresoPedido)
                    .HasName("ingreso_pedido_proveedor_pkey");

                entity.ToTable("ingreso_pedido_proveedor");

                entity.Property(e => e.IdIngresoPedido).HasColumnName("id_ingreso_pedido");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

                entity.Property(e => e.NroRemitoPedido).HasColumnName("nro_remito_pedido");

                entity.Property(e => e.NroOrdenCompra).HasColumnName("nro_orden_compra");

                entity.Property(e => e.Flag).HasColumnName("flag");   

                entity.Property(e => e.TipoFactura)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("tipo_factura");

                entity.Property(e => e.Pago)
                    .HasMaxLength(50)
                    .HasColumnName("pago");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.IngresoPedidoProveedors)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_empleado");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.IngresoPedidoProveedors)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_proveedor");

                entity.HasOne(d => d.NroOrdenCompraNavigation)
                    .WithMany(p => p.IngresoPedidoProveedors)
                    .HasForeignKey(d => d.NroOrdenCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_nro_orden");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("marca_pkey");

                entity.ToTable("marca");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.NombreMarca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre_marca");
            });
//TABLA AGREGADA
            modelBuilder.Entity<MotivoDevolucion>(entity =>
            {
                entity.HasKey(e => e.IdMotivo)
                    .HasName("motivo_devolucion_pkey");

                entity.ToTable("motivo_devolucion");

                entity.Property(e => e.IdMotivo).HasColumnName("id_motivo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");
            });
//ACA TERMINA
            modelBuilder.Entity<NotaPedido>(entity =>
            {
                entity.HasKey(e => e.IdOrdenCompra)
                    .HasName("nota_pedido_pkey");

                entity.ToTable("nota_pedido");

                entity.Property(e => e.IdOrdenCompra).HasColumnName("id_orden_compra");

                entity.Property(e => e.FechaEmision)
                    .HasColumnType("date")
                    .HasColumnName("fecha_emision");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("date")
                    .HasColumnName("fecha_entrega");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.NotaPedidos)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_empleado");

                 entity.Property(e => e.Flag).HasColumnName("flag");   

            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("proveedor_pkey");

                entity.ToTable("proveedor");

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

                entity.Property(e => e.CodBarrio).HasColumnName("cod_barrio");

                entity.Property(e => e.Direccion).HasColumnName("direccion");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Flag).HasColumnName("flag");   

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("razon_social");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.CodBarrioNavigation)
                    .WithMany(p => p.Proveedors)
                    .HasForeignKey(d => d.CodBarrio)
                    .HasConstraintName("fk_cod_barrio");

            });

            modelBuilder.Entity<TalleArticulo>(entity =>
            {
                entity.HasKey(e => e.IdTalle)
                    .HasName("talle_articulo_pkey");

                entity.ToTable("talle_articulo");

                entity.Property(e => e.IdTalle).HasColumnName("id_talle");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.NombreTalle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre_talle");
            });

            modelBuilder.Entity<TipoArticulo>(entity =>
            {
                entity.HasKey(e => e.IdTipoArticulo)
                    .HasName("tipo_articulo_pkey");

                entity.ToTable("tipo_articulo");

                entity.Property(e => e.IdTipoArticulo).HasColumnName("id_tipo_articulo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.NombreTipoArticulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre_tipo_articulo");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("venta_pkey");

                entity.ToTable("venta");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("date")
                    .HasColumnName("fecha_venta");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdFormaPago).HasColumnName("id_forma_pago");

                entity.Property(e => e.Flag).HasColumnName("flag");   

                entity.Property(e => e.NroFactura).HasColumnName("nro_factura");

                entity.Property(e => e.TipoFactura)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("tipo_factura");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_cliente");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_empleado");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_forma_pago");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
