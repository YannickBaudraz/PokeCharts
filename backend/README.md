# PokeGraph Backend

## Local PokeApi Graphql

The backend call the Graphql PokeApi in order to get data more precisely and in less request than the REST API. The
problem is that the public Graphql API is rate limited to 100 request per hour. So we need to run our own Graphql in a
local environment where we can make as many request as we want.

Fortunately, the repository of PokeApi provide a Docker container setup managed by Docker Compose that allow to create
a production-like environment with a Graphql API.

### Get the requirements

First, clone [this fork](https://github.com/yannickcpnv/pokeapi) of the PokeApi repository.

To have the local API you'll need to have :

- [Docker](https://docs.docker.com/get-docker/)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [Gnu Make](https://www.gnu.org/software/make/#download)
    - `choco install make` on Windows
    - Install it from [cygwin](https://www.cygwin.com/) on Windows
- [Hasura CLI](https://hasura.io/docs/latest/hasura-cli/install-hasura-cli/) (v2.0.8)
    - `npm install -g hasura-cli@2.0.8`

### Setup and run the local GraphQL API

Start everything by

```shell
make docker-setup
```

When you start PokéAPI with the above docker-compose setup, an [Hasura Engine](https://github.com/hasura/graphql-engine)
server is started as well. It's possible to track all the PokeAPI tables and foreign keys by simply run

```shell
make hasura-apply
```

When finished browse <http://localhost:8080> and you will find the admin console. The password is `pokemon`.
The GraphQL endpoint will be hosted at <http://localhost:8080/v1/graphql>.

After that you can also just stop and start the containers with

```shell
# Stop the containers
make docker-down

# Start the containers
make docker-up
```

A set of examples are provided in the
directory [/graphql/examples](https://github.com/yannickcpnv/pokeapi/tree/master/graphql/examples) of the repository.

_More information can be found at [this link](https://github.com/yannickcpnv/pokeapi#docker-and-compose--)._
