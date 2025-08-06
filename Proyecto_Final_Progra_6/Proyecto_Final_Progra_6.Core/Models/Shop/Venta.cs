using System;
using System.Collections.Generic;
using Proyecto_Final_Progra_6.Core.Models;

namespace Proyecto_Final_Progra_6.Core.Models.Shop
{
    public class Venta : IAuditableEntity
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public ICollection<VentaDetalle> Detalles { get; set; } = new List<VentaDetalle>();
        // Auditoría
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    public class VentaDetalle
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public Venta Venta { get; set; } = null!;
        public int LibroId { get; set; }
        public Libro Libro { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}