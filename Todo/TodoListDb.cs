using Microsoft.EntityFrameworkCore;
using Todo.Model;

namespace Todo
{
    public class TodoListDb : DbContext
    {
        public TodoListDb(DbContextOptions<TodoListDb> options) : base(options)
        {

        }

        public DbSet<TodoData> TodoLists { get; set; }
    }
}
