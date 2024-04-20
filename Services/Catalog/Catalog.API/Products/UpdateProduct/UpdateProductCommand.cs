namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    List<string> Categories,
    string ImageFile,
    decimal Price
) : ICommand<UpdateProductResult>;