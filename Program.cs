using M12_NotaseF;
using Microsoft.EntityFrameworkCore;

using NotasDbContext db = new NotasDbContext();
Console.WriteLine("Conectado a notas.dv");

if (!db.Estudiantes.Any())
{
    db.Estudiantes.Add(new Estudiante { Nombre = "Jonny", Nota = 7, Ciudad = "Guayaquil"});
    db.Estudiantes.Add(new Estudiante { Nombre = "Pedro", Nota = 9, Ciudad = "Guayaquil"});
    db.Estudiantes.Add(new Estudiante { Nombre = "Alex", Nota = 8, Ciudad = "Quito"});
    db.Estudiantes.Add(new Estudiante { Nombre = "Luisa", Nota = 10, Ciudad = "Guayaquil"});

    int filas = db.SaveChanges();
    Console.WriteLine($"Filas insertadas: {filas}");
}

List<Estudiante> todos = db.Estudiantes.ToList();
Console.WriteLine($"Estudiantes en la base de datos: {todos.Count()}");

foreach (var estudiante in todos)
{
    Console.WriteLine($" {estudiante.Id}, {estudiante.Nombre}, {estudiante.Nota}, {estudiante.Ciudad}");
}

List<String> aprobados = db.Estudiantes
    .Where(e => e.Nota > 7)
    .OrderByDescending( e => e.Nota)
    .Select( e => e.Nombre)
    .ToList();

Console.WriteLine($"Aprobados: {string.Join(",", aprobados)}");

int dbQuito = db.Estudiantes.Count( e => e.Ciudad == "Quito");

Console.WriteLine($"De Quito: {dbQuito}");

IQueryable<Estudiante> consulta = db.Estudiantes.Where( e => e.Nota > 7);
Console.WriteLine("Swql: ");
Console.WriteLine(consulta.ToQueryString());
