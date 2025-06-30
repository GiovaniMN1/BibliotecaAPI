using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Entidades;
using BibliotecaAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        //Se agrega el constructor para permitir la inyección de dependencias DbContext
        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //[HttpGet]
        //public IEnumerable<Autor> Get()
        //{
        //    return new List<Autor>
        //    {
        //        new Autor { Id = 1, Name = "Autor 1" },
        //        new Autor { Id = 2, Name = "Autor 2" }
        //    };  
        //}

        [HttpPost]
        public async Task<ActionResult> Post (Autor autor) {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Autor>> Get()
        {
            return await context.Autores.ToListAsync();
        }
        
    }
}
