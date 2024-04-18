using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
    Guid Id,
    string Name,
    string Description,
    List<string> Category,
    string ImageFile,
    decimal Price
) : IRequest<CreateProductResult>;