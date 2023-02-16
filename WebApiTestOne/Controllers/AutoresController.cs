using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTestOne.Entidades;

namespace WebApiTestOne.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        // contructor de la clase 
        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
           return await context.Autores.Include(x => x.Libros).ToListAsync();  
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autorData)
        {
            context.Add(autorData);
            await context.SaveChangesAsync();
            return Ok();    
        }

        [HttpPut("{id:int}")]  // api/autores/*
        public async Task<ActionResult> Put(Autor autorData, int id)
        {
            // validar si el id corresponde al usuario
            if(autorData.Id != id)
            {
                return BadRequest("El Id del autor no coicide");
            }

            var existeAutor = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existeAutor)
            {
                return NotFound();
            }

            context.Update(autorData);  
            await context.SaveChangesAsync();   
            return Ok();    
        }

        [HttpDelete("{id:int}")] // api/autores/2
        public async Task<ActionResult> Delete(int id)
        {
            var existeAutor = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existeAutor)
            {
                return NotFound();
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
