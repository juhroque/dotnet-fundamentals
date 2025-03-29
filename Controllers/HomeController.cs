using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{

    [ApiController] 
    public class HomeController : ControllerBase
    {
        // Every public method in a controller is called an ACTION
        [HttpGet("/")]
        public string Get(){
            return "Hello World";
        }
    }
}