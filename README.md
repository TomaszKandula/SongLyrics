# Song Lyrics

Test project in React.js - allows to traverse through different artists to find songs from albums for lyrics. Project status can be seen here: [Project Board](https://github.com/users/TomaszKandula/projects/6).

## Tech-stack

### Front-end

1. React.js
1. Redux.js.
1. React-Materialize.
1. Materialize CSS via CDN.
1. React HTML Parser.
1. React Pose.

Client application uses classes and connects instead of functional approach with React Hooks. However, project using React Hooks can be found here: [TokanPages](https://github.com/users/TomaszKandula/projects/7).

### Back-end

1. Web API (NET Core 3.1 / C# language).
1. SQL Database, Entity Framework Core.
1. SeriLog for structural logging (sink to file).
1. Swagger-UI.

Unit Tests and Integration Tests are provided using [XUnit](https://github.com/xunit/xunit) and [FluentAssertions](https://github.com/fluentassertions/fluentassertions).

Back-end project is relatively small and therefore is not split into sub-projects.

## Setting-up the database

Setup the connection string in the settings file:

```
{
  "ConnectionStrings": 
  {
    "DbConnect": "<your_connection_string_goes_here>"
  }
}
```

Run following command in Package Manager Console:  

`Update-Database -StartupProject SongLyrics -Project SongLyrics -Context MainDbContext`

EF Core will create necessary tables and will seed test data. 

## Integration Tests

Focuses on testing HTTP responses, dependencies and theirs configuration.

## Unit Tests

Covers all the logic used in the controllers (please note that the endpoints does not provide any business logic, they are only responsible for handling requests, validation etc.). All dependencies are mocked. For mocking [Moq](https://github.com/moq/moq4) and [MockQueryable.Moq](https://github.com/romantitov/MockQueryable) have been used. 

## REST API

Currently, all controllers are public.

__Swagger-UI__ is added for easy API discover: `/swagger`. Swagger JSON is also available: `/swagger/v1/swagger.json`.

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

When succeed returns **200** status code and returns list of all artist members (if applicable).

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

##### Return all albums (or given artist album)

```
GET /api/v1/albums/?ArtistId={id}
```

When succeed returns **200** status code and returns albums or album recorded by selected band id.

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
