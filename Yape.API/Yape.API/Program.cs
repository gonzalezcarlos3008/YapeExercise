using Yape.API.Application.Handlers;
using Yape.API.Domain.Interfaces;
using Yape.API.Infrastructure.Adapters;
using Yape.API.Infrastructure.Persistence;
using Yape.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Yape.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Database configuration
var connectionString = builder.Configuration.GetConnectionString("DB_CONNECTION_STRING");
builder.Services.AddDbContext<YapeDbContext>(options =>
    options.UseSqlServer(connectionString));


// Dependency Injection
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IValidationService, PersonServiceAdapter>();
builder.Services.AddScoped<CreateCustomerHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
