using BLL.Concrete;
using BLL.Abstract;
using DAL.Concrete;
using API;
using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
string TMDBApiKey = builder.Configuration.GetSection("ApiKeys:TMDB").Value ?? "";
var contextOptions = new DbContextOptionsBuilder<DataContext>()
    .UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"))
    .Options;


builder.Services.AddSingleton<IApiManager>(x => new ApiManager(new ApiService(TMDBApiKey), new MovieDAL(new DataContext(contextOptions))));


// worker service
builder.Services.AddHostedService<Worker>();

// database configuration
builder.Services.DALDependencies(builder.Configuration);


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
