using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Students.Business.Business;
using Students.Business.Contract;
using Student.Repository.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Student.Repository.Common;
using AutoMapper;
using Student.Entity;
using Student.ViewModel;
using Microsoft.OpenApi.Models;
using System;
using Students.Entity.Model;
using Student.Repository.Repository;
using AutoMapper.Extensions.ExpressionMapping;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Configuration
builder.Services.AddDbContext<StudentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbConnectionString"));
});
builder.Services.AddAutoMapper(c =>
{
    c.AddExpressionMapping();
}, typeof(AutoMapperProfile).Assembly);

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentBusiness, StudentBusiness>();
builder.Services.AddScoped<DbContext, StudentContext>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// Configure the HTTP request pipeline.
// Dependency Injection


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
