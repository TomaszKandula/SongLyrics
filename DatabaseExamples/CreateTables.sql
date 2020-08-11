

create table Generes
(
	Id		int identity(1, 1) primary key,
	Genere	varchar(255) not null
)


create table Bands 
(
	Id			int identity(1, 1) primary key not null,
	BandName	nvarchar(255) not null,
	Established	date not null,
	ActiveUntil	date null
)


create table BandsGeneres
(
	Id			int identity(1, 1) primary key not null,
	GenereId	int not null,
	BandId		int not null,
	constraint	FK__GenereId__Generes FOREIGN KEY (GenereId) REFERENCES Generes (Id),
	constraint	FK__BandId__BandsGeneres FOREIGN KEY (BandId) REFERENCES Bands (Id)
)


create table Members
(
	Id			int identity(1, 1) primary key not null,
	BandId		int not null,
	FirstName	nvarchar(255) not null,
	LastName	nvarchar(255) not null,
	IsPresent	bit not null
	constraint	FK__BandId__MembersBands FOREIGN KEY (BandId) REFERENCES Bands (Id),
)


create table Albums
(
	Id			int identity(1, 1) primary key not null,
	BandId		int not null,
	AlbumName	nvarchar(255) not null,
	Issued		date not null
	constraint	FK__BandId__AlbumsBands FOREIGN KEY (BandId) REFERENCES Bands (Id),
)


create table Songs
(
	Id			int identity(1, 1) primary key not null,
	AlbumId		int not null,	
	SongName	nvarchar(255) not null,
	SongUrl		varchar(2048) null,
	SongLyrics	varchar(max) not null,
	constraint	FK__AlbumId__Albums FOREIGN KEY (AlbumId) REFERENCES Albums (Id)
)

