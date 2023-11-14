using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpressAPI.Data;
using SimpressAPI.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SimpressAPI.Converter;
using SimpressAPI.Services;
using SimpressAPI.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddValidatorsFromAssemblyContaining<ProdutoValidator>();
//IServiceCollection serviceCollection = builder.Services.AddTransient<IValidator<ProdutoDto>, ProdutoValidator>();

builder.Services.AddControllers();
builder.Services.AddSingleton<ProductConverter>();
builder.Services.AddScoped<ProdutoService>();


// Configuração do serviço do banco de dados
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




//using var context = new DbContext(contextOptions);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
