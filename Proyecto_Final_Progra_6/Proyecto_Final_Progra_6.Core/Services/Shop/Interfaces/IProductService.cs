// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: IProductService.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Core
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Core\Services\Shop\Interfaces\IProductService.cs
//
// Descripción o propósito del archivo:
// Interfaz para la gestión de productos (libros) en la Librería Universidad. Define métodos para
// CRUD de productos y consultas avanzadas, siguiendo las reglas de negocio y validaciones.
// =====================================================================================

using Proyecto_Final_Progra_6.Core.Models.Shop;

namespace Proyecto_Final_Progra_6.Core.Services.Shop
{
    public interface IProductService
    {
        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <returns>IEnumerable<Product></returns>
        IEnumerable<Product> GetAllProducts();

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Product?</returns>
        Product? GetProductById(int id);

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="product">Producto a crear.</param>
        /// <returns>Product</returns>
        Product CreateProduct(Product product);

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="id">ID del producto a actualizar.</param>
        /// <param name="product">Producto con la información actualizada.</param>
        /// <returns>Product?</returns>
        Product? UpdateProduct(int id, Product product);

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto a eliminar.</param>
        /// <returns>bool</returns>
        bool DeleteProduct(int id);
    }
}
