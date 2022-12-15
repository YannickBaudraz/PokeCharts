using PokeGraphApi.State;

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
        
    }
}