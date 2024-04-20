namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductResult(
    Guid Id,
    string Name,
    string Description,
    List<string> Categories,
    string ImageFile,
    decimal Price
);