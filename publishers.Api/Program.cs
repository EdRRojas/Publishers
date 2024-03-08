using Microsoft.EntityFrameworkCore;
using publishers.Infrastructure.Context;
using publishers.Infrastructure.Interface;
using publishers.Infrastructure.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Connection String 
builder.Services.AddDbContext<PubsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));

//Repositories

builder.Services.AddScoped<IDiscountsRepository, DiscountsRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();