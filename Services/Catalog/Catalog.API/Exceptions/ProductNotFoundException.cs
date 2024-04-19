namespace Catalog.API.Exceptions;

public class ProductNotFoundException(Guid id) : Exception($"Product id '{id}' not found");