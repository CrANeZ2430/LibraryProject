namespace Library.Core.Exceptions;

public class BadRequestException(string message) : DomainException(message);
