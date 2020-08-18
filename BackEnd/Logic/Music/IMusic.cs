using System.Threading.Tasks;
using System.Collections.Generic;
using BackEnd.Models.Json;

namespace BackEnd.Logic.Music
{

    public interface IMusic
    {

        /// <summary>
        /// Return all albums/given album (by BandId) from the entire collection.
        /// </summary>
        /// <param name="BandId"></param>
        /// <returns></returns>
        Task<List<Album>> GetAlbums(int? BandId);

        /// <summary>
        /// Return specific album for given Album Id.
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns></returns>
        Task<List<Album>> GetAlbum(int AlbumId);

        /// <summary>
        /// Return specific song (or songs) from given band's album.
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns></returns>
        Task<List<Song>> GetAlbumSongs(int? AlbumId);

        /// <summary>
        /// Return given song from the entire collection.
        /// </summary>
        /// <param name="SongId"></param>
        /// <returns></returns>
        Task<List<Song>> GetSong(int SongId);

    }

}
