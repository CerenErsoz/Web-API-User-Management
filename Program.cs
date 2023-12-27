using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebApi.Middlewares;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDBContext>(options => options.UseInMemoryDatabase(databaseName: "UserDB"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();


//veritabanını başlat
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Global loglama middleware'i.
app.UseMiddleware<CustomExceptionMiddleware>();


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