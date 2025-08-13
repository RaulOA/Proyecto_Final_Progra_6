// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: CustomerVM.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Server
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Server\ViewModels\Shop\CustomerVM.cs
//
// Descripción o propósito del archivo:
// Define el ViewModel para clientes en la Libreria Universidad, incluyendo validaciones
// y estructura de datos para la gestión de clientes desde el frontend.
//
// Historial de cambios:
// 27/04/2024 - Adaptación de comentarios, estructura y metadatos según estándares de Libreria Universidad.
//            - Traducción de mensajes de validación y secciones al español.
//            - Eliminación de referencias a plantillas originales y autores previos.
//
// Alertas Críticas:
// - 27/04/2024 - Validar que la contraseña no se exponga en respuestas del backend.
// =====================================================================================

using FluentValidation;

namespace Proyecto_Final_Progra_6.Server.ViewModels.Shop
{
    // ======================================================== INICIO - VIEWMODEL DE CLIENTE ========================================================
    // ViewModel para la gestión de clientes en la Libreria Universidad.
    // **********************************************************************************************************************************************
    public class CustomerVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Gender { get; set; }
        public string? Password { get; set; } // Permite enviar la contraseña desde el frontend

        public ICollection<OrderVM>? Orders { get; set; }
    }
    // ======================================================== FIN - VIEWMODEL DE CLIENTE =========================================================

    // ======================================================== INICIO - VALIDACIÓN DE CLIENTE ========================================================
    // Validador para el ViewModel de cliente, usando FluentValidation.
    // **********************************************************************************************************************************************
    public class CustomerViewModelValidator : AbstractValidator<CustomerVM>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(register => register.Name).NotEmpty().WithMessage("El nombre del cliente no puede estar vacío");
            RuleFor(register => register.Gender).NotEmpty().WithMessage("El género no puede estar vacío");
        }
    }
    // ======================================================== FIN - VALIDACIÓN DE CLIENTE =========================================================
}
