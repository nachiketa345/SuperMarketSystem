using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Plugin.DataInMemory;
using Plugins.DataStorage.SQL;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.PluginInterfaces;
using UseCases.ProductsUseCase;
using UseCases.UseCaseInterfaces;
using WebApp.Data;
using Microsoft.Extensions.Configuration;
using WebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method

startup.Configure(app, builder.Environment); // calling Configure method