﻿using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models.Json;
using BackEnd.Models.Database;

namespace BackEnd.Logic.Music
{

    public class Music : IMusic
    {

        private readonly MainDbContext FMainDbContext;

        public Music(MainDbContext AMainDbContext) 
        {
            FMainDbContext = AMainDbContext;
        }

        /// <summary>
        /// Return all albums/given album from the entire collection.
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns></returns>
        public async Task<List<Album>> GetAlbums(int? AlbumId) 
        {

            if (AlbumId != null)
            {

                return await FMainDbContext.Albums
                    .AsNoTracking()
                    .Include(R => R.Band)
                    .Where(R => R.Id == AlbumId)
                    .Select(R => new Album 
                    { 
                        Id        = R.Id,
                        AlbumName = R.AlbumName,
                        BandName  = R.Band.BandName
                    })
                    .ToListAsync();

            }
            else 
            {

                return await FMainDbContext.Albums
                    .AsNoTracking()
                    .Include(R => R.Band)
                    .Select(R => new Album
                    {
                        Id        = R.Id,
                        AlbumName = R.AlbumName,
                        BandName  = R.Band.BandName
                    })
                    .ToListAsync();

            }

        }

        /// <summary>
        /// Return specific album for given Band Id.
        /// </summary>
        /// <param name="bandId"></param>
        /// <returns></returns>
        public async Task<List<Album>> GetAlbum(int BandId) 
        { 

             return await FMainDbContext.Albums
                .AsNoTracking()
                .Include(R => R.Band)
                .Where(R => R.BandId == BandId)
                .Select(R => new Album 
                { 
                    Id        = R.Id,
                    AlbumName = R.AlbumName,
                    BandName  = R.Band.BandName
                })
                .ToListAsync();

        }

        /// <summary>
        /// Return all songs/given song from the entire collection.
        /// </summary>
        /// <param name="SongId"></param>
        /// <returns></returns>
        public async Task<List<Song>> GetSongs(int? SongId) 
        {

            if (SongId != null)
            {

                return await FMainDbContext.Songs
                    .AsNoTracking()
                    .Include(R => R.Album)
                    .Include(R => R.Band)
                    .Where(R => R.Id == SongId)
                    .Select(R => new Song 
                    { 
                        Name      = R.SongName,
                        Lyrics    = R.SongLyrics,
                        Url       = R.SongUrl,
                        AlbumName = R.Album.AlbumName,
                        BandName  = R.Band.BandName
                    })
                    .ToListAsync();

            }
            else 
            {
            
                return await FMainDbContext.Songs
                    .AsNoTracking()
                    .Include(R => R.Album)
                    .Include(R => R.Band)
                    .Select(R => new Song 
                    { 
                        Name      = R.SongName,
                        Lyrics    = R.SongLyrics,
                        Url       = R.SongUrl,
                        AlbumName = R.Album.AlbumName,
                        BandName  = R.Band.BandName
                    })
                    .ToListAsync();

            }
        
        }

        /// <summary>
        /// Return specific song from given band's album.
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns></returns>
        public async Task<List<Song>> GetAlbumSong(int AlbumId) 
        {

            return await FMainDbContext.Songs
                .AsNoTracking()
                .Include(R => R.Album)
                .Include(R => R.Band)
                .Where(R => R.AlbumId == AlbumId)
                .Select(R => new Song
                {
                    Name      = R.SongName,
                    Lyrics    = R.SongLyrics,
                    Url       = R.SongUrl,
                    AlbumName = R.Album.AlbumName,
                    BandName  = R.Band.BandName
                })
                .ToListAsync();

        }

    }

}
