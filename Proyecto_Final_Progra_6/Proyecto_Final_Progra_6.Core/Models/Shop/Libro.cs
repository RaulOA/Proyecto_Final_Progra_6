using System;
using System.Collections.Generic;
using Proyecto_Final_Progra_6.Core.Models;

namespace Proyecto_Final_Progra_6.Core.Models.Shop
{
    public class Libro : IAuditableEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int? ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }
        // Auditoría
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
    }
}