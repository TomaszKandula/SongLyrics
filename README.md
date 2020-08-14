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

and for Integration Test (BackEnd.IntegrationTests project):

```
{
    "DbConnect": "<your_connection_string_goes_here>"
}
```

The database have six tables so far, because this project have already database setup, one may use SQL scripts to create tables and populate database tables from CSV files, all provided here: [Database Examples](https://github.com/TomaszKandula/SongLyrics/tree/master/DatabaseExamples).

## Integration Tests

Focuses on testing dependencies and theirs configuration. There are no HTTP tests at this point, but planned.

## Unit Tests

Covers all the logic used in the controllers (please note that the endpoints does not provide any business logic, they are only responsible for handling requests, validation etc.). All dependencies are mocked. For mocking [Moq](https://github.com/moq/moq4) and [MockQueryable.Moq](https://github.com/romantitov/MockQueryable) have been used. 
