namespace Catalog.API.Products.GetProducts;

public record GetProductsResponse(
    IEnumerable<Product> Products
);