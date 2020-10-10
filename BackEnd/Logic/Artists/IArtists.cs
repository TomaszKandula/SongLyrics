using System.Threading.Tasks;
using System.Collections.Generic;
using BackEnd.Controllers.Artists.Models;

namespace BackEnd.Logic.Artists
{

    public interface IArtists
    {

        /// <summary>
        /// Return list of bands from the entire collection.
        /// </summary>
        /// <param name="ArtistId"></param>
        /// <returns></returns>
        Task<List<Artist>> GetArtists(int? ArtistId);

        /// <summary>
        /// Return bands members for given Band Id.
        /// </summary>
        /// <param name="ArtistId"></param>
        /// <returns></returns>
        Task<List<Member>> GetMembers(int ArtistId);

        /// <summary>
        /// Return band details for given Band Id.
        /// </summary>
        /// <param name="ArtistId"></param>
        /// <returns></returns>
        Task<ReturnArtistDetails> GetArtistDetails(int ArtistId);

    }

}
