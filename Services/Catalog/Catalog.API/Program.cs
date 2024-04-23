using Catalog.API.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.ConfigureMediatR();
builder.ConfigureMarten();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddExceptionHandler<ApiExceptionHandler>();

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(options => { });
app.Run();