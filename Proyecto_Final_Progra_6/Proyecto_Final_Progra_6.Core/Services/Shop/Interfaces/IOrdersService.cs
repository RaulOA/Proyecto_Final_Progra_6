// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: IOrdersService.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Core
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Core\Services\Shop\Interfaces\IOrdersService.cs
//
// Descripción o propósito del archivo:
// Interfaz para la gestión de órdenes (ventas) en la Librería Universidad. Define métodos para
// CRUD de órdenes y consultas avanzadas, siguiendo las reglas de negocio y validaciones.
// =====================================================================================

using Proyecto_Final_Progra_6.Core.Models.Shop;

namespace Proyecto_Final_Progra_6.Core.Services.Shop
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetAllOrders();
        Order? GetOrderById(int id);
        Order CreateOrder(Order order);
        Order? UpdateOrder(int id, Order order);
        bool DeleteOrder(int id);
    }
}
