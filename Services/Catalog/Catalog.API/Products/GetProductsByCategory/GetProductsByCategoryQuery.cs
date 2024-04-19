namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;