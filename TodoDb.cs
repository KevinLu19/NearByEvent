using Microsoft.EntityFrameworkCore;

namespace AzureASPApi;

public class TodoDb : DbContext
{
	public TodoDb(DbContextOptions<TodoDb> options)
		: base(options) {  }

	public DbSet<Todo> Todos => Set<Todo>();
}
