using Microsoft.EntityFrameworkCore;
using TA35_01.Models;

var builder = WebApplication.CreateBuilder(args);

//Configuramos la conexion Base Datos SQL
string connection = "server=localhost;user=root;password=root;database=PieProv";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<pieprosumContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connection, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

// Add services to the container.
builder.Services.AddControllers();

//Registro Swagger Generator
builder.Services.AddSwaggerGen();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddDbContext<pieprosumContext>(opt =>
//    opt.UseInMemoryDatabase("pieprosumList"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json","My API V1");
    });
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
