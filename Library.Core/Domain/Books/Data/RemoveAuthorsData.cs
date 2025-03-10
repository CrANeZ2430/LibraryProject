﻿using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Books.Data;

public record RemoveAuthorsData(
    IEnumerable<Author> AuthorsToRemove,
    IEnumerable<BookAuthor> BookAuthors,
    int Quantity);
