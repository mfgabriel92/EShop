namespace Catalog.API.Setup;

public static class MartenConfiguration
{
    public static WebApplicationBuilder AddMartenConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddMarten(opts =>
            {
                opts.Connection(builder.Configuration.GetConnectionString("Database")!);
            })
            .UseLightweightSessions();

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.InitializeMartenWith<CatalogInitialData>();
        }

        return builder;
    }
}