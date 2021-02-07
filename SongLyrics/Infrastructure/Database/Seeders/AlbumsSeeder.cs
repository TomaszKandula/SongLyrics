using System;
using Microsoft.EntityFrameworkCore;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Seeders
{
    public class AlbumsSeeder : IMainDbContextSeeder
    {
        public void Seed(ModelBuilder AModelBuilder)
        {
            AModelBuilder.Entity<Albums>().HasData(
                new Albums 
                {
                    Id = 1,
                    ArtistId = 1,
                    AlbumName = "Queen",
                    Issued = DateTime.Parse("1973-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 2,
                    ArtistId = 1,
                    AlbumName = "Queen II",
                    Issued = DateTime.Parse("1974-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 3,
                    ArtistId = 1,
                    AlbumName = "Sheer Heart Attack",
                    Issued = DateTime.Parse("1974-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 4,
                    ArtistId = 1,
                    AlbumName = "A Night at the Opera",
                    Issued = DateTime.Parse("1975-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 5,
                    ArtistId = 1,
                    AlbumName = "A Day at the Races",
                    Issued = DateTime.Parse("1976-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 6,
                    ArtistId = 1,
                    AlbumName = "News of the World",
                    Issued = DateTime.Parse("1977-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 7,
                    ArtistId = 1,
                    AlbumName = "Jazz",
                    Issued = DateTime.Parse("1978-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 8,
                    ArtistId = 1,
                    AlbumName = "The Game",
                    Issued = DateTime.Parse("1980-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 9,
                    ArtistId = 1,
                    AlbumName = "Flash Gordon",
                    Issued = DateTime.Parse("1980-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 10,
                    ArtistId = 1,
                    AlbumName = "Hot Space",
                    Issued = DateTime.Parse("1982-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 11,
                    ArtistId = 1,
                    AlbumName = "The Works",
                    Issued = DateTime.Parse("1984-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 12,
                    ArtistId = 1,
                    AlbumName = "A Kind of Magic",
                    Issued = DateTime.Parse("1986-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 13,
                    ArtistId = 1,
                    AlbumName = "The Miracle",
                    Issued = DateTime.Parse("1989-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 14,
                    ArtistId = 1,
                    AlbumName = "Innuendo",
                    Issued = DateTime.Parse("1991-01-01 00:00:00")
                },
                new Albums
                {
                    Id = 15,
                    ArtistId = 1,
                    AlbumName = "Made in Heaven",
                    Issued = DateTime.Parse("1995-01-01 00:00:00")
                }
            );
        }
    }
}
