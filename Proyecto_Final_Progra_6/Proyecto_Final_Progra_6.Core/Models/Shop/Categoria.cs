using System;
using System.Collections.Generic;
using Proyecto_Final_Progra_6.Core.Models;

namespace Proyecto_Final_Progra_6.Core.Models.Shop
{
    /// <summary>
    /// Representa una categoría de libros en la tienda.
    /// </summary>
    public class Categoria : IAuditableEntity
    {
        /// <summary>
        /// Identificador único de la categoría.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la categoría.
        /// </summary>
        public string Nombre { get; set; } = null!;

        /// <summary>
        /// Descripción opcional de la categoría.
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Colección de libros asociados a esta categoría.
        /// </summary>
        public ICollection<Libro> Libros { get; set; } = new List<Libro>();

        // Auditoría

        /// <summary>
        /// Usuario que creó la entidad.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Fecha de creación de la entidad.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Usuario que actualizó por última vez la entidad.
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Fecha de la última actualización de la entidad.
        /// </summary>
        public DateTime UpdatedDate { get; set; }
    }
}