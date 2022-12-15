using System;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using PokeGraphApi.State;

namespace PokeGraphApi
{
    public class PokemonService
    {
        private IPokeAPIGraphClient client;

        public PokemonService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddPokeAPIGraphClient()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:8080/v1/graphql"));
            IServiceProvider services = serviceCollection.BuildServiceProvider();
            client = services.GetRequiredService<IPokeAPIGraphClient>();
        }
        

        public async virtual Task<Pokemon> Get(string name)
        {
            var result = await client.GetPokemonByName.ExecuteAsync(name);
            return ConvertToPokemon(result.Data?.Pokemon_v2_pokemon[0]);
        }
        
        public async virtual Task<Pokemon> Get(int id)
        {
            var result = await client.GetPokemonById.ExecuteAsync(id);
            return ConvertToPokemon(result.Data?.Pokemon_v2_pokemon[0]);
        }

        public async virtual Task<List<Pokemon>> GetAll()
        {
            List<Pokemon> pokemonList = new List<Pokemon>();
            var result = await client.GetAllPokemons.ExecuteAsync();
            foreach
            return pokemonList;
        }
        public static Pokemon ConvertToPokemon(dynamic pokemon_v2_pokemon)
        {
            string pokemonName = pokemon_v2_pokemon.Name;
            int pokemonID = pokemon_v2_pokemon.Id;
            return new Pokemon(pokemonName, "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + pokemonID + ".png");
        }

    }
}

