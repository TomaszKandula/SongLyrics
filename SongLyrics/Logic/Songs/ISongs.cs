using System.Threading.Tasks;
using System.Collections.Generic;
using BackEnd.Controllers.Songs.Models;

namespace BackEnd.Logic.Songs
{

    public interface ISongs
    {

        /// <summary>
        /// Return specific song (or songs) from given band's album.
        /// </summary>
        /// <param name="AAlbumId"></param>
        /// <returns></returns>
        Task<List<Song>> GetAlbumSongs(int? AAlbumId);

        /// <summary>
        /// Return given song from the entire collection.
        /// </summary>
        /// <param name="ASongId"></param>
        /// <returns></returns>
        Task<SingleSong> GetSong(int ASongId);

    }

}
