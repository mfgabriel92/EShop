namespace Catalog.API.Products.GetProductsByCategory;

public class GetProductsByCategoryQueryHandler(IQuerySession session)
    : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query,
                                                          CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(p => p.Categories.Contains(query.Category))
            .ToListAsync(cancellationToken);

        return new GetProductsByCategoryResult(products);
    }
}