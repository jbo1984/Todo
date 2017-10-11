using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Model;


namespace Todo.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoListDb _context;

        public TodoController(TodoListDb context)
        {
            _context = context;
            if (_context.TodoLists.Count() == 0)
            {
                _context.TodoLists.Add(new TodoData { Id = 1, Item = "Walk dog", Done = false});
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<TodoData> GetAll()
        {
            return _context.TodoLists.ToList();
        }
    }
}
