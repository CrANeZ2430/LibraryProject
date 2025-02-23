using Library.Application.Common;
using MediatR;

namespace Library.Application.Domain.Books.Queries.GetBooks;

public record GetBooksQuery(
    int Page, 
    int PageSize) 
    : IRequest<PageResponse<BookDto[]>>;
