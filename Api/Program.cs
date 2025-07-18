using DataAccess;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ServiceFreight.BusinessLogic.Extensions;
using ServiceFreight.DataAccess.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddBusinessLogicDependencies(builder.Configuration, builder.Environment);

builder.Services.AddDataAccessDependencies(builder.Configuration, builder.Environment);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
            builder => builder.WithOrigins("http://localhost:4200", "http://localhost:83", "http://localhost:84", "http://192.168.29.100:83")
                .AllowAnyMethod()
                .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
