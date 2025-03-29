var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers();

var app = builder.Build(); 

app.MapControllers();

app.Run(); // Run the web application
