# Song Lyrics

Song Lyrics project allow to traverse through different artists to find songs from albums for lyrics.

In the future, this project may also allow to register an account, and the users will be able to add and modify artists data (albums, songs, lyrics, etc.).

Working demo has been deployed on Azure Cloud: [Song Lyrics](https://songlyrics.azurewebsites.net).

## Tech-stack

### Front-end

1. React.js
1. Redux.js.
1. React-Materialize.
1. Materialize CSS via CDN.

### Back-end

1. Web API (NET Core 3.1 / C# language).
1. SQL Database, Entity Framework Core.
1. SeriLog for structural logging*.

Unit Tests and Integration Tests are provided using [XUnit](https://github.com/xunit/xunit) and [FluentAssertions](https://github.com/fluentassertions/fluentassertions).

*Kibana and ElasticSearch with Docker are planned to be used.

## Setting-up the database

For testing, local SQL server/database is used, connection string have to be setup in __secrets.json__ (BackEnd project):

```
{

  "ConnectionStrings": 
  {
    "DbConnect": "<your_connection_string_goes_here>"
  }

}
```

Integration Tests uses the same __secrets.json__.

The database have six tables so far, because this project have already database setup ([database first approach](https://entityframeworkcore.com/approach-database-first)), one may use SQL scripts to create tables and populate database tables from CSV files, all provided here: [Database Examples](https://github.com/TomaszKandula/SongLyrics/tree/master/DatabaseExamples).

## Integration Tests

Focuses on testing HTTP responses, dependencies and theirs configuration.

## Unit Tests

Covers all the logic used in the controllers (please note that the endpoints does not provide any business logic, they are only responsible for handling requests, validation etc.). All dependencies are mocked. For mocking [Moq](https://github.com/moq/moq4) and [MockQueryable.Moq](https://github.com/romantitov/MockQueryable) have been used. 

## REST API

Currently, all controllers are public.

### Artists controller

#### Return artists

```
GET /api/v1/artists/
```

When succeed returns **200** status code and returns list of artists from the entire collection.

#### Return band members

```
GET /api/v1/artists/{id}/members/
```

When succeed returns **200** status code and returns list of all band members.

#### Returns band detail

```
GET /api/v1/artists/{id}/details/
```

When succeed returns **200** status code and returns:

1. Artist name.
1. When started.
1. When ended.
1. Music genere.
1. List of members.

### Albums controller

##### Return all albums (or given band album)

```
GET /api/v1/albums/?BandId={id}
```

When succeed returns **200** status code and returns albums or abum recorded by selected band id.

##### Return specific album

```
GET /api/v1/albums/{id}/
```

When succeed returns **200** status code and returns specific album.

### Songs controller

##### Return songs

```
GET /api/v1/songs/?AlbumId={id}
```

When succeed returns **200** status code and returns all songs from the entire collection or songs belonging to given album.

##### Return song

```
GET /api/v1/music/songs/{Id}/
```

When succeed returns **200** status code and returns selected song from the entire collection.
