namespace Basket.API.Setup;

public static class MartenConfiguration
{
    public static WebApplicationBuilder AddMartenConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddMarten(opts =>
            {
                opts.Connection(builder.Configuration.GetConnectionString("Database")!);
                opts.Schema.For<ShoppingCart>().Identity(x => x.Username);
            })
            .UseLightweightSessions();

        return builder;
    }
}