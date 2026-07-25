using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "Employee Web API using Swagger",

        Contact = new OpenApiContact
        {
            Name = "John Doe",
            Email = "john@example.com",
            Url = new Uri("https://example.com")
        },

        License = new OpenApiLicense
        {
            Name = "License Terms",
            Url = new Uri("https://example.com/license")
        }
    });
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        "Swagger Demo v1"
    );
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();