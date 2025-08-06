using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Progra_6.Core.Models;
using Proyecto_Final_Progra_6.Core.Models.Account;
using Proyecto_Final_Progra_6.Core.Models.Shop;
using Proyecto_Final_Progra_6.Core.Services.Account;

namespace Proyecto_Final_Progra_6.Core.Infrastructure
{
    /// <summary>
    /// Contexto principal de la aplicación para Entity Framework Core.
    /// Gestiona las entidades de identidad y las entidades del dominio de la tienda.
    /// </summary>
    public class ApplicationDbContext(DbContextOptions options, IUserIdAccessor userIdAccessor) :
        IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
    {
        /// <summary>
        /// Conjunto de clientes.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Conjunto de categorías de productos.
        /// </summary>
        public DbSet<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Conjunto de productos.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Conjunto de órdenes.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Conjunto de detalles de órdenes.
        /// </summary>
        public DbSet<OrderDetail> OrderDetails { get; set; }



        public DbSet<Libro> Libros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }





        // Método que configura el modelo de datos y las relaciones entre entidades en Entity Framework Core.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Llama a la configuración base de IdentityDbContext.
            base.OnModelCreating(builder);
            const string priceDecimalType = "decimal(18,2)"; // Tipo de dato para precios.
            const string tablePrefix = "App"; // Prefijo para los nombres de las tablas.

            // --- Configuración de entidades de identidad (usuarios y roles) ---

