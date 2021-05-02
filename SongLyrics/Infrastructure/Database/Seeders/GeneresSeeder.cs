using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Seeders
{
    public class GeneresSeeder : IMainDbContextSeeder
    {
        public void Seed(ModelBuilder AModelBuilder)
            => AModelBuilder.Entity<Generes>().HasData(CreateGeneresList());

        private static IEnumerable<Generes> CreateGeneresList()
        {
            return new List<Generes>
            {
                new Generes 
                {
                    Id = 1,
                    Genere = "Art Punk"
                },
                new Generes
                {
                    Id = 2,
                    Genere = "Alternative Rock"
                },
                new Generes
                {
                    Id = 3,
                    Genere = "Britpunk"
                },
                new Generes
                {
                    Id = 4,
                    Genere = "College Rock"
                },
                new Generes
                {
                    Id = 5,
                    Genere = "Crossover Thrash"
                },
                new Generes
                {
                    Id = 6,
                    Genere = "Crust Punk"
                },
                new Generes
                {
                    Id = 7,
                    Genere = "Emotional Hardcore"
                },
                new Generes
                {
                    Id = 8,
                    Genere = "Experimental Rock"
                },
                new Generes
                {
                    Id = 9,
                    Genere = "Folk Punk"
                },
                new Generes
                {
                    Id = 10,
                    Genere = "Gothic Rock"
                },
                new Generes
                {
                    Id = 11,
                    Genere = "Grunge"
                },
                new Generes
                {
                    Id = 12,
                    Genere = "Hardcore Punk"
                },
                new Generes
                {
                    Id = 13,
                    Genere = "Hard Rock"
                },
                new Generes
                {
                    Id = 14,
                    Genere = "Indie Rock"
                },
                new Generes
                {
                    Id = 15,
                    Genere = "Lo-fi"
                },
                new Generes
                {
                    Id = 16,
                    Genere = "Musique Concrète"
                },
                new Generes
                {
                    Id = 17,
                    Genere = "New Wave"
                },
                new Generes
                {
                    Id = 18,
                    Genere = "Progressive Rock"
                },
                new Generes
                {
                    Id = 19,
                    Genere = "Punk"
                },
                new Generes
                {
                    Id = 20,
                    Genere = "Shoegaze"
                },
                new Generes
                {
                    Id = 21,
                    Genere = "Steampunk"
                },
                new Generes
                {
                    Id = 22,
                    Genere = "Blues"
                },
                new Generes
                {
                    Id = 23,
                    Genere = "Rock"
                },
                new Generes
                {
                    Id = 24,
                    Genere = "Classical"
                },
                new Generes
                {
                    Id = 25,
                    Genere = "Country"
                },
                new Generes
                {
                    Id = 26,
                    Genere = "Dance"
                },
                new Generes
                {
                    Id = 27,
                    Genere = "Pop"
                },
                new Generes
                {
                    Id = 28,
                    Genere = "Electronic"
                },
                new Generes
                {
                    Id = 29,
                    Genere = "French Pop"
                },
                new Generes
                {
                    Id = 30,
                    Genere = "German Folk"
                },
                new Generes
                {
                    Id = 31,
                    Genere = "German Pop"
                },
                new Generes
                {
                    Id = 32,
                    Genere = "Hip-Hop/Rap"
                },
                new Generes
                {
                    Id = 33,
                    Genere = "Indie Pop"
                },
                new Generes
                {
                    Id = 34,
                    Genere = "Industrial"
                },
                new Generes
                {
                    Id = 35,
                    Genere = "Instrumental"
                },
                new Generes
                {
                    Id = 36,
                    Genere = "J-Pop"
                },
                new Generes
                {
                    Id = 37,
                    Genere = "Jazz"
                },
                new Generes
                {
                    Id = 38,
                    Genere = "K-Pop"
                },
                new Generes
                {
                    Id = 39,
                    Genere = "Karaoke"
                },
                new Generes
                {
                    Id = 40,
                    Genere = "Latin"
                },
                new Generes
                {
                    Id = 41,
                    Genere = "New Age"
                },
                new Generes
                {
                    Id = 42,
                    Genere = "Opera"
                },
                new Generes
                {
                    Id = 43,
                    Genere = "Progressive"
                },
                new Generes
                {
                    Id = 44,
                    Genere = "R&B/Soul"
                },
                new Generes
                {
                    Id = 45,
                    Genere = "Reggae"
                }
            };
        }
    }
}
