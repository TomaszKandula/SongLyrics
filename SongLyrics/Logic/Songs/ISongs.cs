using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SongLyrics.Shared.Dto;

namespace SongLyrics.Logic.Songs
{
    public interface ISongs
    {
        /// <summary>
        /// Return specific song (or songs) from given band's album.
        /// </summary>
        /// <param name="AAlbumId"></param>
        /// <returns></returns>
        Task<List<SongDto>> GetAlbumSongs(int? AAlbumId, CancellationToken ACancellationToken = default);

        /// <summary>
        /// Return given song from the entire collection.
        /// </summary>
        /// <param name="ASongId"></param>
        /// <returns></returns>
        Task<SingleSongDto> GetSong(int ASongId, CancellationToken ACancellationToken = default);
    }
}
