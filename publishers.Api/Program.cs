using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using publishers.Application.Contract;
using publishers.Application.Exceptions;
using publishers.Application.Service;
using publishers.Domain.Entities;
using publishers.Infrastructure.Context;
using publishers.Ioc.TitlesDependency;
using publishers.Infrastructure.Interfaces;
using publishers.Infrastructure.Repositories;
using System;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Connection String 
builder.Services.AddDbContext<PubsContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));

//Titles Dependencies
builder.Services.AddTitlesDependency();

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
