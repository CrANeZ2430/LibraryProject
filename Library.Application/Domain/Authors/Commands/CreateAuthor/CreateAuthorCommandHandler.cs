using MediatR;

namespace Library.Application.Domain.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
{
    public Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
