using Library.Application.Common;
using Library.Application.Domain.Books.Queries.GetBooks;
using Library.Persistence.LibraryDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Books.Queries.GetBooks;

public class GetBooksQueryHandler(
    LibraryDbContext dbContext) 
    : IRequestHandler<GetBooksQuery, PageResponse<BookDto[]>>
{
    public async Task<PageResponse<BookDto[]>> Handle(
        GetBooksQuery query, 
        CancellationToken cancellationToken)
    {
        var sqlQuery = dbContext
            .Books
            .AsNoTracking()
            .Include(x => x.Authors);

        var skip = query.PageSize * (query.Page - 1);

        var count = sqlQuery.Count();

        var books = await sqlQuery
            .OrderBy(a => a.Title)
            .Skip(skip)
            .Take(query.PageSize)
            .Select(x => new BookDto(
                x.Id,
                x.Title,
                x.Description,
                x.Authors.Select(o => new AuthorDto(o.Author.FirstName, o.Author.LastName)).ToArray()
                ))
            .ToArrayAsync(cancellationToken);

        return new PageResponse<BookDto[]>(count, books);
    }
}
