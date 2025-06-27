var builder = WebApplication.CreateBuilder(args);

//Area Servicios

builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Area de Middlewares
app.MapControllers();

app.Run();
