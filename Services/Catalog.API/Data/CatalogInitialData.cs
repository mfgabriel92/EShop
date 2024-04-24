using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        await using var session = store.LightweightSession();
        var hasProduct = await session.Query<Product>().AnyAsync(cancellation);

        if (hasProduct)
        {
            return;
        }

        session.Store(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        return new[]
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Dell Inspiron 7472",
                Description = "Dell Inspiron 7472 laptop, 16GB RAM, 128GB SSD, Intel i7 8th Gen.",
                Categories = ["technology", "computers", "notebooks"],
                ImageFile = "dell-inspiron-7472.png",
                Price = 899.00M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy A52 5G",
                Description = "Samsung Galaxy A52 5G 6GB RAM",
                Categories = ["technology", "smartphones", "samsung"],
                ImageFile = "samsung-galaxy-a52-5g.png",
                Price = 375.00M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Gucci White T-shirt",
                Description = "Gucci white, short-sleeves T-shirt",
                Categories = ["clothing", "t-shirts"],
                ImageFile = "gucci-white-shirt.png",
                Price = 255.75M
            }
        };
    }
}