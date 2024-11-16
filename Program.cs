using ApiMinimal.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiMinimalContext>(opt => opt.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//FromServices: Recibimos el contexto de EF, posterior colocamos el nombre del context y despues el nombre a la variable que va a recibir este contexto. 

app.MapGet("/dbconexion", async ([FromServices] ApiMinimalContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory" + dbContext.Database.IsInMemory());
});

app.Run();
