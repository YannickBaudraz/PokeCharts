var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddPokeAPIGraphClient()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://beta.pokeapi.co/graphql/v1beta"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet(
    "/{name}", 
    async (string name, PokeGraphApi.GetPokemonByNameQuery query, CancellationToken cancellationToken) => 
    {
        var result = await query.ExecuteAsync(name, cancellationToken);
        return result.Data!.Pokemon_v2_pokemon;
    });


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
