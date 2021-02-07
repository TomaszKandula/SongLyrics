using System.Threading.Tasks;
using System.Collections.Generic;
using SongLyrics.Controllers.Artists.Models;

namespace SongLyrics.Logic.Artists
{
    public interface IArtists
    {
        /// <summary>
        /// Return list of bands from the entire collection.
        /// </summary>
        /// <param name="AArtistId"></param>
        /// <returns></returns>
        Task<List<Artist>> GetArtists(int? AArtistId);

        /// <summary>
        /// Return bands members for given Band Id.
        /// </summary>
        /// <param name="AArtistId"></param>
        /// <returns></returns>
        Task<List<Member>> GetMembers(int AArtistId);

        /// <summary>
        /// Return band details for given Band Id.
        /// </summary>
        /// <param name="AArtistId"></param>
        /// <returns></returns>
        Task<ReturnArtistDetails> GetArtistDetails(int AArtistId);
    }
}
