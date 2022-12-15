using PokeGraphApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddPokeAPIGraphClient()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:8080/v1/graphql"));


builder.Services.AddControllers();
builder.Services.AddSingleton<PokemonService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


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
