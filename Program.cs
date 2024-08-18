using ActivityStudents.Repositories;
using ActivityStudents.Entities;
using ActivityStudents.Models;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("db");
builder.Services.AddSingleton(new Database(connection!));
builder.Services.AddScoped<ActivityRepository>();
builder.Services.AddSwaggerGen();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

//?classId=A&name=Arthur%20Teodoro
//?name=Arthur%20Teodoro
//?classId=A
app.MapGet("/", (ActivityRepository repo, string? name, string? classId) =>
{
    try
    {
        IEnumerable<ActivityEntity> activities;

        // Se ambos os parâmetros forem fornecidos, filtre por ambos
        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(classId))
        {
            activities = repo.GetByNameAndClass(name, classId);
        }
        // Se apenas o nome for fornecido, filtre por nome
        else if (!string.IsNullOrEmpty(name))
        {
            activities = repo.GetByName(name);
        }
        // Se apenas o classId for fornecido, filtre por classId
        else if (!string.IsNullOrEmpty(classId))
        {
            activities = repo.GetByClass(classId);
        }
        // Se nenhum filtro for fornecido, retorne todas as atividades
        else
        {
            activities = repo.GetAll();
        }

        var grouped = activities.GroupBy(g => g.ClassIdentify, (key, g) => new
        {
            @class = key,
            students = g.Select(s => new Student(s)).ToList()
        });

        return grouped.Any() ? Results.Ok(grouped) : Results.NotFound("Nenhuma atividade encontrada.");
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});



app.Run();
