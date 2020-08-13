using System.Threading.Tasks;
using System.Collections.Generic;
using BackEnd.Models.Json;

namespace BackEnd.Logic.Music
{

    public interface IMusic
    {

        Task<List<Album>> GetAlbums(int? AlbumId);

        Task<List<Album>> GetAlbum(int BandId);

        Task<List<Song>> GetSongs(int? SongId);

    }

}
