using System;

namespace TiendaServicios.Api.Autor.Dto
{
    /// <summary>
    /// Class BookAuthotDto
    /// </summary>
    public class BookAuthorDto
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the birthdate.
        /// </summary>
        /// <value>
        /// The birthdate.
        /// </value>
        public DateTime? Birthdate { get; set; }
        /// <summary>
        /// Gets or sets the book author unique identifier.
        /// </summary>
        /// <value>
        /// The book author unique identifier.
        /// </value>
        public string BookAuthorGuid { get; set; }
    }
}
