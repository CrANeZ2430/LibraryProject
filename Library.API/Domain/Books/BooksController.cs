using Library.API.Common;
using Library.API.Domain.Books.Records;
using Library.Application.Domain.Books.Commands.AssignAuthors;
using Library.Application.Domain.Books.Commands.CreateBook;
using Library.Application.Domain.Books.Commands.DeleteBook;
using Library.Application.Domain.Books.Commands.RemoveAuthors;
using Library.Application.Domain.Books.Commands.UpdateBook;
using Library.Application.Domain.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.API.Domain.Books;

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
        [FromBody][Required] CreateBookRequest request,
        [FromQuery][Required] Guid[] authorsId,
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

    [HttpPut]
    public async Task<IActionResult> UpdateBook(
        [FromBody][Required] UpdateBookRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateBookCommand(
            request.BookId,
            request.Title,
            request.Description);

        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBook(
        [FromQuery][Required] Guid BookId,
        CancellationToken cancellationToken)
    {
        var command = new DeleteBookCommand(BookId);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPut("assign-authors")]
    public async Task<IActionResult> AssignAuthors(
        [FromBody][Required] AssignAuthorsRequest request,
        CancellationToken cancellationToken)
    {
        var command = new AssignAuthorsCommand(
            request.BookId,
            request.AuthorIds);

        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPut("remove-authors")]
    public async Task<IActionResult> RemoveAuthors(
        [FromBody][Required] RemoveAuthorsRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RemoveAuthorsCommand(
            request.BookId,
            request.AuthorIds);

        await mediator.Send(command, cancellationToken);
        return Ok();
    }
}
