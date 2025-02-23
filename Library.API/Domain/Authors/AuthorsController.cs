using Library.API.Common;
using Library.API.Domain.Authors.Records;
using Library.Application.Domain.Authors.Commands.CreateAuthor;
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
            request.Email);

        var id = await mediator.Send(command, cancellationToken);
        return Ok(id);
    }
}
