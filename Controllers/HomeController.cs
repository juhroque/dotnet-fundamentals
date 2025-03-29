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
        public List<TodoModel> Get(
            [FromServices] AppDbContext context // Dependency Injection
        )
        {
            return context.Todos.ToList();
        }

        [HttpGet("/{id:int}")]
        public TodoModel GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context // Dependency Injection
        )
        {
            return context.Todos.FirstOrDefault(todo => todo.Id == id);
        }

        [HttpPost("/")]
        public IActionResult Post(
            [FromServices] AppDbContext context,
            [FromBody] TodoModel model
        )
        {
            context.Todos.Add(model);
            context.SaveChanges();

            return Created($"/{model.Id}", model); // 201 code
        }

        [HttpPut("/{id:int}")]
        public TodoModel Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context // Dependency Injection
        )
        {
            var model = context.Todos.FirstOrDefault(todo => todo.Id == id);
            if (model == null) return todo;

            model.Title = todo.Title;
            model.Done = todo.Done;
            context.Todos.Update(model);
            context.SaveChanges();
            return model;
        }

        [HttpDelete("/{id:int}")]
        public TodoModel Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context // Dependency Injection
        )
        {
            var model = context.Todos.FirstOrDefault(todo => todo.Id == id);
            context.Todos.Remove(model);
            context.SaveChanges();
            return model;
        }

    }
}