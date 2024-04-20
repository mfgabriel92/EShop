namespace Catalog.API.Products.CreateProduct;

internal class CreateProductCommandHandler(IDocumentSession session, IValidator<CreateProductCommand> validator)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validation = await validator.ValidateAsync(command, cancellationToken);
        var errors = validation.Errors.Select(x => x.ErrorMessage).ToList();

        if (errors.Count > 0)
        {
            throw new ValidationException(errors.FirstOrDefault());
        }

        var product = new Product
        {
            Name = command.Name,
            Description = command.Description,
            Categories = command.Categories,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(
            product.Id,
            product.Name,
            product.Description,
            product.Categories,
            product.ImageFile,
            product.Price
        );
    }
}