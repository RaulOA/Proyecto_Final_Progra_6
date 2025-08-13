// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: ICustomerService.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Core
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Core\Services\Shop\Interfaces\ICustomerService.cs
//
// Descripción o propósito del archivo:
// Interfaz para la gestión de clientes en la Librería Universidad. Define métodos para
// CRUD de clientes y consultas avanzadas, siguiendo las reglas de negocio y validaciones.
//
// Historial de cambios:
// 1. 04/08/2025 - Se agregaron métodos CRUD y comentarios descriptivos en español.
// =====================================================================================

using Proyecto_Final_Progra_6.Core.Models.Shop;

namespace Proyecto_Final_Progra_6.Core.Services.Shop
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetTopActiveCustomers(int count);
        IEnumerable<Customer> GetAllCustomersData();
        Customer? GetCustomerById(int id);
        Customer CreateCustomer(Customer customer);
        Customer? UpdateCustomer(int id, Customer customer);
        bool DeleteCustomer(int id);
    }
}
