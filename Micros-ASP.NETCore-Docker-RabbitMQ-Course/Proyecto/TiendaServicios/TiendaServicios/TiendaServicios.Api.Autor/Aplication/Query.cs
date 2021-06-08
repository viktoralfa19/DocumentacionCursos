using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Dto;
using TiendaServicios.Api.Autor.Model;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Aplication
{
    /// <summary>
    /// Class Query
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Class ListAuthor
        /// </summary>
        /// <seealso cref="IRequest{ICollection{BookAuthor}}" />
        public class ListAuthor: IRequest<ICollection<BookAuthorDto>>
        {
        }

        /// <summary>
        /// Management
        /// </summary>
        /// <seealso cref="IRequestHandler{Query.ListAuthor, ICollection{BookAuthor}}" />
        public class Management : IRequestHandler<ListAuthor, ICollection<BookAuthorDto>>
        {
            /// <summary>
            /// The context
            /// </summary>
            private readonly DbContextAuthor _context;
            /// <summary>
            /// The mapper
            /// </summary>
            private readonly IMapper _mapper;

            /// <summary>
            /// Initializes a new instance of the <see cref="Management"/> class.
            /// </summary>
            /// <param name="context">The context.</param>
            /// <param name="mapper">The mapper.</param>
            public Management(DbContextAuthor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            /// <summary>
            /// Handles a request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">Cancellation token</param>
            /// <returns>
            /// Response from the request
            /// </returns>
            public async Task<ICollection<BookAuthorDto>> Handle(ListAuthor request, CancellationToken cancellationToken)
            {
                var authors = await _context.BookAuthor.ToListAsync();
                return _mapper.Map<ICollection<BookAuthor>, ICollection<BookAuthorDto>>(authors);
            }
        }
    }
}
