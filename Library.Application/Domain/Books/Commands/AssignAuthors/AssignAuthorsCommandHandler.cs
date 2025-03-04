﻿using Library.Core.Common.DbContext;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Data;
using MediatR;

namespace Library.Application.Domain.Books.Commands.AssignAuthors;

public class AssignAuthorsCommandHandler(
    IUnitOfWork unitOfWork,
    IBooksRepository booksRepository,
    IAuthorsRepository authorsRepository) 
    : IRequestHandler<AssignAuthorsCommand>
{
    public async Task Handle(
        AssignAuthorsCommand request, 
        CancellationToken cancellationToken)
    {
        var book = await booksRepository.GetById(
            request.BookId, 
            cancellationToken);

        var authors = await authorsRepository.GetByIds(request.AuthorIds, cancellationToken);
        var data = new AssignAuthorsData(
            authors,
            book.Authors,
            authors.Count());

        await book.AssignAuthors(data);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
