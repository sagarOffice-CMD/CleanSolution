using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ApiApplication.Controllers;
using Application;
using Application.Validator;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//DBContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.
        Configuration.GetConnectionString("DefaultConnection"),
        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


//DI
builder.Services
    .AddScoped<IApplicationDbContext>(
    provider => provider.GetRequiredService<ApplicationDbContext>()
    );

//Mediatr
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});



// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



//FluentValidator
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
       
builder.Services.AddScoped<IValidator<Student>, StudentValidator>();


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
