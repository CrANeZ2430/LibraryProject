using Library.API.Common;
using Library.API.Domain.Books.Records;
using Library.Application.Domain.Books.Commands.AssignAuthors;
using Library.Application.Domain.Books.Commands.CreateBook;
using Library.Application.Domain.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.API.Domain.Books
{
    [Route(Routes.Books)]
    [ApiController]
    public class BooksController(
    IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBooks(
            [FromQuery][Required] int page = 1,
            [FromQuery][Required] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var query = new GetBooksQuery(page, pageSize);
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(
            [FromBody] [Required] CreateBookRequest request,
            [FromQuery] [Required] Guid authorsId,
            CancellationToken cancellationToken)
        {
            var command = new CreateBookCommand(
                request.Title,
                request.Description);

            var id = await mediator.Send(command, cancellationToken);
            var assignAuthorCommand = new AssignAuthorsCommand(id, authorsId);
            await mediator.Send(assignAuthorCommand, cancellationToken);
            return Ok(id);
        }
    }
}
