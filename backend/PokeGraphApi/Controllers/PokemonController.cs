using Microsoft.AspNetCore.Mvc;

namespace PokeGraphApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        [HttpGet("{name}")]
        public ActionResult<Pokemon> Get(string name)
        {
            Pokemon pokemon = Pokemon.get(name);
            return pokemon;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Pokemon> Get(int id)
        {
            Pokemon pokemon = Pokemon.get(id);
            return pokemon;
        }
        [HttpGet]
        public ActionResult<List<Pokemon>> GetAll()
        {
            List<Pokemon> pokemons = Pokemon.getAll();
            // Return response with code and errors inside body
            return pokemons;
        }
    }
}
