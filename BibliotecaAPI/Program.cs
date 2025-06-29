using BibliotecaAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Area Servicios

//se agarega la conexion a db
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));


builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Area de Middlewares
app.MapControllers();

app.Run();
