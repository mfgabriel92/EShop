using BuildingBlocks.Behavior;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services
    .AddMarten(opts => { opts.Connection(builder.Configuration.GetConnectionString("Database")!); })
    .UseLightweightSessions();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(handler =>
{
    handler.Run(async ctx =>
    {
        var ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (ex is null) return;

        var problemDetails = new ProblemDetails
        {
            Description = ex.Message,
            StatusCode = StatusCodes.Status500InternalServerError
        };

        ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
        ctx.Response.ContentType = "application/problem+json";

        await ctx.Response.WriteAsJsonAsync(problemDetails);
    });
});
app.Run();