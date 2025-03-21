using Library.Core.Domain.Books.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.LibraryDb.EntityConfigurations;

internal class BookAuthorEntityTypeConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasKey(x => new { x.BookId, x.AuthorId });
    }
}
