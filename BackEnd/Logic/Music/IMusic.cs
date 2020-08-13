using System.Threading.Tasks;
using System.Collections.Generic;
using BackEnd.Models.Json;

namespace BackEnd.Logic.Music
{

    public interface IMusic
    {

        /// <summary>
        /// Return all albums/given album from the entire collection.
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns></returns>
        Task<List<Album>> GetAlbums(int? AlbumId);

        /// <summary>
        /// Return specific album for given Band Id.
        /// </summary>
        /// <param name="bandId"></param>
        /// <returns></returns>
        Task<List<Album>> GetAlbum(int BandId);

        /// <summary>
        /// Return all songs/given song from the entire collection.
        /// </summary>
        /// <param name="SongId"></param>
        /// <returns></returns>
        Task<List<Song>> GetSongs(int? SongId);

        /// <summary>
        /// Return specific song from given band's album.
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns></returns>
        Task<List<Song>> GetAlbumSongs(int AlbumId);

    }

}
