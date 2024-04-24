namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryResult(IReadOnlyList<Product> Products);