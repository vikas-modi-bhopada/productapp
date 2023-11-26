using UserAPI.Context;
using UserAPI.Repository;
using UserAPI.Service;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenGenerator,TokenGenerator>();
string? connectionSQL = builder.Configuration.GetConnectionString("localSQLConnection");
builder.Services.AddDbContext<UserDbContext>(options=>options.UseSqlServer(connectionSQL));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

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



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
