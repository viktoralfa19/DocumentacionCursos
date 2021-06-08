using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Model;

namespace TiendaServicios.Api.Autor.Persistence
{
    public class DbContextAuthor: DbContext
    {
        public DbContextAuthor(DbContextOptions<DbContextAuthor> options): base(options){}

        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<AcademicGrade> AcademicGrade { get; set; }
    }
}
