using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApiUsingDatabase.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApiUsingDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItems2Controller : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItems2Controller(TodoContext context)
        {
            _context = context;
        }
        // GET: api/<TodoItems2Controller>
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _context.TodoItems;
        }

        // GET api/<TodoItems2Controller>/5
        [HttpGet("{id}")]
        public TodoItem Get(int id)
        {
            return _context.TodoItems.FirstOrDefault(item => item.Id == id);
        }

        // POST api/<TodoItems2Controller>
        [HttpPost]
        public TodoItem Post([FromBody] TodoItem value)
        {
            // TODO generated Id??
            _context.TodoItems.Add(value);
            _context.SaveChangesAsync();
            return value;
        }

        /*/ PUT api/<TodoItems2Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TodoItem value)
        {
        
        }*/

        // DELETE api/<TodoItems2Controller>/5
        [HttpDelete("{id}")]
        public TodoItem Delete(int id)
        {
            TodoItem item = _context.TodoItems.FirstOrDefault(todoItem => todoItem.Id == id);
            if (item == null) return null;
            _context.TodoItems.Remove(item);
            return item;
        }
    }
}
