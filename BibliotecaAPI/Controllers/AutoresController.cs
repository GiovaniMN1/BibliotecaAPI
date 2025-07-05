using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Entidades;
using BibliotecaAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
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
        public async Task<ActionResult> Post(Autor autor) {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Autor>> Get()
        {
            return await context.Autores.ToListAsync();
        }

        //metodo para obtener un autor por id
        [HttpGet("{id:int}")] //Agregamos el id como parametro  seria asi https://localhost:7281/api/autores/1
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            //if(string.IsNullOrEmpty(autor)
            //{
            //    return NotFound();  
            //}
            if (autor == null)
            {
                return NotFound();
            }

            return autor;

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Autor>> Put(int id, Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != autor.Id)
            {
                return BadRequest();
            }
            context.Entry(autor).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await context.Autores.AnyAsync(a => a.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw; // Re-lanza la excepción si es otro error de concurrencia
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno: " + ex.Message);
            }

            return Ok(autor);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Autor>> Delete(int id)
        {
            var existItem = await context.Autores.FindAsync(id);
            if (existItem == null) {
                return NotFound();
            }
            context.Autores.Remove(existItem);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
