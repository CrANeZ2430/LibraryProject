using Library.Application.Common;
using Library.Application.Domain.Authors.Queries.GetAuthors;
using Library.Persistence.LibraryDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Authors.Queries.GetAuthors;

public class GetAuthorsQueryHandler(
    LibraryDbContext dbContext)
    : IRequestHandler<GetAuthorsQuery, PageResponse<AuthorDto[]>>
{
    public async Task<PageResponse<AuthorDto[]>> Handle(
        GetAuthorsQuery request, 
        CancellationToken cancellationToken)
    {
        var sqlQuery = dbContext
            .Authors
            .AsNoTracking()
            .Include(x => x.Books);

        var skip = request.PageSize * (request.Page - 1);

        var count = sqlQuery.Count();

        var authors = await sqlQuery
            .OrderBy(a => a.FirstName)
            .Skip(skip)
            .Take(request.PageSize)
            .Select(x => new AuthorDto(
                x.Id,
                x.FirstName,
                x.LastName,
                x.Email,
                x.Books.Select(o => new BookDto(o.Book.Title, o.Book.Description)).ToArray()
                ))
            .ToArrayAsync(cancellationToken);

        return new PageResponse<AuthorDto[]>(count, authors);
    }
}
