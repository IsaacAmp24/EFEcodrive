using Microsoft.EntityFrameworkCore;
using EFEcodrive.Shared.Domain.Repositories;
using EFEcodrive.Shared.Persistence.Contexts;
using EFEcodrive.Shared.Persistence.Repositories;
using EFEcodrive.loyalty.Domain.Repositories;
using EFEcodrive.loyalty.Domain.Services;
using EFEcodrive.loyalty.Persistence.Repositories;
using EFEcodrive.loyalty.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

// Student
builder.Services.AddScoped<IRewardsRepository,RewardsRepository>();
builder.Services.AddScoped<IRewardsService, RewardsService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(EFEcodrive.loyalty.Mapping.ModelToResourceProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

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