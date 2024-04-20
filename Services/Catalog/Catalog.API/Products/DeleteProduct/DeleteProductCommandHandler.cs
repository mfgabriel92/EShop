﻿namespace Catalog.API.Products.DeleteProduct;

internal class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(command.Id);
        }

        session.Delete<Product>(product.Id);
        await session.SaveChangesAsync(cancellationToken);
        return new DeleteProductResult();
    }
}
