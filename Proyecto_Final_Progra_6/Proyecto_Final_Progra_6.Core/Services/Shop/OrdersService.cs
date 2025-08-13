// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: OrdersService.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Core
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Core\Services\Shop\OrdersService.cs
//
// Descripción o propósito del archivo:
// Implementación de la lógica de negocio para la gestión de órdenes (ventas) en la Librería Universidad.
// Incluye métodos CRUD y validaciones según las reglas del proyecto.
// =====================================================================================

using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Progra_6.Core.Infrastructure;
using Proyecto_Final_Progra_6.Core.Models.Shop;

namespace Proyecto_Final_Progra_6.Core.Services.Shop
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrdersService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Order> GetAllOrders() => _dbContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.Cashier)
            .Include(o => o.OrderDetails)
            .OrderBy(o => o.Id)
            .ToList();

        public Order? GetOrderById(int id)
        {
            return _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Cashier)
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == id);
        }

        public Order CreateOrder(Order order)
        {
            // Validaciones básicas
            if (order.CustomerId <= 0)
                throw new ArgumentException("El cliente es obligatorio.");
            if (order.OrderDetails == null || !order.OrderDetails.Any())
                throw new ArgumentException("La orden debe tener al menos un detalle.");
            if (order.Discount < 0)
                throw new ArgumentException("El descuento no puede ser negativo.");

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order;
        }

        public Order? UpdateOrder(int id, Order order)
        {
            var existing = _dbContext.Orders.Find(id);
            if (existing == null) return null;

            // Validaciones básicas
            if (order.CustomerId <= 0)
                throw new ArgumentException("El cliente es obligatorio.");
            if (order.OrderDetails == null || !order.OrderDetails.Any())
                throw new ArgumentException("La orden debe tener al menos un detalle.");
            if (order.Discount < 0)
                throw new ArgumentException("El descuento no puede ser negativo.");

            existing.Discount = order.Discount;
            existing.Comments = order.Comments;
            existing.CashierId = order.CashierId;
            existing.CustomerId = order.CustomerId;
            // No se actualizan los detalles aquí por simplicidad
            _dbContext.SaveChanges();
            return existing;
        }

        public bool DeleteOrder(int id)
        {
            var existing = _dbContext.Orders.Find(id);
            if (existing == null) return false;
            _dbContext.Orders.Remove(existing);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
