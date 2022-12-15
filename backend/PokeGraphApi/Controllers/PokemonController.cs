using Microsoft.AspNetCore.Mvc;

namespace PokeGraphApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        PokemonService pokemonService;
        public PokemonController(PokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Pokemon>> Get(string name)
        {
            Pokemon pokemon = await pokemonService.Get(name);
            return pokemon;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pokemon>> Get(int id)
        {
            Pokemon pokemon = await pokemonService.Get(id);
            return pokemon;
        }
        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetAll()
        {
            List<Pokemon> pokemons = await pokemonService.GetAll();
            return pokemons;
        }
    }
}
