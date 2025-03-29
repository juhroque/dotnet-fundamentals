var builder = WebApplication.CreateBuilder(args); 
var app = builder.Build(); 

app.MapGet("/", () => {
    return Results.Ok("Hello World"); // Return a 200 OK response
}); 

app.Run(); // Run the web application
