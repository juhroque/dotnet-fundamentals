var builder = WebApplication.CreateBuilder(args); 
var app = builder.Build(); 

app.MapGet("/", () => {
    return Results.Ok("Hello World"); // Return a 200 OK response
}); 

// Route with a parameter
// url/name/Julia returns Hello Julia
app.MapGet("name/{nome}", (string nome) => {
    return Results.Ok($"Hello {nome}"); // Return a 200 OK response
}); 

app.MapPost("/", (User user) => { 
    return Results.Ok(user); // Return a 200 OK response with the user object (JSON -> object: serialization; object -> JSON: deserialization)
});

app.Run(); // Run the web application

public class User 
{
    public int Id { get; set; } 
    public string Username { get; set; } = string.Empty; 
}