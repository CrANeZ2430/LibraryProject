﻿using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Books.Data;

public record AssignAuthorsData(
    IEnumerable<Author> AuthorsToAssign,
    IEnumerable<BookAuthor> BookAuthors,
    int Quantity);
