using System.Threading.Tasks;
using System.Collections.Generic;
using BackEnd.Models.Json;

namespace BackEnd.Logic.Songs
{

    public interface ISongs
    {

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
