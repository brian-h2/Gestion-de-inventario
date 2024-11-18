using ApiMinimal.Context;
using ApiMinimal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApiMinimalContext>(opt => opt.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<ApiMinimalContext>(builder.Configuration.GetConnectionString("cnTasks")); //Obtenemos la string de conexion colocada en appsettings.json

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//FromServices: Recibimos el contexto de EF, posterior colocamos el nombre del context y despues el nombre a la variable que va a recibir este contexto. 

app.MapGet("/dbconexion", async ([FromServices] ApiMinimalContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory" + dbContext.Database.IsInMemory());
});

app.MapGet("/itemsAll", async (ApiMinimalContext apidb) =>
{
    var items = await apidb.Tasks.ToListAsync();
    return Results.Ok(items);
});

app.MapPost("/createTask", async (Tasks task, ApiMinimalContext dbcontext) =>
{
    dbcontext.Tasks.Add(task);
    await dbcontext.SaveChangesAsync();
    return Results.Created($"/tasks/{task.IdTask}", task);

});

app.MapGet("/{name}", async (string name, ApiMinimalContext apidb) =>
{
    var itemsResult = await apidb.Tasks.FirstOrDefaultAsync(x => x.TaskName == name);
    return Results.Ok(itemsResult);
});



app.Run();
