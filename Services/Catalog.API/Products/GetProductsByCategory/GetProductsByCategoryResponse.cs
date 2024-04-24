namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryResponse(IReadOnlyList<Product> Products);