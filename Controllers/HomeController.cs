using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{

    [ApiController]
    public class HomeController : ControllerBase
    {
        // Every public method in a controller is called an ACTION
        [HttpGet("/")]
        public IActionResult Get(
            [FromServices] AppDbContext context // Dependency Injection
        ) => Ok(context.Todos.ToList());
        

        [HttpGet("/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context // Dependency Injection
        )
        {
            var todo = context.Todos.FirstOrDefault(todo => todo.Id == id);
            if(todo == null) 
                return NotFound();
            return Ok(todo);
        }

        [HttpPost("/")]
        public IActionResult Post(
            [FromServices] AppDbContext context,
            [FromBody] TodoModel todo
        )
        {
            context.Todos.Add(todo);
            context.SaveChanges();

            return Created($"/{todo.Id}", todo); // 201 code
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context // Dependency Injection
        )
        {
            var model = context.Todos.FirstOrDefault(todo => todo.Id == id);
            if (model == null) 
                return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;
            context.Todos.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context // Dependency Injection
        )
        {
            var model = context.Todos.FirstOrDefault(todo => todo.Id == id);
            if(model == null)
                return NotFound();
            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }

    }
}