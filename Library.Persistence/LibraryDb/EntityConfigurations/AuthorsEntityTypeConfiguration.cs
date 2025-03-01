using Library.Core.Domain.Authors.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.LibraryDb.EntityConfigurations;

internal class AuthorsEntityTypeConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasMaxLength(50);

        builder.Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Phone)
            .HasMaxLength(20)
            .IsRequired();

        builder.Metadata
            .FindNavigation(nameof(Author.Books))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(x => x.Books)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId);
    }
}
