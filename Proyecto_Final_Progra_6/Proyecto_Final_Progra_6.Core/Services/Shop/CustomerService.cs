// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Progra_6.Core.Infrastructure;
using Proyecto_Final_Progra_6.Core.Models.Shop;

namespace Proyecto_Final_Progra_6.Core.Services.Shop
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Customer> GetTopActiveCustomers(int count) => throw new NotImplementedException();

        public IEnumerable<Customer> GetAllCustomersData() => _dbContext.Customers
                .Include(c => c.Orders).ThenInclude(o => o.OrderDetails).ThenInclude(d => d.Product)
                .Include(c => c.Orders).ThenInclude(o => o.Cashier)
                .AsSingleQuery()
                .OrderBy(c => c.Name)
                .ToList();

        // ======================================================== INICIO - OBTENER CLIENTE POR ID ========================================================
        public Customer? GetCustomerById(int id)
        {
            return _dbContext.Customers
                .Include(c => c.Orders).ThenInclude(o => o.OrderDetails)
                .FirstOrDefault(c => c.Id == id);
        }
        // ======================================================== FIN - OBTENER CLIENTE POR ID ==========================================================

        // ======================================================== INICIO - CREAR NUEVO CLIENTE ==========================================================
        public Customer CreateCustomer(Customer customer)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(customer.Name) || customer.Name.Length > 100)
                throw new ArgumentException("El nombre es obligatorio y debe tener máximo 100 caracteres.");
            if (!string.IsNullOrWhiteSpace(customer.Email) && customer.Email.Length > 100)
                throw new ArgumentException("El email debe tener máximo 100 caracteres.");
            if (!string.IsNullOrWhiteSpace(customer.PhoneNumber) && customer.PhoneNumber.Length > 30)
                throw new ArgumentException("El teléfono debe tener máximo 30 caracteres.");
            if (!string.IsNullOrWhiteSpace(customer.Address) && customer.Address.Length > 200)
                throw new ArgumentException("La dirección debe tener máximo 200 caracteres.");

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }
        // ======================================================== FIN - CREAR NUEVO CLIENTE =============================================================

        // ======================================================== INICIO - ACTUALIZAR CLIENTE ===========================================================
        public Customer? UpdateCustomer(int id, Customer customer)
        {
            var existing = _dbContext.Customers.Find(id);
            if (existing == null) return null;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(customer.Name) || customer.Name.Length > 100)
                throw new ArgumentException("El nombre es obligatorio y debe tener máximo 100 caracteres.");
            if (!string.IsNullOrWhiteSpace(customer.Email) && customer.Email.Length > 100)
                throw new ArgumentException("El email debe tener máximo 100 caracteres.");
            if (!string.IsNullOrWhiteSpace(customer.PhoneNumber) && customer.PhoneNumber.Length > 30)
                throw new ArgumentException("El teléfono debe tener máximo 30 caracteres.");
            if (!string.IsNullOrWhiteSpace(customer.Address) && customer.Address.Length > 200)
                throw new ArgumentException("La dirección debe tener máximo 200 caracteres.");

            existing.Name = customer.Name;
            existing.Email = customer.Email;
            existing.PhoneNumber = customer.PhoneNumber;
            existing.Address = customer.Address;
            existing.City = customer.City;
            existing.Gender = customer.Gender;
            _dbContext.SaveChanges();
            return existing;
        }
        // ======================================================== FIN - ACTUALIZAR CLIENTE =============================================================

        // ======================================================== INICIO - ELIMINAR CLIENTE =============================================================
        public bool DeleteCustomer(int id)
        {
            var existing = _dbContext.Customers.Find(id);
            if (existing == null) return false;
            _dbContext.Customers.Remove(existing);
            _dbContext.SaveChanges();
            return true;
        }
        // ======================================================== FIN - ELIMINAR CLIENTE ===============================================================
    }
}
