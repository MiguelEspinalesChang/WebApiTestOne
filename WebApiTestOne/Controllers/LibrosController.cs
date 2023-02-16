using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTestOne.Entidades;

namespace WebApiTestOne.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            return await context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);  
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libroData)
        {

            var existeAutor = await context.Autores.AnyAsync(x => x.Id == libroData.AutorId);

            if (!existeAutor)
            {
                return BadRequest("El Id del autor no coicide");
            }

            context.Add(libroData);  
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
