using BusTracking.Application.Interfaces;
using BusTracking.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using BusTracking.Infrastructure.DATA; // Adjust the namespace as needed

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Configure DbContext with SQL Server
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("bustracking")));
var connectionString = builder.Configuration.GetConnectionString("bustracking");
Console.WriteLine($"Connection String: {connectionString}");
// Add services to the container.




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(b =>
{
    b
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();


app.Run();

