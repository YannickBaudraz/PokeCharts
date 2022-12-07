# GraphQL

## Installation de graphql
Source: https://bartwullems.blogspot.com/2021/10/graphqlstrawberry-shake-graphql-client.html

```sh
dotnet tool install StrawberryShake.Tools –local
dotnet add package StrawberryShake.Transport.Http
dotnet add package StrawberryShake.CodeGeneration.CSharp.Analyzers
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Http
``` 

Ca doit ajouter ces nouvaux packageS dans le fichier `PokeGraphApi.csproj`
```c#
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="7.0.0" />
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="7.0.0" />
    <PackageReference Include="Microsoft.Extensions.Http" Version="7.0.0" />
    <PackageReference Include="StrawberryShake.CodeGeneration.CSharp.Analyzers" Version="12.15.2" />
    <PackageReference Include="StrawberryShake.Transport.Http" Version="12.15.2" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
  </ItemGroup>
  ```

## Initialisation du client graphql:

Source: https://www.youtube.com/watch?v=I0ihOcBVu8c


```sh
dotnet graphql init https://beta.pokeapi.co/graphql/v1beta -n PokeAPIGraphClient
``` 

Le nom du client qui sera utilisé dans le code sera: `PokeGraphAPiClient`

Cette commande crée 4 fichiers à la racine: `.graphqrc.json`, `schema.extensions.graphql`, `schema.graphql`, `.graphqlrc.json`

Les fichiers de schemas font en sorte qu'on puisse compiler les requêtes GraphQL.


## StrawberryShake.Server

Ajout du package StrawberryShake.Server:

```sh
dotnet add package StrawberryShake.Server
```

Cela va générer le client.

Dans `Program.cs` on va ajouter le client `PokeAPIGraphClient` qu'on vient de créer à notre service.
On va également spécifier comment il faut se connecter au backend de notre client.

```c#
builder.Services
    .AddPokeAPIGraphClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://beta.pokeapi.co/graphql/v1beta"));
```


## Créer notre requête

On se base sur la samplePokeAPIQuery ici: https://beta.pokeapi.co/graphql/console/
On crée la requête dans un fichier `samplePokeAPIquery.graphql`

