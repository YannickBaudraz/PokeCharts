namespace PokeGraphApi
{
    public class Pokemon
    {
        private string name;
        private string imageUrl;

        public Pokemon(string name, string imageUrl)
        {
            this.name = name;
            this.imageUrl = imageUrl;
        }
        public string Name { get => name; }
        public string ImageUrl { get => imageUrl; }

        public static Pokemon get(string name)
        {
            return new Pokemon(name, "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png");
        }

        public static Pokemon get(int id)
        {
            return new Pokemon("Charmander", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png");
        }

        public static List<Pokemon> getAll()
        {
            List<Pokemon> pokemonList = new List<Pokemon>();
            pokemonList.Add(new Pokemon("Pikachu", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png"));
            pokemonList.Add(new Pokemon("Bulbasaur", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png"));
            pokemonList.Add(new Pokemon("Charmander", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png"));
            pokemonList.Add(new Pokemon("Squirtle", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/7.png"));
            pokemonList.Add(new Pokemon("Dialga", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/483.png"));
            return pokemonList;
        }
    }
}