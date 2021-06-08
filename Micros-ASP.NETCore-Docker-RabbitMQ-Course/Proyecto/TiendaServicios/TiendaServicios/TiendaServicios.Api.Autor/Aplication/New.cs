using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Model;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Aplication
{
    /// <summary>
    /// Class new
    /// </summary>
    public class New
    {
        /// <summary>
        /// Class Execute
        /// </summary>
        /// <seealso cref="IRequest" />
        public class Execute: IRequest
        {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>
            /// The name.
            /// </value>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the lastname.
            /// </summary>
            /// <value>
            /// The lastname.
            /// </value>
            public string Lastname { get; set; }
            /// <summary>
            /// Gets or sets the birthdate.
            /// </summary>
            /// <value>
            /// The birthdate.
            /// </value>
            public DateTime? Birthdate { get; set; }
        }

        /// <summary>
        /// Class ExcecuteValidation
        /// </summary>
        /// <seealso cref="AbstractValidator{Execute}" />
        public class ExcecuteValidation: AbstractValidator<Execute>
        {
            public ExcecuteValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Lastname).NotEmpty();
                RuleFor(x => x.Birthdate).NotEmpty();
            }
        }

        /// <summary>
        /// Class Management
        /// </summary>
        /// <seealso cref="IRequestHandler{Execute}" />
        public class Management : IRequestHandler<Execute>
        {
            /// <summary>
            /// The context
            /// </summary>
            private readonly DbContextAuthor _context;

            /// <summary>
            /// Initializes a new instance of the <see cref="Management"/> class.
            /// </summary>
            /// <param name="context">The context.</param>
            public Management(DbContextAuthor context)
            {
                _context = context;
            }

            /// <summary>
            /// Handles the specified request.
            /// </summary>
            /// <param name="request">The request.</param>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns></returns>
            /// <exception cref="Exception">Error al momento de ingresar un autor</exception>
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var author = new BookAuthor
                {
                    Name = request.Name,
                    LastName = request.Lastname,
                    Birthdate = request.Birthdate,
                    BookAuthorGuid = Guid.NewGuid().ToString()
                };
                _context.BookAuthor.Add(author);
                var succed = await _context.SaveChangesAsync();
                if (succed > 0)
                    return Unit.Value;
                throw new Exception("Error al momento de ingresar un autor");
            }
        }
    }
}
