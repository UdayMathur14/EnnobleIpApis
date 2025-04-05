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
            builder => builder.WithOrigins("http://10.101.0.225:3252", "http://localhost:4200", "http://111.93.61.251:9091", "http://111.93.61.253:9091", "http://10.101.0.225:9091", "http://10.101.0.227:9091")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
