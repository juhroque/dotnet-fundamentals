var builder = WebApplication.CreateBuilder(args); // Create a builder for the web application
var app = builder.Build(); // Build the web application

app.MapGet("/", () => "Hello World!"); // Map a GET request to the root URL to return "Hello World!"

// If I try to call the route GET /banana -> 404 not found cause I did not map this route
// () => "Hello World!" is a lambda function that returns "Hello World!" when the root URL is accessed (função anônima)

app.MapGet("/banana", () => "Hello Banana!"); // Map a GET request to the /banana URL to return "Hello Banana!"
app.Run(); // Run the web application
