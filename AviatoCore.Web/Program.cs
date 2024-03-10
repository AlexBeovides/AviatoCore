using AviatoCore.Infrastructure;
using AviatoCore.Application.Interfaces;
using AviatoCore.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AviatoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS services.
builder.Services.AddCors(options => {
    options.AddPolicy("AllowMyClient",
        builder => builder.WithOrigins("http://localhost:5173") // replace with your React app's address
                           .AllowAnyMethod()
                           .AllowAnyHeader());
});

builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS middleware here.
app.UseCors("AllowMyClient");

app.UseAuthorization();

app.MapControllers();

app.Run();