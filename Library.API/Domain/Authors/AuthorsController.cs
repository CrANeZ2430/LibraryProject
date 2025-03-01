using Library.API.Common;
using Library.API.Domain.Authors.Records;
using Library.Application.Domain.Authors.Commands.CreateAuthor;
using Library.Application.Domain.Authors.Commands.UpdateAuthor;
using Library.Application.Domain.Authors.Commands.DeleteAuthor;
using Library.Application.Domain.Authors.Queries.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.API.Domain.Authors;

[Route(Routes.Authors)]
[ApiController]
public class AuthorsController(
    IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAuthors(
        [FromQuery][Required] int page = 1,
        [FromQuery][Required] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAuthorsQuery(page, pageSize);
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor(
        [FromBody][Required] CreateAuthorRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateAuthorCommand(
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.Phone);

        var id = await mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAuthor(
        [FromBody][Required] UpdateAuthorRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateAuthorCommand(
            request.AuthorId,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.Phone);

        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAuthor(
        [FromQuery][Required] Guid AuthorId,
        CancellationToken cancellationToken)
    {
        var command = new DeleteAuthorCommand(AuthorId);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }
}
