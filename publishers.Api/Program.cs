using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using publishers.Infrastructure.Contex;
using publishers.Infrastructure.Interfaces;
using publishers.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//cnn string
builder.Services.AddDbContext<PubsContex>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContex")));

//repositories
builder.Services.AddScoped<IRoyschedRepository, RoyschedRepository>();

//App Service

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
