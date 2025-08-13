// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: ProductController.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Server
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Server\Controllers\ProductController.cs
//
// Descripción o propósito del archivo:
// Controlador para la gestión de productos (libros) en la Librería Universidad. Incluye endpoints
// para CRUD de productos, con protección por roles, validaciones y manejo de errores.
// =====================================================================================

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Progra_6.Core.Services.Shop;
using Proyecto_Final_Progra_6.Server.ViewModels.Shop;
using Proyecto_Final_Progra_6.Core.Models.Shop;

namespace Proyecto_Final_Progra_6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        // ======================================================== INICIO - OBTENER TODOS LOS PRODUCTOS ========================================================
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductVM>>(products));
        }
        // ======================================================== FIN - OBTENER TODOS LOS PRODUCTOS ===========================================================

        // ======================================================== INICIO - OBTENER PRODUCTO POR ID ============================================================
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound($"Producto con ID {id} no encontrado.");
            return Ok(_mapper.Map<ProductVM>(product));
        }
        // ======================================================== FIN - OBTENER PRODUCTO POR ID ==============================================================

        // ======================================================== INICIO - CREAR NUEVO PRODUCTO ==============================================================
        [HttpPost]
        public IActionResult Post([FromBody] ProductVM value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = _mapper.Map<Product>(value);
            var created = _productService.CreateProduct(product);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, _mapper.Map<ProductVM>(created));
        }
        // ======================================================== FIN - CREAR NUEVO PRODUCTO ================================================================

        // ======================================================== INICIO - ACTUALIZAR PRODUCTO ===============================================================
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductVM value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = _mapper.Map<Product>(value);
            var updated = _productService.UpdateProduct(id, product);
            if (updated == null)
                return NotFound($"Producto con ID {id} no encontrado.");
            return Ok(_mapper.Map<ProductVM>(updated));
        }
        // ======================================================== FIN - ACTUALIZAR PRODUCTO ==================================================================

        // ======================================================== INICIO - ELIMINAR PRODUCTO ==================================================================
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _productService.DeleteProduct(id);
            if (!deleted)
                return NotFound($"Producto con ID {id} no encontrado.");
            return NoContent();
        }
        // ======================================================== FIN - ELIMINAR PRODUCTO =====================================================================
    }
}
