using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SongLyrics.Shared.Dto;

namespace SongLyrics.Logic.Albums
{
    public interface IAlbums
    {
        /// <summary>
        /// Return all albums/given album (by BandId) from the entire collection.
        /// </summary>
        /// <param name="ABandId"></param>
        /// <param name="ACancellationToken"></param>
        /// <returns></returns>
        Task<List<AlbumDto>> GetAlbums(int? ABandId, CancellationToken ACancellationToken = default);

        /// <summary>
        /// Return specific album for given Album Id.
        /// </summary>
        /// <param name="AAlbumId"></param>
        /// <param name="ACancellationToken"></param>
        /// <returns></returns>
        Task<List<AlbumDto>> GetAlbum(int AAlbumId, CancellationToken ACancellationToken = default);
    }
}
