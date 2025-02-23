using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.LibraryDb;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
    public static string LibraryDbSchema = "library";
    public static string LibraryMigrationHistory = "__LibraryMigrationHistory";

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(LibraryDbSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
    }
}
