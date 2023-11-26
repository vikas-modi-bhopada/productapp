using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductAPI.Context;
using ProductAPI.Repository;
using ProductAPI.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string? connectionSQL = builder.Configuration.GetConnectionString("localSQLConnection");
builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(connectionSQL));

ValidateTokenWithParameters(builder.Services, builder.Configuration);
void ValidateTokenWithParameters(IServiceCollection services, ConfigurationManager configuration)
{
    var userSecretKey = configuration["JwtValidationDetails:UserApplicationSecretKey"];
    var userIssuer = configuration["JwtValidationDetails:UserIssuer"];
    var userAudience = configuration["JwtValidationDetails:UserAudience"];
    var userSecurityKey = Encoding.UTF8.GetBytes(userSecretKey);
    var userSymmetricSecurity = new SymmetricSecurityKey(userSecurityKey);
    var tokenValidationParameters = new TokenValidationParameters()
    {

        ValidateIssuer = true,
        ValidIssuer = userIssuer,

        ValidateAudience = true,
        ValidAudience = userAudience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = userSymmetricSecurity,

        ValidateLifetime = true
    };
    services.AddAuthentication(u =>
    {
        u.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        u.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(u => u.TokenValidationParameters = tokenValidationParameters);
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

    app.UseHttpsRedirection();
    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
