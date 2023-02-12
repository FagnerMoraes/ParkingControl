using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ParkingControl.Application.Contexts.ParkingSpots.Contracts;
using ParkingControl.Application.Contexts.ParkingSpots.DTOs.Request;
using ParkingControl.Application.Contexts.ParkingSpots.Services;
using ParkingControl.Data.Contexts.ParkingSpots.Repositories;
using ParkingControl.Data.DataContext;
using ParkingControl.Domain.Contexts.PargingSpots.Repositories;
using ParkingControl.Domain.Contexts.ParkingSpots.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddDbContext<AppDbContext>(op => 
        op.UseSqlite(builder.Configuration.GetConnectionString("PCConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IParkingSpotRepository, ParkingSpotRepository>();
builder.Services.AddScoped<IParkingSpotService, ParkingSpotService>();


builder.Services.AddTransient<IValidator<CreateParkingSpotRequest>, ParkingSpotValidation>();

var app = builder.Build();

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
