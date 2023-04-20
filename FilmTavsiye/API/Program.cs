using BLL.Concrete;
using BLL.Abstract;
using DAL.Concrete;
using API;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CORE;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://www.mikro.com.tr",
        ValidAudience = "MyAudienceValue",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySigningKeyForSha256Security"))
    };
});


// database configuration
builder.Services.DALDependencies(builder.Configuration);

// Dependency Injection
string TMDBApiKey = builder.Configuration.GetSection("ApiKeys:TMDB").Value ?? "";
var contextOptions = new DbContextOptionsBuilder<DataContext>()
    .UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"))
    .Options;

HostMail hostMail = new HostMail
{
    Port = Convert.ToInt16(builder.Configuration.GetSection("HostMail:Port").Value),
    SenderMail = builder.Configuration.GetSection("HostMail:SenderMail").Value ?? "",
    SenderPassword = builder.Configuration.GetSection("HostMail:SenderPassword").Value ?? "",
    HostMailServer = builder.Configuration.GetSection("HostMail:HostMailServer").Value ?? ""
};

builder.Services.AddSingleton<IApiManager>(x => new ApiManager(new ApiService(TMDBApiKey), new MovieDAL(new DataContext(contextOptions))));
builder.Services.AddSingleton<IMovieManager>(x=> new MovieManager(new MovieDAL(new DataContext(contextOptions))));
builder.Services.AddSingleton<IMailManager>(x => new MailManager(new MovieDAL(new DataContext(contextOptions)), hostMail));

// worker service
builder.Services.AddHostedService<Worker>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
