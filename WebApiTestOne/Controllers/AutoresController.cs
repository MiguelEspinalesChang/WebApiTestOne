using Microsoft.AspNetCore.Mvc;
using WebApiTestOne.Entidades;

namespace WebApiTestOne.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Autor>> Get()
        {
            return new List<Autor>()
            {
                new Autor() { Id = 1, Nombre = "Juan"},
                new Autor() { Id = 2, Nombre = "Jose"},
                new Autor() { Id = 3, Nombre = "Manuel"}
            };
        }
    }
}
