// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: ProductService.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Core
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Core\Services\Shop\ProductService.cs
//
// Descripción o propósito del archivo:
// Implementación de la lógica de negocio para la gestión de productos (libros) en la Librería Universidad.
// Incluye métodos CRUD y validaciones según las reglas del proyecto.
// =====================================================================================

using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Progra_6.Core.Infrastructure;
using Proyecto_Final_Progra_6.Core.Models.Shop;

namespace Proyecto_Final_Progra_6.Core.Services.Shop
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts() => _dbContext.Products
            .Include(p => p.ProductCategory)
            .Include(p => p.Children)
            .Include(p => p.OrderDetails)
            .OrderBy(p => p.Name)
            .ToList();

        public Product? GetProductById(int id)
        {
            return _dbContext.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.Children)
                .Include(p => p.OrderDetails)
                .FirstOrDefault(p => p.Id == id);
        }

        public Product CreateProduct(Product product)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(product.Name) || product.Name.Length > 100)
                throw new ArgumentException("El nombre es obligatorio y debe tener máximo 100 caracteres.");
            if (!string.IsNullOrWhiteSpace(product.Description) && product.Description.Length > 500)
                throw new ArgumentException("La descripción debe tener máximo 500 caracteres.");
            if (!string.IsNullOrWhiteSpace(product.Icon) && product.Icon.Length > 256)
                throw new ArgumentException("El icono debe tener máximo 256 caracteres.");
            if (product.SellingPrice < 0)
                throw new ArgumentException("El precio de venta no puede ser negativo.");
            if (product.UnitsInStock < 0)
                throw new ArgumentException("Las unidades en stock no pueden ser negativas.");

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public Product? UpdateProduct(int id, Product product)
        {
            var existing = _dbContext.Products.Find(id);
            if (existing == null) return null;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(product.Name) || product.Name.Length > 100)
                throw new ArgumentException("El nombre es obligatorio y debe tener máximo 100 caracteres.");
            if (!string.IsNullOrWhiteSpace(product.Description) && product.Description.Length > 500)
                throw new ArgumentException("La descripción debe tener máximo 500 caracteres.");
            if (!string.IsNullOrWhiteSpace(product.Icon) && product.Icon.Length > 256)
                throw new ArgumentException("El icono debe tener máximo 256 caracteres.");
            if (product.SellingPrice < 0)
                throw new ArgumentException("El precio de venta no puede ser negativo.");
            if (product.UnitsInStock < 0)
                throw new ArgumentException("Las unidades en stock no pueden ser negativas.");

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Icon = product.Icon;
            existing.BuyingPrice = product.BuyingPrice;
            existing.SellingPrice = product.SellingPrice;
            existing.UnitsInStock = product.UnitsInStock;
            existing.IsActive = product.IsActive;
            existing.IsDiscontinued = product.IsDiscontinued;
            existing.ProductCategoryId = product.ProductCategoryId;
            _dbContext.SaveChanges();
            return existing;
        }

        public bool DeleteProduct(int id)
        {
            var existing = _dbContext.Products.Find(id);
            if (existing == null) return false;
            _dbContext.Products.Remove(existing);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
