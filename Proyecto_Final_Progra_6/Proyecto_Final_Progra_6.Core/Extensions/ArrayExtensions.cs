namespace Proyecto_Final_Progra_6.Core.Extensions
{
    /// <summary>
    /// Proporciona métodos de extensión para trabajar con arreglos.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Devuelve <c>null</c> si el arreglo está vacío; de lo contrario, devuelve el arreglo original.
        /// </summary>
        /// <typeparam name="T">Tipo de los elementos del arreglo.</typeparam>
        /// <param name="value">Arreglo a evaluar.</param>
        /// <returns>
        /// <c>null</c> si el arreglo está vacío o es <c>null</c>; de lo contrario, el arreglo original.
        /// </returns>
        public static T[]? NullIfEmpty<T>(this T[]? value) => value?.Length == 0 ? null : value;

        /// <summary>
        /// Devuelve un arreglo vacío si el valor es <c>null</c>; de lo contrario, devuelve el arreglo original.
        /// </summary>
        /// <typeparam name="T">Tipo de los elementos del arreglo.</typeparam>
        /// <param name="value">Arreglo a evaluar.</param>
        /// <returns>
        /// Un arreglo vacío si <paramref name="value"/> es <c>null</c>; de lo contrario, el arreglo original.
        /// </returns>
        public static T[]? EmptyIfNull<T>(this T[]? value) => value ?? [];
    }
}
