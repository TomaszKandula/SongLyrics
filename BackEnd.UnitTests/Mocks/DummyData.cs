using System;
using System.Collections.Generic;
using BackEnd.Models.Database;

namespace BackEnd.UnitTests.Mocks
{

    public static class DummyData
    {

        public static List<Bands> ReturnDummyArtists() 
        {

            return new List<Bands>()
            {

                new Bands
                {
                    Id          = 1,
                    BandName    = "Queen",
                    Established = DateTime.Parse("1970-01-01"),
                    ActiveUntil = null
                },

                new Bands
                { 
                    Id          = 2,
                    BandName    = "Led Zeppelin",
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
                    BandId    = 1,
                    AlbumName = "Queen",
                    Issued    = DateTime.Parse("1973-01-01"),
                    Band = new Bands
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                },

                new Albums
                {
                    Id        = 2,
                    BandId    = 1,
                    AlbumName = "Queen II",
                    Issued    = DateTime.Parse("1974-01-01"),
                    Band = new Bands
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                },

                new Albums
                {
                    Id        = 3,
                    BandId    = 2,
                    AlbumName = "Led Zeppelin",
                    Issued    = DateTime.Parse("1969-01-01"),
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    }
                },

                new Albums
                {
                    Id        = 4,
                    BandId    = 2,
                    AlbumName = "Led Zeppelin II",
                    Issued    = DateTime.Parse("1969-01-01"),
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
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

        public static List<BandsGeneres> ReturnDummyBandsGeneres()
        {

            return new List<BandsGeneres>()
            {

                new BandsGeneres
                { 
                    Id       = 1,
                    BandId   = 1,
                    GenereId = 1,
                    Band = new Bands 
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                    Genere = new Generes 
                    { 
                        Id = 1,
                        Genere = "Rock"
                    }

                },
                
                new BandsGeneres
                {
                    Id       = 2,
                    BandId   = 2,
                    GenereId = 1,
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
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
                    BandId    = 1,
                    FirstName = "Brian",
                    LastName  = "May",
                    IsPresent = true,
                    Band = new Bands
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    }
                },

                new Members
                {
                    Id        = 2,
                    BandId    = 1,
                    FirstName = "Roger",
                    LastName  = "Taylor",
                    IsPresent = true,
                    Band = new Bands
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    }                
                },

                new Members
                {
                    Id        = 3,
                    BandId    = 1,
                    FirstName = "John",
                    LastName  = "Deacon",
                    IsPresent = false,
                    Band = new Bands
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    }
                },

                new Members
                {
                    Id        = 4,
                    BandId    = 1,
                    FirstName = "Freddie",
                    LastName  = "Mercury",
                    IsPresent = false,
                    Band = new Bands
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    }
                },

                new Members
                {
                    Id        = 5,
                    BandId    = 2,
                    FirstName = "Robert",
                    LastName  = "Plant",
                    IsPresent = false,
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                },

                new Members
                {
                    Id        = 6,
                    BandId    = 2,
                    FirstName = "Jimmy",
                    LastName  = "Page",
                    IsPresent = false,
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                },

                new Members
                {
                    Id        = 7,
                    BandId    = 2,
                    FirstName = "John",
                    LastName  = "Jones",
                    IsPresent = false,
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                },

                new Members
                {
                    Id        = 8,
                    BandId    = 2,
                    FirstName = "John",
                    LastName  = "Bonham",
                    IsPresent = false,
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
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
                    BandId     = 1,
                    SongName   = "Keep Yourself Alive",
                    SongLyrics = "aaa aaa aaa",
                    SongUrl    = "youtube.com/aaa",
                    Band = new Bands
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                    Album = new Albums
                    {
                        Id        = 1,
                        BandId    = 1,
                        AlbumName = "Queen",
                        Issued    = DateTime.Parse("1973-01-01")
                    }
                },

                new Songs
                {
                    Id         = 2,
                    AlbumId    = 1,
                    BandId     = 1,
                    SongName   = "Liar",
                    SongLyrics = "bbb bbb bbb",
                    SongUrl    = "youtube.com/bbb",
                    Band = new Bands
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                    Album = new Albums
                    {
                        Id        = 1,
                        BandId    = 1,
                        AlbumName = "Queen",
                        Issued    = DateTime.Parse("1973-01-01")
                    }
                },

                new Songs
                {
                    Id         = 3,
                    AlbumId    = 2,
                    BandId     = 1,
                    SongName   = "Seven Seas of Rhye",
                    SongLyrics = "ccc ccc ccc",
                    SongUrl    = "youtube.com/ccc",
                    Band = new Bands
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                    Album = new Albums
                    {
                        Id        = 2,
                        BandId    = 1,
                        AlbumName = "Queen II",
                        Issued    = DateTime.Parse("1974-01-01")
                    }
                },

                new Songs
                {
                    Id         = 4,
                    AlbumId    = 2,
                    BandId     = 1,
                    SongName   = "White Queen",
                    SongLyrics = "ddd ddd ddd",
                    SongUrl    = "youtube.com/ddd",
                    Band = new Bands
                    {
                        BandName    = "Queen",
                        Established = DateTime.Parse("1970-01-01"),
                        ActiveUntil = null
                    },
                    Album = new Albums
                    {
                        Id        = 2,
                        BandId    = 1,
                        AlbumName = "Queen II",
                        Issued    = DateTime.Parse("1974-01-01")
                    }
                },

                new Songs
                {
                    Id         = 5,
                    AlbumId    = 3,
                    BandId     = 2,
                    SongName   = "Good Times Bad Times",
                    SongLyrics = "eee eee eee",
                    SongUrl    = "youtube.com/eee",
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                    Album = new Albums
                    {
                        Id        = 3,
                        BandId    = 2,
                        AlbumName = "Led Zeppelin",
                        Issued    = DateTime.Parse("1969-01-01")
                    }
                },

                new Songs
                {
                    Id         = 6,
                    AlbumId    = 3,
                    BandId     = 2,
                    SongName   = "You Shook Me",
                    SongLyrics = "fff fff fff",
                    SongUrl    = "youtube.com/fff",
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                    Album = new Albums
                    {
                        Id        = 3,
                        BandId    = 2,
                        AlbumName = "Led Zeppelin",
                        Issued    = DateTime.Parse("1969-01-01")
                    }
                },

                new Songs
                {
                    Id         = 7,
                    AlbumId    = 4,
                    BandId     = 2,
                    SongName   = "Whole Lotta Love",
                    SongLyrics = "ggg ggg ggg",
                    SongUrl    = "youtube.com/ggg",
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                    Album = new Albums
                    {
                        Id        = 4,
                        BandId    = 2,
                        AlbumName = "Led Zeppelin II",
                        Issued    = DateTime.Parse("1969-01-01")
                    }
                },

                new Songs
                {
                    Id         = 8,
                    AlbumId    = 4,
                    BandId     = 2,
                    SongName   = "Moby Dick",
                    SongLyrics = "hhh hhh hhh",
                    SongUrl    = "youtube.com/hhh",
                    Band = new Bands
                    {
                        BandName    = "Led Zeppelin",
                        Established = DateTime.Parse("1968-01-01"),
                        ActiveUntil = DateTime.Parse("1980-01-01")
                    },
                    Album = new Albums
                    {
                        Id        = 4,
                        BandId    = 2,
                        AlbumName = "Led Zeppelin II",
                        Issued    = DateTime.Parse("1969-01-01")
                    }
                },

            };

        }

    }

}
