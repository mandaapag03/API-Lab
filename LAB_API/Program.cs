using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "LAB API",
        Description = "Uma aplicação ASP.NET Core Web API para sistema de reserva de laboratórios.",
        Contact = new OpenApiContact
        {
            Name = "Repositório no GitHub do projeto",
            Url = new Uri("https://github.com/mandaapag03/API-Lab")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(policy =>
    policy.AddDefaultPolicy(p =>
        p.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();