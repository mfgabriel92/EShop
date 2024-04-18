namespace Catalog.API.Products.CreateProduct;

public abstract record CreateProductRequest(
    string Name,
    string Description,
    List<string> Category,
    string ImageFile,
    decimal Price
);