using BibliotecaAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Data;


public class ApplicationDbContext:DbContext
{
    //Se agrega econstructor para inyectar el DbContextOptions
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    //Aqui se declara el nombre de la tabla
    public DbSet<Autor> Autores { get; set; }


}
