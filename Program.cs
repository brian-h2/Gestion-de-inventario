using ApiMinimal.Context;
using ApiMinimal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;

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

app.MapGet("/tasksAll", async (ApiMinimalContext apidb) =>
{
    var items = await apidb.Tasks.ToListAsync();
    return Results.Ok(items);
});

app.MapGet("/getTask/{name}", async (string name, ApiMinimalContext apidb) =>
{
    var itemsResult = await apidb.Tasks.FirstOrDefaultAsync(x => x.TaskName == name);
    return Results.Ok(itemsResult);
});

app.MapPost("/createTask", async (Tasks task, ApiMinimalContext apidb) =>
{
    apidb.Tasks.Add(task);
    await apidb.SaveChangesAsync();
    return Results.Created("Tarea creada correctamente", task);

});

app.MapPatch("/modifiedTask/{name}", async (Tasks tasks,string name, ApiMinimalContext apidb) =>
{
    var itemsResult = await apidb.Tasks.FirstOrDefaultAsync(x => x.TaskName == name);
    if(itemsResult != null)
    {
        itemsResult.IdTask = tasks.IdTask;
        itemsResult.TaskName = tasks.TaskName;
        itemsResult.PriorityTask = tasks.PriorityTask;
        apidb.Tasks.Add(itemsResult);
        await apidb.SaveChangesAsync();
    }
    return Results.Ok("Tarea modificada correctamente" + itemsResult);
});

app.MapDelete("/deleteTask/{name}", async (string name, ApiMinimalContext apidb) =>
{
    var itemResult = await apidb.Tasks.FirstOrDefaultAsync(x => x.TaskName == name);
    if (itemResult != null) 
    {
        apidb.Remove(itemResult);
        await apidb.SaveChangesAsync();
    }
    return Results.Ok("Tarea eliminada correctamente " + itemResult.TaskName);
});

app.Run();
