using Tariff.Comparison.Api.Controllers;
using Tariff.Comparison.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddResolvers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/register", RegisterProductTariffController.RegisterProductAsync);
app.MapPost("/register/batch", RegisterProductTariffController.RegisterProductBatchAsync);

app.MapGet("/products", FindProductsController.FindProducatsAsync);

app.UseHttpsRedirection();

app.Run();
