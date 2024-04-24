namespace Catalog.API.Products.CreateProduct;

public record CreateProductResponse(
    Guid Id,
    string Name,
    string Description,
    List<string> Categories,
    string ImageFile,
    decimal Price
);