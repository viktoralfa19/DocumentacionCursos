using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Dto;
using TiendaServicios.Api.Autor.Model;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Aplication
{
    /// <summary>
    /// Class QueryFilter
    /// </summary>
    public class QueryFilter
    {
        /// <summary>
        /// Class UniqueAuthor
        /// </summary>
        /// <seealso cref="MediatR.IRequest{BookAuthorDto}" />
        public class UniqueAuthor: IRequest<BookAuthorDto>
        {
            public string AuthorGuid { get; set; }
        }

        /// <summary>
        /// Management
        /// </summary>
        /// <seealso cref="IRequestHandler{UniqueAuthor, BookAuthorDto}" />
        public class Management : IRequestHandler<UniqueAuthor, BookAuthorDto>
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
            public async Task<BookAuthorDto> Handle(UniqueAuthor request, CancellationToken cancellationToken)
            {
                var author = await _context.BookAuthor.FirstOrDefaultAsync(d=>d.BookAuthorGuid == request.AuthorGuid);
                if (author == null)
                    throw new Exception("Usuario no encontrado");
                return _mapper.Map<BookAuthor, BookAuthorDto>(author);
            }
        }
    }
}
