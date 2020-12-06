using System;
using System.Collections.Generic;
using SongLyrics.Database.Models;

namespace SongLyrics.UnitTests.Database
{

    public static class DummyLoad
    {

        public static List<Artists> ReturnDummyArtists() 
        {

            return new List<Artists>()
            {

                new Artists
                {
                    Id          = 1,
                    ArtistName    = "Queen",
                    Established = DateTime.Parse("1970-01-01"),
                    ActiveUntil = null
                },

                new Artists
                { 
                    Id          = 2,
                    ArtistName    = "Led Zeppelin",
                    Established = DateTime.Parse("1968-01-01"),
                    ActiveUntil = DateTime.Parse("1980-01-01")
                }           
            
            };

        }

        public static List<Albums> ReturnDummyAlbums() 
        {

            return new List<Albums>()
            {
            
                new Albums
                { 
                    Id        = 1,
                    ArtistId    = 1,
                    AlbumName = "Queen",
                    Issued    = DateTime.Parse("1973-01-01"),
                    Artist = new Artists
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                },

                new Albums
                {
                    Id        = 2,
                    ArtistId    = 1,
                    AlbumName = "Queen II",
                    Issued    = DateTime.Parse("1974-01-01"),
                    Artist = new Artists
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                },

                new Albums
                {
                    Id        = 3,
                    ArtistId    = 2,
                    AlbumName = "Led Zeppelin",
                    Issued    = DateTime.Parse("1969-01-01"),
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    }
                },

                new Albums
                {
                    Id        = 4,
                    ArtistId    = 2,
                    AlbumName = "Led Zeppelin II",
                    Issued    = DateTime.Parse("1969-01-01"),
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    }
                },

            };
        
        }

        public static List<Generes> ReturnDummyGeneres() 
        {

            return new List<Generes>()
            {

                new Generes
                { 
                    Id     = 1,
                    Genere = "Rock"
                },

                new Generes
                {
                    Id     = 2,
                    Genere = "Pop"
                },

                new Generes
                {
                    Id     = 3,
                    Genere = "Jazz"
                }

            };

        }

        public static List<ArtistsGeneres> ReturnDummyBandsGeneres()
        {

            return new List<ArtistsGeneres>()
            {

                new ArtistsGeneres
                { 
                    Id       = 1,
                    ArtistId   = 1,
                    GenereId = 1,
                    Artist = new Artists 
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                    Genere = new Generes 
                    { 
                        Id = 1,
                        Genere = "Rock"
                    }

                },
                
                new ArtistsGeneres
                {
                    Id       = 2,
                    ArtistId   = 2,
                    GenereId = 1,
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                    Genere = new Generes
                    {
                        Id = 1,
                        Genere = "Rock"
                    }
                }

            };

        }

        public static List<Members> ReturnDummyMembers() 
        {

            return new List<Members>() 
            { 
            
                new Members
                { 
                    Id        = 1,
                    ArtistId    = 1,
                    FirstName = "Brian",
                    LastName  = "May",
                    IsPresent = true,
                    Artist = new Artists
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    }
                },

                new Members
                {
                    Id        = 2,
                    ArtistId    = 1,
                    FirstName = "Roger",
                    LastName  = "Taylor",
                    IsPresent = true,
                    Artist = new Artists
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    }                
                },

                new Members
                {
                    Id        = 3,
                    ArtistId    = 1,
                    FirstName = "John",
                    LastName  = "Deacon",
                    IsPresent = false,
                    Artist = new Artists
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    }
                },

                new Members
                {
                    Id        = 4,
                    ArtistId    = 1,
                    FirstName = "Freddie",
                    LastName  = "Mercury",
                    IsPresent = false,
                    Artist = new Artists
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    }
                },

                new Members
                {
                    Id        = 5,
                    ArtistId    = 2,
                    FirstName = "Robert",
                    LastName  = "Plant",
                    IsPresent = false,
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                },

                new Members
                {
                    Id        = 6,
                    ArtistId    = 2,
                    FirstName = "Jimmy",
                    LastName  = "Page",
                    IsPresent = false,
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                },

                new Members
                {
                    Id        = 7,
                    ArtistId    = 2,
                    FirstName = "John",
                    LastName  = "Jones",
                    IsPresent = false,
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                },

                new Members
                {
                    Id        = 8,
                    ArtistId    = 2,
                    FirstName = "John",
                    LastName  = "Bonham",
                    IsPresent = false,
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                }

            };
        
        }

        public static List<Songs> ReturnDummySongs() 
        {

            return new List<Songs>()
            {

                new Songs
                { 
                    Id         = 1,
                    AlbumId    = 1,
                    ArtistId     = 1,
                    SongName   = "Keep Yourself Alive",
                    SongLyrics = "aaa aaa aaa",
                    SongUrl    = "youtube.com/aaa",
                    Artist = new Artists
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                    Album = new Albums
                    {
                        Id        = 1,
                        ArtistId    = 1,
                        AlbumName = "Queen",
                        Issued    = DateTime.Parse("1973-01-01")
                    }
                },

                new Songs
                {
                    Id         = 2,
                    AlbumId    = 1,
                    ArtistId     = 1,
                    SongName   = "Liar",
                    SongLyrics = "bbb bbb bbb",
                    SongUrl    = "youtube.com/bbb",
                    Artist = new Artists
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                    Album = new Albums
                    {
                        Id        = 1,
                        ArtistId    = 1,
                        AlbumName = "Queen",
                        Issued    = DateTime.Parse("1973-01-01")
                    }
                },

                new Songs
                {
                    Id         = 3,
                    AlbumId    = 2,
                    ArtistId     = 1,
                    SongName   = "Seven Seas of Rhye",
                    SongLyrics = "ccc ccc ccc",
                    SongUrl    = "youtube.com/ccc",
                    Artist = new Artists
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                    Album = new Albums
                    {
                        Id        = 2,
                        ArtistId    = 1,
                        AlbumName = "Queen II",
                        Issued    = DateTime.Parse("1974-01-01")
                    }
                },

                new Songs
                {
                    Id         = 4,
                    AlbumId    = 2,
                    ArtistId     = 1,
                    SongName   = "White Queen",
                    SongLyrics = "ddd ddd ddd",
                    SongUrl    = "youtube.com/ddd",
                    Artist = new Artists
                    {
                        ArtistName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                    Album = new Albums
                    {
                        Id        = 2,
                        ArtistId    = 1,
                        AlbumName = "Queen II",
                        Issued    = DateTime.Parse("1974-01-01")
                    }
                },

                new Songs
                {
                    Id         = 5,
                    AlbumId    = 3,
                    ArtistId     = 2,
                    SongName   = "Good Times Bad Times",
                    SongLyrics = "eee eee eee",
                    SongUrl    = "youtube.com/eee",
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                    Album = new Albums
                    {
                        Id        = 3,
                        ArtistId    = 2,
                        AlbumName = "Led Zeppelin",
                        Issued    = DateTime.Parse("1969-01-01")
                    }
                },

                new Songs
                {
                    Id         = 6,
                    AlbumId    = 3,
                    ArtistId     = 2,
                    SongName   = "You Shook Me",
                    SongLyrics = "fff fff fff",
                    SongUrl    = "youtube.com/fff",
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                    Album = new Albums
                    {
                        Id        = 3,
                        ArtistId    = 2,
                        AlbumName = "Led Zeppelin",
                        Issued    = DateTime.Parse("1969-01-01")
                    }
                },

                new Songs
                {
                    Id         = 7,
                    AlbumId    = 4,
                    ArtistId     = 2,
                    SongName   = "Whole Lotta Love",
                    SongLyrics = "ggg ggg ggg",
                    SongUrl    = "youtube.com/ggg",
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                    Album = new Albums
                    {
                        Id        = 4,
                        ArtistId    = 2,
                        AlbumName = "Led Zeppelin II",
                        Issued    = DateTime.Parse("1969-01-01")
                    }
                },

                new Songs
                {
                    Id         = 8,
                    AlbumId    = 4,
                    ArtistId     = 2,
                    SongName   = "Moby Dick",
                    SongLyrics = "hhh hhh hhh",
                    SongUrl    = "youtube.com/hhh",
                    Artist = new Artists
                    {
                        ArtistName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                    Album = new Albums
                    {
                        Id        = 4,
                        ArtistId    = 2,
                        AlbumName = "Led Zeppelin II",
                        Issued    = DateTime.Parse("1969-01-01")
                    }
                },

            };

        }

    }

}
