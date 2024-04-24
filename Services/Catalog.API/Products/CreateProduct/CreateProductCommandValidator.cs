namespace Catalog.API.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name is required")
            .Length(2, 74).WithMessage("The name must be between 2 and 75 characters in length");
        RuleFor(x => x.Categories).NotEmpty().WithMessage("Specify at least one category");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("The image file is required");
        RuleFor(x => x.Price).NotEmpty().WithMessage("The price is required")
            .GreaterThan(0).WithMessage("The price must be above 0");
    }
}