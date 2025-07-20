using System.Reflection;
using CreditApplication.API.Middlewares;
using CreditApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Db connection
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

//Global Exception Errors I
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

//MediatR
var assemblies = Assembly.Load("CreditApplication.Application");

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(assemblies);
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

//Global Exception Errors II
app.UseExceptionHandler();
app.UseStatusCodePages();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
