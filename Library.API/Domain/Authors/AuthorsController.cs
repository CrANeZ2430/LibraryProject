using Library.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Domain.Authors;

[Route(Routes.Authors)]
[ApiController]
public class AuthorsController(
    IMediator mediator) : ControllerBase
{

}
