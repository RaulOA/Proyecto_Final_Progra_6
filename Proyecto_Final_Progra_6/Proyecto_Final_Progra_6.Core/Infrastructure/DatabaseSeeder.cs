// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: DatabaseSeeder.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Core
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Core\Infrastructure\DatabaseSeeder.cs
//
// Descripción o propósito del archivo:
// Inicializa la base de datos con usuarios, roles y datos de demostración para la Libreria Universidad.
// Incluye la creación de roles y usuarios predeterminados, así como datos de ejemplo para pruebas.
//
// Historial de cambios:
// 27/04/2024 - Adaptación de comentarios, estructura y metadatos según estándares de Libreria Universidad.
//            - Traducción de comentarios y secciones al español.
//            - Eliminación de referencias a plantillas originales y autores previos.
//
// Alertas Críticas:
// - 27/04/2024 - Revisar que los datos de demostración no se utilicen en producción.
// =====================================================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Proyecto_Final_Progra_6.Core.Models;
using Proyecto_Final_Progra_6.Core.Models.Account;
using Proyecto_Final_Progra_6.Core.Models.Shop;
using Proyecto_Final_Progra_6.Core.Services.Account;

namespace Proyecto_Final_Progra_6.Core.Infrastructure
{
    // ======================================================== INICIO - CLASE DatabaseSeeder ========================================================
    // Clase responsable de inicializar la base de datos con datos predeterminados y de demostración.
    // **********************************************************************************************************************************************
    public class DatabaseSeeder(ApplicationDbContext dbContext, ILogger<DatabaseSeeder> logger,
        IUserAccountService userAccountService, IUserRoleService userRoleService) : IDatabaseSeeder
    {
        public async Task SeedAsync()
        {
            await dbContext.Database.MigrateAsync();
            await SeedDefaultUsersAsync();
            await SeedDemoDataAsync();
        }

        // ======================================================== INICIO - USUARIOS Y ROLES POR DEFECTO ========================================================
        // Crea los roles y usuarios predeterminados para la aplicación.
        // **********************************************************************************************************************************************
        private async Task SeedDefaultUsersAsync()
        {
            // Siempre asegura que los roles existen, aunque ya existan usuarios
            const string adminRoleName = "Administrador";
            const string clienteRoleName = "Cliente";

            await EnsureRoleAsync(adminRoleName, "Administrador del sistema", ApplicationPermissions.GetAllPermissionValues());
            await EnsureRoleAsync(clienteRoleName, "Cliente de la librería", []);

            // Solo crea usuarios de ejemplo si la tabla está vacía
            if (!await dbContext.Users.AnyAsync())
            {
                logger.LogInformation("Generando cuentas internas predeterminadas");

                await CreateUserAsync("admin",
                                      "tempP@ss123",
                                      "Administrador General",
                                      "admin@libreria.com",
                                      "+1 (123) 000-0000",
                                      [adminRoleName]);

                await CreateUserAsync("cliente",
                                      "tempP@ss123",
                                      "Cliente Demo",
                                      "cliente@libreria.com",
                                      "+1 (123) 000-0003",
                                      [clienteRoleName]);

                logger.LogInformation("Generación de cuentas internas completada");
            }
        }

        private async Task EnsureRoleAsync(string roleName, string description, string[] claims)
        {
            if (await userRoleService.GetRoleByNameAsync(roleName) == null)
            {
                logger.LogInformation("Generando rol predeterminado: {roleName}", roleName);

                var applicationRole = new ApplicationRole(roleName, description);

                var result = await userRoleService.CreateRoleAsync(applicationRole, claims);

                if (!result.Succeeded)
                {
                    throw new UserRoleException($"Error al crear el rol \"{description}\". Errores: " +
                        $"{string.Join(Environment.NewLine, result.Errors)}");
                }
            }
        }

        private async Task<ApplicationUser> CreateUserAsync(
            string userName, string password, string fullName, string email, string phoneNumber, string[] roles)
        {
            logger.LogInformation("Generando usuario predeterminado: {userName}", userName);

            var applicationUser = new ApplicationUser
            {
                UserName = userName,
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                EmailConfirmed = true,
                IsEnabled = true
            };

            var result = await userAccountService.CreateUserAsync(applicationUser, roles, password);

            if (!result.Succeeded)
            {
                throw new UserAccountException($"Error al crear el usuario \"{userName}\". Errores: " +
                    $"{string.Join(Environment.NewLine, result.Errors)}");
            }

            return applicationUser;
        }
        // ======================================================== FIN - USUARIOS Y ROLES POR DEFECTO =========================================================

        // ======================================================== INICIO - DATOS DE DEMOSTRACIÓN ========================================================
        // Inserta datos de ejemplo para pruebas y desarrollo.
        // **********************************************************************************************************************************************
        private async Task SeedDemoDataAsync()
        {
            if (!await dbContext.Customers.AnyAsync() && !await dbContext.ProductCategories.AnyAsync())
            {
                logger.LogInformation("Insertando datos de demostración");

                var cust_1 = new Customer
                {
                    Name = "Ejemplo Cliente 1",
                    Email = "cliente1@libreria.com",
                    Gender = Gender.Male
                };

                var cust_2 = new Customer
                {
                    Name = "Ejemplo Cliente 2",
                    Email = "cliente2@libreria.com",
                    PhoneNumber = "+81123456789",
                    Address = "Dirección ficticia, Calle 123, Ciudad Demo",
                    City = "Ciudad Demo",
                    Gender = Gender.Male
                };

                var cust_3 = new Customer
                {
                    Name = "Ejemplo Cliente 3",
                    Email = "cliente3@libreria.com",
                    PhoneNumber = "+18585858",
                    Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                    Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at elementum imperdiet",
                    City = "Lorem Ipsum",
                    Gender = Gender.Male
                };

                var cust_4 = new Customer
                {
                    Name = "Ejemplo Cliente 4",
                    Email = "cliente4@libreria.com",
                    PhoneNumber = "+18585858",
                    Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                    Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at elementum imperdiet",
                    City = "Lorem Ipsum",
                    Gender = Gender.Male
                };

                var prodCat_1 = new ProductCategory
                {
                    Name = "Sin categoría",
                    Description = "Categoría por defecto. Productos sin categoría asignada"
                };

                var prod_1 = new Product
                {
                    Name = "Libro de Ejemplo 1",
                    Description = "Libro de muestra para pruebas de la Libreria Universidad",
                    BuyingPrice = 100,
                    SellingPrice = 120,
                    UnitsInStock = 12,
                    IsActive = true,
                    ProductCategory = prodCat_1
                };

                var prod_2 = new Product
                {
                    Name = "Libro de Ejemplo 2",
                    Description = "Segundo libro de muestra para pruebas",
                    BuyingPrice = 80,
                    SellingPrice = 95,
                    UnitsInStock = 4,
                    IsActive = true,
                    ProductCategory = prodCat_1
                };

                var ordr_1 = new Order
                {
                    Discount = 10,
                    Cashier = await dbContext.Users.OrderBy(u => u.UserName).FirstAsync(),
                    Customer = cust_1
                };

                var ordr_2 = new Order
                {
                    Cashier = await dbContext.Users.OrderBy(u => u.UserName).FirstAsync(),
                    Customer = cust_2
                };

                ordr_1.OrderDetails.Add(new()
                {
                    UnitPrice = prod_1.SellingPrice,
                    Quantity = 1,
                    Product = prod_1,
                    Order = ordr_1
                });
                ordr_1.OrderDetails.Add(new()
                {
                    UnitPrice = prod_2.SellingPrice,
                    Quantity = 1,
                    Product = prod_2,
                    Order = ordr_1
                });

                ordr_2.OrderDetails.Add(new()
                {
                    UnitPrice = prod_2.SellingPrice,
                    Quantity = 1,
                    Product = prod_2,
                    Order = ordr_2
                });

                dbContext.Customers.Add(cust_1);
                dbContext.Customers.Add(cust_2);
                dbContext.Customers.Add(cust_3);
                dbContext.Customers.Add(cust_4);

                dbContext.Products.Add(prod_1);
                dbContext.Products.Add(prod_2);

                dbContext.Orders.Add(ordr_1);
                dbContext.Orders.Add(ordr_2);

                await dbContext.SaveChangesAsync();

                logger.LogInformation("Datos de demostración insertados correctamente");
            }
        }
        // ======================================================== FIN - DATOS DE DEMOSTRACIÓN =========================================================
    }
    // ======================================================== FIN - CLASE DatabaseSeeder ============================================================
}
