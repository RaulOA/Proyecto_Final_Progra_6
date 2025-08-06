using System;
using System.Collections.Generic;
using Proyecto_Final_Progra_6.Core.Models;

namespace Proyecto_Final_Progra_6.Core.Models.Shop
{
    /// <summary>
    /// Representa una categor�a de libros en la tienda.
    /// </summary>
    public class Categoria : IAuditableEntity
    {
        /// <summary>
        /// Identificador �nico de la categor�a.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la categor�a.
        /// </summary>
        public string Nombre { get; set; } = null!;

        /// <summary>
        /// Descripci�n opcional de la categor�a.
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Colecci�n de libros asociados a esta categor�a.
        /// </summary>
        public ICollection<Libro> Libros { get; set; } = new List<Libro>();

        // Auditor�a

        /// <summary>
        /// Usuario que cre� la entidad.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Fecha de creaci�n de la entidad.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Usuario que actualiz� por �ltima vez la entidad.
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Fecha de la �ltima actualizaci�n de la entidad.
        /// </summary>
        public DateTime UpdatedDate { get; set; }
    }
}