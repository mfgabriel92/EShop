var builder = WebApplication.CreateBuilder(args);

builder.AddMediatRConfiguration();
builder.AddMartenConfiguration();
builder.AddRepositoryConfiguration();
builder.Services.AddCarter();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddExceptionHandler<ApiExceptionHandler>();

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(options => { });
app.Run();