            // Un usuario puede tener muchos claims (reclamaciones de identidad).
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Claims)
                .WithOne()
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina el usuario, se eliminan sus claims.

            // Un usuario puede tener muchos roles.
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Roles)
                .WithOne()
                .HasForeignKey(r => r.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina el usuario, se eliminan sus roles.

            // Un rol puede tener muchos claims.
            builder.Entity<ApplicationRole>()
                .HasMany(r => r.Claims)
                .WithOne()
                .HasForeignKey(c => c.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina el rol, se eliminan sus claims.

            // Un rol puede tener muchos usuarios.
            builder.Entity<ApplicationRole>()
                .HasMany(r => r.Users)
                .WithOne()
                .HasForeignKey(r => r.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina el rol, se eliminan las relaciones con usuarios.

            // --- Configuración de entidades del dominio de tienda ---

            // Configuración de la entidad Customer (cliente).
            builder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().HasIndex(c => c.Name);
            builder.Entity<Customer>().Property(c => c.Email).HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.PhoneNumber).IsUnicode(false).HasMaxLength(30);
            builder.Entity<Customer>().Property(c => c.City).HasMaxLength(50);
            builder.Entity<Customer>().ToTable($"{tablePrefix}{nameof(Customers)}"); // Nombre de tabla con prefijo.

            // Configuración de la entidad ProductCategory (categoría de producto).
            builder.Entity<ProductCategory>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<ProductCategory>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<ProductCategory>().ToTable($"{tablePrefix}{nameof(ProductCategories)}");

            // Configuración de la entidad Product (producto).
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Product>().HasIndex(p => p.Name);
            builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<Product>().Property(p => p.Icon).IsUnicode(false).HasMaxLength(256);
            builder.Entity<Product>().HasOne(p => p.Parent).WithMany(p => p.Children).OnDelete(DeleteBehavior.Restrict); // Relación jerárquica de productos.
            builder.Entity<Product>().Property(p => p.BuyingPrice).HasColumnType(priceDecimalType);
            builder.Entity<Product>().Property(p => p.SellingPrice).HasColumnType(priceDecimalType);
            builder.Entity<Product>().ToTable($"{tablePrefix}{nameof(Products)}");

            // Configuración de la entidad Order (orden).
            builder.Entity<Order>().Property(o => o.Comments).HasMaxLength(500);
            builder.Entity<Order>().Property(p => p.Discount).HasColumnType(priceDecimalType);
            builder.Entity<Order>().ToTable($"{tablePrefix}{nameof(Orders)}");

            // Configuración de la entidad OrderDetail (detalle de orden).
            builder.Entity<OrderDetail>().Property(p => p.UnitPrice).HasColumnType(priceDecimalType);
            builder.Entity<OrderDetail>().Property(p => p.Discount).HasColumnType(priceDecimalType);
            builder.Entity<OrderDetail>().ToTable($"{tablePrefix}{nameof(OrderDetails)}");

            // --- Configuración para entidades de la librería universitaria ---

            // Configuración de la entidad Libro.
            builder.Entity<Libro>(entity =>
            {
                entity.ToTable($"{tablePrefix}Libros");
                entity.Property(l => l.Titulo).IsRequired().HasMaxLength(200);
                entity.Property(l => l.Autor).IsRequired().HasMaxLength(150);
                entity.Property(l => l.Precio).HasColumnType(priceDecimalType);
                entity.Property(l => l.Stock).IsRequired();
                entity.HasOne(l => l.Categoria)
                      .WithMany(c => c.Libros)
                      .HasForeignKey(l => l.CategoriaId)
                      .OnDelete(DeleteBehavior.Restrict); // No permite borrar la categoría si hay libros asociados.
                entity.HasOne(l => l.Proveedor)
                      .WithMany(p => p.Libros)
                      .HasForeignKey(l => l.ProveedorId)
                      .OnDelete(DeleteBehavior.SetNull); // Si se elimina el proveedor, el campo queda nulo.
                entity.HasIndex(l => l.Titulo);
            });

            // Configuración de la entidad Categoria.
            builder.Entity<Categoria>(entity =>
            {
                entity.ToTable($"{tablePrefix}Categorias");
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Descripcion).HasMaxLength(300);
                entity.HasIndex(c => c.Nombre).IsUnique(); // El nombre de la categoría es único.
            });

            // Configuración de la entidad Venta.
            builder.Entity<Venta>(entity =>
            {
                entity.ToTable($"{tablePrefix}Ventas");
                entity.Property(v => v.Total).HasColumnType(priceDecimalType);
                entity.Property(v => v.Fecha).IsRequired();
                entity.HasOne(v => v.Cliente)
                      .WithMany(c => c.Ventas)
                      .HasForeignKey(v => v.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict); // No permite borrar el cliente si hay ventas asociadas.
            });

            // Configuración de la entidad VentaDetalle.
            builder.Entity<VentaDetalle>(entity =>
            {
                entity.ToTable($"{tablePrefix}VentaDetalles");
                entity.Property(d => d.PrecioUnitario).HasColumnType(priceDecimalType);
                entity.Property(d => d.Cantidad).IsRequired();
                entity.HasOne(d => d.Venta)
                      .WithMany(v => v.Detalles)
                      .HasForeignKey(d => d.VentaId)
                      .OnDelete(DeleteBehavior.Cascade); // Si se elimina la venta, se eliminan los detalles.
                entity.HasOne(d => d.Libro)
                      .WithMany(l => l.VentaDetalles)
                      .HasForeignKey(d => d.LibroId)
                      .OnDelete(DeleteBehavior.Restrict); // No permite borrar el libro si hay detalles asociados.
            });

            // Configuración de la entidad Cliente.
            builder.Entity<Cliente>(entity =>
            {
                entity.ToTable($"{tablePrefix}Clientes");
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Email).HasMaxLength(100);
                entity.Property(c => c.Telefono).HasMaxLength(30);
                entity.Property(c => c.Direccion).HasMaxLength(200);
                entity.HasIndex(c => c.Nombre);
            });

            // Configuración de la entidad Proveedor.
            builder.Entity<Proveedor>(entity =>
            {
                entity.ToTable($"{tablePrefix}Proveedores");
                entity.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.Telefono).HasMaxLength(30);
                entity.Property(p => p.Direccion).HasMaxLength(200);
                entity.HasIndex(p => p.Nombre);
            });
            // --- Fin configuración librería universitaria ---
        }

        /// <summary>
        /// Guarda los cambios en la base de datos y agrega información de auditoría.
        /// </summary>
        /// <returns>Número de entidades afectadas.</returns>
        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos y agrega información de auditoría.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Si se deben aceptar todos los cambios al tener éxito.</param>
        /// <returns>Número de entidades afectadas.</returns>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddAuditInfo();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos de forma asíncrona y agrega información de auditoría.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Número de entidades afectadas.</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos de forma asíncrona y agrega información de auditoría.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Si se deben aceptar todos los cambios al tener éxito.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Número de entidades afectadas.</returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Agrega información de auditoría (usuario y fecha de creación/modificación) a las entidades auditables.
        /// </summary>
        private void AddAuditInfo()
        {
            var currentUserId = userIdAccessor.GetCurrentUserId();

            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity &&
                           (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = currentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = currentUserId;
            }
        }
    }
}
