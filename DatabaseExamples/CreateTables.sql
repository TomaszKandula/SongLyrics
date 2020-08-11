CREATE TABLE Generes
(
    Id        INT IDENTITY(1, 1) PRIMARY KEY,
    Genere    VARCHAR(255) NOT NULL
)


CREATE TABLE Bands 
(
    Id             INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    BandName       NVARCHAR(255) NOT NULL,
    Established    DATE NOT NULL,
    ActiveUntil    DATE NULL
)


CREATE TABLE BandsGeneres
(
    Id            INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    GenereId      INT NOT NULL,
    BandId        INT NOT NULL,
    constraint    FK__GenereId__Generes FOREIGN KEY (GenereId) REFERENCES Generes (Id),
    constraint    FK__BandId__BandsGeneres FOREIGN KEY (BandId) REFERENCES Bands (Id)
)


CREATE TABLE Members
(
    Id            INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    BandId        INT NOT NULL,
    FirstName     NVARCHAR(255) NOT NULL,
    LastName      NVARCHAR(255) NOT NULL,
    IsPresent     BIT NOT NULL
    constraint    FK__BandId__MembersBands FOREIGN KEY (BandId) REFERENCES Bands (Id),
)


CREATE TABLE Albums
(
    Id            INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    BandId        INT NOT NULL,
    AlbumName     NVARCHAR(255) NOT NULL,
    Issued        DATE NOT NULL
    constraint    FK__BandId__AlbumsBands FOREIGN KEY (BandId) REFERENCES Bands (Id),
)


CREATE TABLE Songs
(
    Id            INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    AlbumId       INT NOT NULL,    
    SongName      NVARCHAR(255) NOT NULL,
    SongUrl       VARCHAR(2048) NULL,
    SongLyrics    VARCHAR(MAX) NOT NULL,
    constraint    FK__AlbumId__Albums FOREIGN KEY (AlbumId) REFERENCES Albums (Id)
)
