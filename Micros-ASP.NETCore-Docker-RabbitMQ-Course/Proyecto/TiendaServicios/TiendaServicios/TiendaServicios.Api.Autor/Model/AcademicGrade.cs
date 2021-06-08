using System;

namespace TiendaServicios.Api.Autor.Model
{
    public class AcademicGrade
    {
        public short Id { get; set; }
        public int BookAuthorId { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime GradeDate { get; set; }
        public string AcademicGradeGuid { get; set; }

        public virtual BookAuthor BookAuthor { get; set; }
    }
}
