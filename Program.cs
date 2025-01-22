using Microsoft.EntityFrameworkCore;

namespace AzureASPApi;

/*
Project: 
Web app for organizing and discovering local community events.
Returns only events in the area from user entering city name only (easier to remember).

Security features: wont store zip code or any user info in database. They only enter zip and only searches events.

 */
public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Dependency Injection
		builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

		var app = builder.Build();


		// Get requests
		app.MapGet("/todoitems", async (TodoDb db) => 
			await db.Todos.ToListAsync());

		app.MapGet("/todoitems/complete", async (TodoDb db) =>
			await db.Todos.Where(t => t.IsComplete).ToListAsync());

		// Post request
		app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
		{
			db.Todos.Add(todo);
			await db.SaveChangesAsync();

			return Results.Created($"/todoitems/{todo.Id}", todo);
		});

		// Put request
		app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
		{
			var todo = await db.Todos.FindAsync(id);

			if (todo is null) return Results.NotFound();

			todo.Name = inputTodo.Name;
			todo.IsComplete = inputTodo.IsComplete;

			await db.SaveChangesAsync();

			return Results.NoContent();
		});

		// Delete Request
		app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
		{
			if (await db.Todos.FindAsync(id) is Todo todo)
			{
				db.Todos.Remove(todo);
				await db.SaveChangesAsync();
				return Results.NoContent();
			}

			return Results.NoContent();
		});

		app.Run();
	}
}