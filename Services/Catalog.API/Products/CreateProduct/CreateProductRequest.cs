namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest(
    string Name,
    string Description,
    List<string> Categories,
    string ImageFile,
    decimal Price
);