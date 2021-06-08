using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Aplication;
using TiendaServicios.Api.Autor.Dto;
using TiendaServicios.Api.Autor.Model;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<ICollection<BookAuthorDto>> Get()
        {
            return await _mediator.Send(new Query.ListAuthor());
        }

        [HttpGet("{id}")]
        public async Task<BookAuthorDto> GetOne([FromRoute]string  id)
        {
            return await _mediator.Send(new QueryFilter.UniqueAuthor() { AuthorGuid = id });
        }
    }
}
