namespace Catalog.API.Products.CreateProduct;

public record CreateProductResult(
    Guid Id,
    string Name,
    string Description,
    List<string> Categories,
    string ImageFile,
    decimal Price
);