using Microsoft.EntityFrameworkCore;
using ParkingControl.Application.Contracts;
using ParkingControl.Application.Services;
using ParkingControl.Data.DataContext;
using ParkingControl.Data.Repositories;
using ParkingControl.Domain.Calcs;
using ParkingControl.Domain.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(op => 
        op.UseSqlServer(builder.Configuration.GetConnectionString("PCConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile) ;
    options.IncludeXmlComments(xmlPath);
});
builder.Services.AddCors(options => options.AddPolicy(name: "ParkingControlOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }
    ));

builder.Services.AddScoped<IParkingSpotRepository, ParkingSpotRepository>();
builder.Services.AddScoped<IParkingSpotService, ParkingSpotService>();
builder.Services.AddScoped<IParkingFeeRepository, ParkingFeeRepository>();
builder.Services.AddScoped<IParkingFeeService, ParkingFeeService>();
builder.Services.AddScoped<IParkingFeeCalculations, ParkingFeeCalculations>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseCors("ParkingControlOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
