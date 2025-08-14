// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: OrderController.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Server
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Server\Controllers\OrderController.cs
//
// Descripción o propósito del archivo:
// Controlador para la gestión de órdenes (ventas) en la Librería Universidad. Incluye endpoints
// para CRUD de órdenes, con protección por roles, validaciones y manejo de errores.
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
    [Authorize(Roles = "Administrador,Cliente")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrdersService _ordersService;

        public OrderController(IMapper mapper, IOrdersService ordersService)
        {
            _mapper = mapper;
            _ordersService = ordersService;
        }

        // ======================================================== INICIO - OBTENER TODAS LAS ÓRDENES ========================================================
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _ordersService.GetAllOrders();
            return Ok(_mapper.Map<IEnumerable<OrderVM>>(orders));
        }
        // ======================================================== FIN - OBTENER TODAS LAS ÓRDENES ===========================================================

        // ======================================================== INICIO - OBTENER ORDEN POR ID ============================================================
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _ordersService.GetOrderById(id);
            if (order == null)
                return NotFound($"Orden con ID {id} no encontrada.");
            return Ok(_mapper.Map<OrderVM>(order));
        }
        // ======================================================== FIN - OBTENER ORDEN POR ID ==============================================================

        // ======================================================== INICIO - CREAR NUEVA ORDEN ==============================================================
        [HttpPost]
        public IActionResult Post([FromBody] OrderVM value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var order = _mapper.Map<Order>(value);
            var created = _ordersService.CreateOrder(order);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, _mapper.Map<OrderVM>(created));
        }
        // ======================================================== FIN - CREAR NUEVA ORDEN ================================================================

        // ======================================================== INICIO - ACTUALIZAR ORDEN ===============================================================
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderVM value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var order = _mapper.Map<Order>(value);
            var updated = _ordersService.UpdateOrder(id, order);
            if (updated == null)
                return NotFound($"Orden con ID {id} no encontrada.");
            return Ok(_mapper.Map<OrderVM>(updated));
        }
        // ======================================================== FIN - ACTUALIZAR ORDEN ==================================================================

        // ======================================================== INICIO - ELIMINAR ORDEN ==================================================================
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _ordersService.DeleteOrder(id);
            if (!deleted)
                return NotFound($"Orden con ID {id} no encontrada.");
            return NoContent();
        }
        // ======================================================== FIN - ELIMINAR ORDEN =====================================================================
    }
}
