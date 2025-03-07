﻿namespace Library.API.Domain.Authors.Records;

public record UpdateAuthorRequest(
    Guid AuthorId,
    string FirstName,
    string LastName,
    string MiddleName,
    string Email,
    string Phone);
