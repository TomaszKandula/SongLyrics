CREATE TABLE Generes
(
    Id        INT IDENTITY(1, 1) PRIMARY KEY,
    Genere    VARCHAR(255) NOT NULL
)


CREATE TABLE Bands 
(
    Id             INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    ArtistName     NVARCHAR(255) NOT NULL,
    Established    DATE NOT NULL,
    ActiveUntil    DATE NULL
)


CREATE TABLE BandsGeneres
(
    Id            INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    GenereId      INT NOT NULL,
    ArtistId      INT NOT NULL,
    CONSTRAINT    FK__GenereId__Generes FOREIGN KEY (GenereId) REFERENCES Generes (Id),
    CONSTRAINT    FK__ArtistId__ArtistsGeneres FOREIGN KEY (ArtistId) REFERENCES Artists (Id)
)


CREATE TABLE Members
(
    Id            INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    ArtistId      INT NOT NULL,
    FirstName     NVARCHAR(255) NOT NULL,
    LastName      NVARCHAR(255) NOT NULL,
    IsPresent     BIT NOT NULL
    CONSTRAINT    FK__ArtistId__MembersArtists FOREIGN KEY (ArtistId) REFERENCES Artists (Id),
)


CREATE TABLE Albums
(
    Id            INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    ArtistId      INT NOT NULL,
    AlbumName     NVARCHAR(255) NOT NULL,
    Issued        DATE NOT NULL
    CONSTRAINT    FK__ArtistId__AlbumsArtists FOREIGN KEY (ArtistId) REFERENCES Artists (Id),
)


CREATE TABLE Songs
(
    Id            INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    AlbumId       INT NOT NULL,    
    ArtistId      INT NOT NULL,
    SongName      NVARCHAR(255) NOT NULL,
    SongUrl       VARCHAR(2048) NULL,
    SongLyrics    VARCHAR(MAX) NOT NULL,
    CONSTRAINT    FK__AlbumId__Albums FOREIGN KEY (AlbumId) REFERENCES Albums (Id),
    CONSTRAINT    FK__ArtistId__Artists FOREIGN KEY (ArtistId) REFERENCES Artists (Id)
)
