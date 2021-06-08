using System;
using System.Collections.Generic;

namespace TiendaServicios.Api.Autor.Model
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string BookAuthorGuid { get; set; }

        public virtual ICollection<AcademicGrade> ListAcademicGrade { get; set; }
    }
}
