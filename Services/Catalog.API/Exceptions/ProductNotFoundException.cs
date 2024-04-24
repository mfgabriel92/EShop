using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions;

public class ProductNotFoundException(Guid id) : NotFoundException($"Product id '{id}' not found");