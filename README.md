# SongLyrics

SongLyrics project allow to traverse through different artists to find songs from albums for lyrics. This projects will also allow to register an account, users will be able to add and modify artists data (albums, songs, lyrics).

The project will be deployed on Azure cloud, the domain is yet to be determined. 

## Tech-stack

### Front-end

Planned:

1. React.js
1. Redux.js.
1. Materialize via CDN.

It is not yet started.

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

### Artists controller

#### Return bands

```
GET /api/v1/artists/bands/
```

When succeed returns **200** status code and returns list of bands from the entire collection.

#### Return band members

```
GET /api/v1/artists/bands/{id}/members/
```

When succeed returns **200** status code and returns list of all band members.

#### Returns band detail

```
GET /api/v1/artists/bands/{id}/details/
```

When succeed returns **200** status code and returns:

1. Band name.
1. When started.
1. When ended.
1. Music genere.
1. List of members.

### Music controller

#### Return all albums (or given band album)

```
GET /api/v1/music/albums/?BandId={id}
```

When succeed returns **200** status code and returns albums or abum recorded by selected band id.

#### Return specific album

```
GET /api/v1/music/albums/{id}/
```

When succeed returns **200** status code and returns specific album.

#### Return songs

```
GET /api/v1/music/songs/?AlbumId={id}
```

When succeed returns **200** status code and returns all songs from the entire collection or songs belonging to given album.

#### Return song

```
GET /api/v1/music/songs/{Id}/
```

When succeed returns **200** status code and returns selected song from the entire collection.
