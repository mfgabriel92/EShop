using FluentValidation;

namespace Catalog.API.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("The name is required");
        RuleFor(x => x.Categories).NotEmpty().WithMessage("Specify at least one category");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("The image file is required");
        RuleFor(x => x.Price).NotEmpty().WithMessage("The price is required")
                            .GreaterThan(0).WithMessage("The price must be above 0");
    }
}
