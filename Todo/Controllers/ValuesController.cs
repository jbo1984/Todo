using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Model;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly TodoListDb _context;

        public ValuesController(TodoListDb context)
        {
            _context = context;
            if (_context.TodoLists.Count() == 0)
            {
                _context.TodoLists.Add(new TodoData {Id = 1, Item = "First task", Done = false });
                _context.TodoLists.Add(new TodoData { Id = 2, Item = "Second task", Done = false });
                _context.SaveChanges();
            }
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<TodoData> GetAll()
        {
            //Will return http 200 OK
            return _context.TodoLists.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(int id)
        {
            var item = _context.TodoLists.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]TodoData todoData)
        {
            //From Body Tells program to get data from body of http reaquest
            if (todoData == null)
            {
                return BadRequest();
            }
            _context.TodoLists.Add(todoData);
            _context.SaveChanges();
            //Returns 201
            return CreatedAtRoute("GetTodo", new {id = todoData.Id }, todoData);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]TodoData todoData)
        {
            //Sends the entire data not just changed
            if (todoData == null || todoData.Id != id)
            {
                return BadRequest();
            }

            var item = _context.TodoLists.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            item.Item = todoData.Item;
            item.Done = todoData.Done;

            _context.TodoLists.Update(item);
            _context.SaveChanges();
            return  new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
