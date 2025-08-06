using System;
using System.Collections.Generic;
using Proyecto_Final_Progra_6.Core.Models;

namespace Proyecto_Final_Progra_6.Core.Models.Shop
{
    public class Cliente : IAuditableEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
        // Auditoría
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}