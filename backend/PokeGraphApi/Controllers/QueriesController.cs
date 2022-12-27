using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace PokeGraphApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QueriesController : ControllerBase
{
    [HttpGet("simple")]
    public ActionResult<string> GetSimple()
    {
        return new GraphQlQuery("allPokemon")
            .Field("pokemon_v2_pokemon", builder => builder
                .Field("id")
                .Field("name")
            ).Build();
    }
    
    [HttpGet("complex")]
    public ActionResult<string> GetComplex()
    {
        GraphQlQuery complexQuery = new GraphQlQuery("weakestPokemonAbleToBeatFireRedAlone")
            .FieldWithArguments("pokemon_v2_pokemon", builder => builder
                .Argument("where", builder => builder
                    .Argument("_and", builder => builder
                        .Argument("pokemon_v2_pokemonspecy", builder => builder
                            .Argument("pokemon_v2_generation", builder => builder
                                .Argument("name", builder => builder
                                    .ArgumentCondition("_eq", "generation-i"))))
                        .Argument("pokemon_v2_pokemonmoves", builder => builder
                            .Argument("pokemon_v2_move", builder => builder
                                .Argument("name", builder => builder
                                    .ArgumentCondition("_eq", "strength"))))
                        .Argument("_and", builder => builder
                            .Argument("pokemon_v2_pokemonmoves", builder => builder
                                .Argument("pokemon_v2_move", builder => builder
                                    .Argument("name", builder => builder
                                        .ArgumentCondition("_eq", "cut"))))
                            .Argument("_and", builder => builder
                                .Argument("pokemon_v2_pokemonmoves", builder => builder
                                    .Argument("pokemon_v2_move", builder => builder
                                        .Argument("name", builder => builder
                                            .ArgumentCondition("_eq", "surf"))))))))
                .Argument("order_by", builder => builder
                    .ArgumentConditionEnum("base_experience", "asc"))
                .ArgumentCondition("limit", 1)
                .EndArguments()
                .Field("pokemon_v2_pokemonspecy", builder => builder
                    .FieldWithArguments("pokemon_v2_pokemonspeciesnames", builder => builder
                        .Argument("where", builder => builder
                            .Argument("pokemon_v2_language", builder => builder
                                .Argument("name", builder => builder
                                    .ArgumentCondition("_eq", "en"))))
                        .EndArguments()
                        .Field("name")))
            );

        return complexQuery.Build();
    }
}