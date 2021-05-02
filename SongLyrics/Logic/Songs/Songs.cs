using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SongLyrics.Shared.Dto;
using SongLyrics.Infrastructure.Database;

namespace SongLyrics.Logic.Songs
{
    public class Songs : ISongs
    {
        private readonly MainDbContext FMainDbContext;

        public Songs(MainDbContext AMainDbContext)
            => FMainDbContext = AMainDbContext;

        /// <summary>
        /// Return specific song (or songs) from given band's album.
        /// </summary>
        /// <param name="AAlbumId"></param>
        /// <param name="ACancellationToken"></param>
        /// <returns></returns>
        public async Task<List<SongDto>> GetAlbumSongs(int? AAlbumId, CancellationToken ACancellationToken = default)
        {
            if (AAlbumId != null)
            {
                return await FMainDbContext.Songs
                    .AsNoTracking()
                    .Include(ASongs => ASongs.Album)
                    .Include(ASongs => ASongs.Artist)
                    .Where(ASongs => ASongs.AlbumId == AAlbumId)
                    .Select(ASongs => new SongDto
                    {
                        Id = ASongs.Id,
                        Name = ASongs.SongName,
                        AlbumName = ASongs.Album.AlbumName,
                        ArtistName = ASongs.Artist.ArtistName
                    })
                    .ToListAsync(ACancellationToken);
            }

            return await FMainDbContext.Songs
                .AsNoTracking()
                .Include(ASongs => ASongs.Album)
                .Include(ASongs => ASongs.Artist)
                .Select(ASongs => new SongDto
                {
                    Id = ASongs.Id,
                    Name = ASongs.SongName,
                    AlbumName = ASongs.Album.AlbumName,
                    ArtistName = ASongs.Artist.ArtistName
                })
                .ToListAsync(ACancellationToken);
        }

        /// <summary>
        /// Return given song from the entire collection.
        /// </summary>
        /// <param name="ASongId"></param>
        /// <param name="ACancellationToken"></param>
        /// <returns></returns>
        public async Task<SingleSongDto> GetSong(int ASongId, CancellationToken ACancellationToken = default)
        {
            return await FMainDbContext.Songs
                .AsNoTracking()
                .Include(ASongs => ASongs.Album)
                .Include(ASongs => ASongs.Artist)
                .Where(ASongs => ASongs.Id == ASongId)
                .Select(ASongs => new SingleSongDto
                {
                    Name = ASongs.SongName,
                    Lyrics = ASongs.SongLyrics,
                    Url = ASongs.SongUrl,
                    AlbumName = ASongs.Album.AlbumName,
                    ArtistName = ASongs.Artist.ArtistName
                })
                .SingleOrDefaultAsync(ACancellationToken);
        }
    }
}
