using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Entidades;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController
    {
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return new List<Autor>
            {
                new Autor { Id = 1, Name = "Autor 1" },
                new Autor { Id = 2, Name = "Autor 2" }
            };  
        }
    }
}
