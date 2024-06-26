namespace Catalog.API.Setup;

public static class MediatRConfiguration
{
    public static WebApplicationBuilder AddMediatRConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(Program).Assembly);
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        return builder;
    }
}