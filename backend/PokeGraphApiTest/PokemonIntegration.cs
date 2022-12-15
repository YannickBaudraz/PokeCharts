using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Moq;
using PokeGraphApi.Controllers;
using PokeGraphApi.State;
using FluentAssertions;

namespace PokeGraphApiTest
{
    [TestClass]
    public class PokemonIntegration
    {
        Mock<PokemonService> PokemonServiceMock = new Mock<PokemonService>();
        [TestMethod]
        public void PokemonGetByNameSucess()
        {
            Pokemon pokemonToTest = new Pokemon("Pikachu", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png");
            PokemonServiceMock.Setup(pokemonService => pokemonService.Get(It.IsAny<string>())).Returns(Task.FromResult(pokemonToTest));
            PokemonController pokemonController = new PokemonController(PokemonServiceMock.Object);
            Pokemon? result = pokemonController.Get("teemo").Result.Value;
            result.Should().BeEquivalentTo(pokemonToTest);
        }
    }
}
    