using Marten.Pagination;

namespace Catalog.API.Products.GetProducts;

internal class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var pageNumber = query.PageNumber ?? 1;
        var pageSize = query.PageSize ?? 10;
        var products = await session.Query<Product>()
            .ToPagedListAsync(pageNumber, pageSize, cancellationToken);

        return new GetProductsResult(products);
    }
}