using AutoMapper;
using TiendaServicios.Api.Autor.Model;

namespace TiendaServicios.Api.Autor.Dto
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<BookAuthor,BookAuthorDto>();
        }
    }
}
